'use server';
import * as z from 'zod';
import { LoginFormSchema } from '@/forms/schemas/login-form-schema';
import { signIn } from '@/auth';
import { DEFAULT_LOGIN_REDIRECT } from '../routes';
import { AuthError } from 'next-auth';

export const login = async (
  data: z.infer<typeof LoginFormSchema>,
  callbackUrl: string | null
) => {
  const validatedFields = LoginFormSchema.safeParse(data);
  if (!validatedFields.success) {
    return {
      message: 'Missing Fields. Failed to Login!',
      errors: validatedFields.error.flatten().fieldErrors,
    };
  }
  try {
    await signIn('credentials', {
      email: data.email,
      password: data.password,
      callbackUrl: callbackUrl ?? DEFAULT_LOGIN_REDIRECT,
    });
    return {
      message: 'Login Successfully!',
      errors: null,
    };
  } catch (error) {
    if (error instanceof AuthError) {
      switch (error.type) {
        case 'CredentialsSignin':
          return {
            message: 'Invalid credentials!',
            errors: 'Invalid credentials!',
          };
        default:
          return {
            message: 'Something went worng!',
            errors: 'Something went worng!',
          };
      }
    }
    throw error;
  }
};

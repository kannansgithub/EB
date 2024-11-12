import * as z from 'zod';

const LoginFormSchema = z.object({
  email: z.string().email({ message: 'Enter a valid email address' }),
  password: z.string(),
});

export { LoginFormSchema };

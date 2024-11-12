'use client';
import { Button } from '@/components/ui/button';
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import * as z from 'zod';

import { zodResolver } from '@hookform/resolvers/zod';
import { signIn } from 'next-auth/react';
import { useSearchParams } from 'next/navigation';
import { useTransition } from 'react';
import { useForm } from 'react-hook-form';
import toasterMessage from '@/lib/tost-alert';
import { ThemeSwitcher } from '@/components/layout/themes/theme-switch';
import Icon from '@/components/custom/icon';
import FormError from '@/components/custom/form-error';
import FormSuccess from '@/components/custom/form-success';
import { login } from '@/actions/login';
import { LoginFormSchema } from '@/forms/schemas/login-form-schema';

type UserFormValue = z.infer<typeof LoginFormSchema>;
const defaultValues = {
  email: 'admin@root.com',
  password: '123456',
};

export default function UserAuthForm() {
  const searchParams = useSearchParams();
  const callbackUrl = searchParams.get('callbackUrl');
  const [loading, startTransition] = useTransition();

  const form = useForm<UserFormValue>({
    resolver: zodResolver(LoginFormSchema),
    defaultValues,
  });

  const onSubmit = async (data: UserFormValue) => {
    startTransition(async () => {
      const response = await login(data, callbackUrl);
      if (response.errors) {
        toasterMessage.error(response.message);
      } else {
        toasterMessage.success(response.message);
      }
    });

    // console.log('result: ', result);
    // if (result?.error) {
    //   toasterMessage.error('Login failed! Please check your credentials.');
    // } else {
    //   toasterMessage.success('Signed In Successfully!');
    // }
  };

  return (
    <>
      <Form {...form}>
        <form
          onSubmit={form.handleSubmit(onSubmit)}
          className="w-full space-y-2"
        >
          <FormField
            control={form.control}
            name="email"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Email</FormLabel>
                <FormControl>
                  <Input
                    type="email"
                    placeholder="Enter your email..."
                    disabled={loading}
                    {...field}
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="password"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Password</FormLabel>
                <FormControl>
                  <Input
                    type="password"
                    placeholder="Enter your Password"
                    disabled={loading}
                    {...field}
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <ThemeSwitcher />
          <Icon iconName="BiMenuAltLeft" set="bi" size={40} color="blue" />
          <FormError message="Oops somthing bad happend" />
          <FormSuccess message="Email Sent Successfully!" />
          <Button disabled={loading} className="ml-auto w-full" type="submit">
            Signin
          </Button>
        </form>
      </Form>
    </>
  );
}

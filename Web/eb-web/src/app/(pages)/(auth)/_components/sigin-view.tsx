import { Metadata } from 'next';
import Link from 'next/link';
import { buttonVariants } from '@/components/ui/button';
import { cn } from '@/lib/utils';
import UserAuthForm from './user-auth-form';
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from '@/components/ui/card';
import Image from 'next/image';
import LoginPageCarousel from '@/components/loginpage-carousel';

export const metadata: Metadata = {
  title: 'Authentication',
  description: 'Authentication forms built using the components.',
};

export default function SignInViewPage() {
  return (
    <div className="relative h-screen flex-col items-center justify-center md:grid lg:max-w-none lg:grid-cols-2 lg:px-0">
      <Link
        href="/examples/authentication"
        className={cn(
          buttonVariants({ variant: 'ghost' }),
          'absolute right-4 top-4 hidden md:right-8 md:top-8'
        )}
      >
        Login
      </Link>
      <div className="relative hidden h-full flex-col lg:flex dark:border-r">
        <div className="absolute" />

        <div>
          <Image
            src={'/img/login_bg.png'}
            alt="logo"
            layout="fill"
            objectFit="cover"
            className="w-full -z-1 -mb-40"
            // style={{
            //   maskImage:
            //     'linear-gradient(to bottom, rgba(0,0,0,1), rgba(0,0,0,0))',
            // }}
          />
        </div>
        <div className="relative z-20 mt-auto">
          <blockquote className="space-y-2">
            <LoginPageCarousel />
          </blockquote>
        </div>
      </div>
      <div className="flex h-full items-center p-4 lg:p-8">
        <div className="mx-auto flex w-full flex-col justify-center space-y-6 sm:w-[450px]">
          <Card>
            <div className="flex flex-col space-y-2 text-center">
              <CardHeader>
                <CardTitle>
                  <h1 className="text-2xl font-semibold tracking-tight">
                    Enter your credentials
                  </h1>
                </CardTitle>
                <CardDescription>
                  <p className="text-sm text-muted-foreground">
                    Enter your email and password below to login account
                  </p>
                </CardDescription>
              </CardHeader>
            </div>
            <CardContent>
              <UserAuthForm />
            </CardContent>
            <CardFooter>
              <p className="px-8 text-center text-sm text-muted-foreground">
                By clicking continue, you agree to our{' '}
                <Link
                  href="/terms"
                  className="underline underline-offset-4 hover:text-primary"
                >
                  Terms of Service
                </Link>{' '}
                and{' '}
                <Link
                  href="/privacy"
                  className="underline underline-offset-4 hover:text-primary"
                >
                  Privacy Policy
                </Link>
                .
              </p>
            </CardFooter>
          </Card>
        </div>
      </div>
    </div>
  );
}

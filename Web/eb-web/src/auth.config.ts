import CredentialProvider from 'next-auth/providers/credentials';
import type { NextAuthConfig } from 'next-auth';
import { UserService } from '@/services/userService';
export default {
  providers: [
    CredentialProvider({
      name: 'Credentials',
      credentials: {
        email: { label: 'Username', type: 'text', placeholder: 'kannan' },
        password: { label: 'Password', type: 'password' },
      },
      async authorize(credentials) {
        const { email, password } = credentials;
        const res = await UserService.Login({ email, password });
        if (res.code === 200) {
          const user = res?.content;
          console.log('user: ', user);
          if (user) {
            return user;
          } else {
            return null;
          }
        } else {
          return null;
        }
      },
    }),
  ],
  pages: {
    signIn: '/',
    signOut: '/',
  },
  session: {
    strategy: 'jwt',
    maxAge: 30 * 24 * 60 * 60, // 30 days
  },
  callbacks: {
    async jwt({ token, user }) {
      return { ...token, ...user };
    },
    async session({ session, token }) {
      //@ts-expect-error "This is a bug in the types"
      session.user = token as unknown;
      return session;
    },
  },
} satisfies NextAuthConfig;

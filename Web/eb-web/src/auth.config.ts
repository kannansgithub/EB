import '../envConfig';
import CredentialProvider from 'next-auth/providers/credentials';
import type { NextAuthConfig, User } from 'next-auth';
import axios from 'axios';
import toasterMessage from './lib/tost-alert';
const authConfig = {
  session: {
    strategy: 'jwt',
  },
  providers: [
    CredentialProvider({
      name: 'Credentials',
      credentials: {
        username: { label: 'Username', type: 'text', placeholder: 'jsmith' },
        password: { label: 'Password', type: 'password' },
      },
      async authorize(credentials, req) {
        const { email, password } = credentials as {
          email: string;
          password: string;
        };
        try {
          const res = await axios.post(
            'http://localhost:5181/api/Account/Login',
            {
              email,
              password,
            }
          );
          console.log('Response Data: ', res.data?.message);
          if (res.data.code === 200) {
            const user = res?.data?.content;
            if (user) {
              return user;
            } else {
              return null;
            }
          } else {
            toasterMessage.error(res.data.message);
          }
        } catch {
          toasterMessage.error('Something went wrong');
        }
        // const user = res.data;
      },
    }),
  ],
  pages: {
    error: '/',
    signIn: '/',
    signOut: '/',
  },
  secret: 'DSHFSKDJHF345345JH34543',
  callbacks: {
    async jwt({ token, user }) {
      return { ...token, ...user };
    },
    async session({ session }) {
      return session;
    },
  },
} satisfies NextAuthConfig;

export default authConfig;

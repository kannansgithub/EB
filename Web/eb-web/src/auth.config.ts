import CredentialProvider from 'next-auth/providers/credentials';
//@ts-expect-error "This is a bug in the types"
import type { NextAuthConfig } from 'next-auth';
import axios from 'axios';
export default {
  providers: [
    CredentialProvider({
      name: 'Credentials',
      credentials: {
        username: { label: 'Username', type: 'text', placeholder: 'kannan' },
        password: { label: 'Password', type: 'password' },
      },
      async authorize(credentials) {
        const { email, password } = credentials;
        const res = await axios.post(
          `${process.env.API_ENPOINT}/api/Account/Login`,
          {
            email,
            password,
          }
        );
        if (res.data.code === 200) {
          const user = res?.data?.content;
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
  callbacks: {
    async jwt({ token, user }: unknown) {
      return { ...token, ...user };
    },
    async session({ session, token }: unknown) {
      session.user = token;
      return session;
    },
  },
} satisfies NextAuthConfig;

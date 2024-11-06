import '../envConfig';
import CredentialProvider from 'next-auth/providers/credentials';
import type { NextAuthConfig } from 'next-auth';
import axios from 'axios';
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
      async authorize(credentials) {
        const { username, password } = credentials as {
          username: string;
          password: string;
        };
        const user = {
          id: '1',
          name: 'John Doe',
          email: 'jsmith@example.com',
        };
        // const res = await axios.post('http://localhost:3000/api/auth/signin', {
        //   username,
        //   password,
        // });
        // const user = res.data;
        if (user) {
          return user;
        } else {
          return null;
        }
      },
    }),
  ],
  pages: {
    error: '/',
    signIn: '/',
    signOut: '/',
  },
  secret: 'DSHFSKDJHF345345JH34543',
} satisfies NextAuthConfig;

export default authConfig;

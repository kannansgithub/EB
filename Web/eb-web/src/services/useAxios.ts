import axios from 'axios';
import { getSession, signIn, signOut } from 'next-auth/react';
const useAxios = axios.create({
  baseURL: process.env.API_ENPOINT,
  headers: {
    'Content-Type': 'application/json',
  },
});
const useAuthAxios = axios.create({
  baseURL: process.env.NEXT_PUBLIC_API_ENPOINT,
  headers: {
    'Content-Type': 'application/json',
  },
});
useAuthAxios.interceptors.request.use(async (config) => {
  const session = await getSession();
  const token = session?.user;
  if (token) {
    config.headers.Authorization = `Bearer ${token.accessToken}`;
  }
  return config;
});
useAuthAxios.interceptors.response.use(
  (response) => {
    return response;
  },
  async (error) => {
    const prevRequest = error?.config;
    if (error?.response?.status === 401 && !prevRequest?.sent) {
      prevRequest.sent = true;
      const session = await getSession();

      const res = await useAxios.post('/api/Account/RefreshAccessToken', {
        refreshToken: session?.user.refreshToken,
      });

      if (session) session.user.accessToken = res.data.accessToken;
      else signIn();

      prevRequest.headers[
        'Authorization'
      ] = `Bearer ${session?.user.accessToken}`;
      return useAuthAxios(prevRequest);
    }
    if (error?.response?.status === 401) {
      signOut();
    }
    return Promise.reject(error);
  }
);
export { useAuthAxios };
export default useAxios;

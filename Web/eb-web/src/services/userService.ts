import useAxios, { useAuthAxios } from './useAxios';

const UserService = {
  Login: async ({ email, password }: { email: unknown; password: unknown }) => {
    const { data } = await useAxios.post('/api/Account/Login', {
      email,
      password,
    });
    return data;
  },
  getLoginStatus: async () => {
    const { data } = await useAuthAxios.get('/api/Account/CheckLoginStatus');
    return data;
  },
};

export { UserService };

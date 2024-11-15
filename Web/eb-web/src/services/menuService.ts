import useAxios from './useAxios';

const MenuService = {
  GetMenu: async () => {
    const { data } = await useAxios.get('/api/Account/CheckLoginStatus');
    return data;
  },
}

export default MenuService;
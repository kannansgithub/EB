import { createSlice } from '@reduxjs/toolkit';
import { initialState } from '../states/theme.state';

export const theme = createSlice({
  name: 'theme',
  initialState,
  reducers: {
    setCurrentTheme: (state, action) => {
      state.currentTheme = action.payload;
    },
  },
});

export const { setCurrentTheme } = theme.actions;
export default theme.reducer;

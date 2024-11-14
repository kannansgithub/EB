'use client';
import React from 'react';
import { SessionProvider, SessionProviderProps } from 'next-auth/react';
import { ThemeProvider } from './themes/theme-provider';
import { ThemeContext } from './theme-context';
export default function Providers({
  session,
  children,
}: {
  session: SessionProviderProps['session'];
  children: React.ReactNode;
}) {
  const [theme, setTheme] = React.useState('light'); // or 'dark'
  return (
    <>
      <ThemeProvider
        attribute="class"
        defaultTheme={theme}
        enableSystem
        disableTransitionOnChange
      >
        <ThemeContext.Provider value={{ theme, setTheme }}>
          <SessionProvider session={session}>{children}</SessionProvider>
        </ThemeContext.Provider>
      </ThemeProvider>
    </>
  );
}

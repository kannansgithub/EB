'use client';
import React from 'react';
import { SessionProvider, SessionProviderProps } from 'next-auth/react';
import ReduxProvider from './redux-provider';
import { ThemeProvider } from './theme-provider';
export default function Providers({
  session,
  children,
}: {
  session: SessionProviderProps['session'];
  children: React.ReactNode;
}) {
  return (
    <>
      <ReduxProvider>
        <ThemeProvider
          attribute="class"
          defaultTheme="system"
          enableSystem
          disableTransitionOnChange
        >
          <SessionProvider session={session}>{children}</SessionProvider>
        </ThemeProvider>
      </ReduxProvider>
    </>
  );
}

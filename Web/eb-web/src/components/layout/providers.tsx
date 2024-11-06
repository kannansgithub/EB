'use client';
import React from 'react';
import { SessionProvider, SessionProviderProps } from 'next-auth/react';
import { ThemeProvider } from './themes/theme-provider';
export default function Providers({
  session,
  children,
}: {
  session: SessionProviderProps['session'];
  children: React.ReactNode;
}) {
  return (
    <>
      <ThemeProvider
        attribute="class"
        defaultTheme="system"
        enableSystem
        disableTransitionOnChange
      >
        <SessionProvider session={session}>{children}</SessionProvider>
      </ThemeProvider>
    </>
  );
}

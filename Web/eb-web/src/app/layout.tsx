import NextTopLoader from 'nextjs-toploader';
import { ToastContainer } from 'react-toastify';
import './globals.css';
import 'react-toastify/dist/ReactToastify.css';

import { auth } from '@/auth';
import Providers from '@/components/layout/providers';
import { geistMono, geistSans } from './fonts/local';

import { metadataHomePage } from '@/data/MetaDataInfo';
import { Metadata } from 'next';

export const metadata: Metadata = metadataHomePage;

export default async function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  const session = await auth();
  return (
    <html lang="en">
      <body
        className={`${geistSans.variable} ${geistMono.variable} antialiased`}
      >
        <NextTopLoader showSpinner={false} />
        <Providers session={session}>
          <div className="relative h-full overflow-hidden bg-background">
            <ToastContainer />
            {children}
          </div>
        </Providers>
      </body>
    </html>
  );
}

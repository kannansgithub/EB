'use client';
import { useSession } from 'next-auth/react';

import RootContent from '@/components/custom/root';
const AppLayout = ({ children }: { children: React.ReactNode }) => {
  const { status: sessionStatus, data: session } = useSession();
  const authorized = sessionStatus === 'authenticated';
  const loading = sessionStatus === 'loading';
  console.log(session);
  console.log(sessionStatus);
  if (typeof window !== 'undefined' && loading) return null;
  if (authorized) {
    return (
      <div className="relative h-full overflow-hidden bg-background">
        <RootContent>{children}</RootContent>
      </div>
    );
  }
  return <p>Access Denied</p>;
};

export default AppLayout;

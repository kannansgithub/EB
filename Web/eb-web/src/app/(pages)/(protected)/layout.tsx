'use client';
import { useSession } from 'next-auth/react';

import RootContent from '@/components/custom/root';
const AppLayout = ({ children }: { children: React.ReactNode }) => {
  const { status: sessionStatus } = useSession();
  const authorized = sessionStatus === 'authenticated';

  if (authorized) {
    return (
      <>
        <div className="relative h-full overflow-hidden bg-background">
          <RootContent>{children}</RootContent>
        </div>
      </>
    );
  }
  return <div>Access Denied</div>;
};

export default AppLayout;

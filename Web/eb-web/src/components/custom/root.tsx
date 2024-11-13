'use client';

import useIsCollapsed from '@/hooks/use-is-collapsed';
import SkipToMain from '@/components/skip-to-main';
import AppSidebar from '../app-sidebar';
import { Layout } from './layout';
import TopNav from '../top-nav';
import { topNavLinks } from '@/data/sidelinks';
import { Search } from '../search';
import { ThemeSwitcher } from '../layout/themes/theme-switch';
import { UserNav } from '../user-nav';

const RootContent = ({ children }: { children: React.ReactNode }) => {
  const [isCollapsed, setIsCollapsed] = useIsCollapsed();
  return (
    <div className="relative h-full overflow-hidden bg-background">
      <SkipToMain />
      <AppSidebar isCollapsed={isCollapsed} setIsCollapsed={setIsCollapsed} />
      <main
        id="content"
        className={`overflow-x-hidden pt-16 transition-[margin] md:overflow-y-hidden md:pt-0 ${
          isCollapsed ? 'md:ml-14' : 'md:ml-64'
        } h-full`}
      >
        <Layout>
          <Layout.Header>
            <TopNav links={topNavLinks} />
            <div className="ml-auto flex items-center space-x-4">
              <Search />
              <ThemeSwitcher />
              <UserNav />
            </div>
          </Layout.Header>
          <Layout.Body>{children}</Layout.Body>
        </Layout>
      </main>
    </div>
  );
};

export default RootContent;

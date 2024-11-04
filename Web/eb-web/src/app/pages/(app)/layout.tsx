import RootContent from '@/components/custom/root';
const AppLayout = ({ children }: { children: React.ReactNode }) => {
  return (
    <div className="relative h-full overflow-hidden bg-background">
      <RootContent>{children}</RootContent>
    </div>
  );
};

export default AppLayout;

import packageJson from '../../package.json';
const AppVersion = ({ isCollapsed }: { isCollapsed: boolean }) => {
  return (
    <div className="text-muted-foreground text-[10px]">
      <span>v{packageJson.version}</span>
    </div>
  );
};

export default AppVersion;

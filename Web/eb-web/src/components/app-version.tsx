import packageJson from '../../package.json';
const AppVersion = () => {
  return (
    <div className="text-white text-[10px]">
      <span>v{packageJson.version}</span>
    </div>
  );
};

export default AppVersion;

import React, { useEffect, useState } from 'react';

// Define a type for icon sets
type IconSet = 'fa' | 'md' | 'ai' | 'bi';

// A mapping of icon sets to their imports.
const iconSets: Record<IconSet, string> = {
  fa: 'react-icons/fa',
  md: 'react-icons/md',
  ai: 'react-icons/ai',
  bi: 'react-icons/bi',
};

interface DynamicIconProps {
  iconName: string; // The icon name as a string
  set: IconSet; // The icon set (fa, md, ai, etc.)
  size?: number;
  color?: string;
}

const Icon: React.FC<DynamicIconProps> = ({
  iconName,
  set,
  size = 24,
  color = 'black',
}) => {
  const [Icon, setIcon] = useState<React.ElementType | null>(null);

  useEffect(() => {
    const loadIcon = async () => {
      try {
        // Dynamically import the icon module based on the icon set and name
        const iconModule = await import(`${iconSets[set]}`);
        const LoadedIcon = iconModule[iconName];

        // If the icon is found, set it in the state
        if (LoadedIcon) {
          setIcon(() => LoadedIcon);
        } else {
          setIcon(null);
        }
      } catch (error) {
        console.error('Error loading icon:', error);
        setIcon(null);
      }
    };

    loadIcon();
  }, [iconName, set]);

  // Render the icon with the given size and color, or show an error message
  return (
    <div>
      {Icon ? (
        React.createElement(Icon, { size, color })
      ) : (
        <span>Icon not found</span>
      )}
    </div>
  );
};

export default Icon;

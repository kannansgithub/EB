'use client';
import { SaveIcon } from 'lucide-react';
import { Button } from '@/components/ui/button';

interface SaveButtonProps {
  onClick?: () => void;
}
const SaveButton = ({ onClick }: SaveButtonProps) => {
  return (
    <Button
      onClick={() => onClick && onClick()}
      variant={'outline'}
      className="text-primary bg-primary/10 hover:text-primary hover:font-medium"
    >
      <SaveIcon />
      Save
    </Button>
  );
};

export default SaveButton;

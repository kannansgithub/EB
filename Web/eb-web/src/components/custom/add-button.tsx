'use client';
import { PlusIcon } from 'lucide-react';
import { Button } from '@/components/ui/button';

interface AddButtonProps {
  onClick?: () => void;
}
const AddButton = ({ onClick }: AddButtonProps) => {
  return (
    <Button
      variant={'outline'}
      className="text-primary bg-primary/10 hover:text-primary hover:font-medium"
      onClick={() => onClick && onClick()}
    >
      <PlusIcon />
      Add New
    </Button>
  );
};

export default AddButton;

'use client';
import React from 'react';
import { Button } from '@/components/ui/button';
import { CircleXIcon } from 'lucide-react';

interface CancelButtonProps {
  onClick?: () => void;
}
const CancelButton = ({ onClick }: CancelButtonProps) => {
  return (
    <Button variant={'outline'} onClick={() => onClick && onClick()}>
      <CircleXIcon />
      Cancel
    </Button>
  );
};

export default CancelButton;

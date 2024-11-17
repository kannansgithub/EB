'use client';
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from '@/components/ui/card';
import AddButton from '@/components/custom/add-button';
import CancelButton from '@/components/custom/cancel-button';
import SaveButton from '@/components/custom/save-button';
import toasterMessage from '@/lib/tost-alert';

const MenuPage = () => {
  return (
    <>
      <Card className="p-0 m-0 border-none bg-background shadow-none">
        <CardHeader>
          <div className="flex justify-between items-center">
            <div>
              <CardTitle>Card Title</CardTitle>
              <CardDescription>Card Description</CardDescription>
            </div>
            <div className="flex gap-3">
              <AddButton
                onClick={() => toasterMessage.info('Clicked Add button')}
              />
              <SaveButton
                onClick={() => toasterMessage.success('Clicked Save button')}
              />
              <CancelButton
                onClick={() => toasterMessage.error('Clicked Cancel button')}
              />
            </div>
          </div>
        </CardHeader>
        <CardContent>
          <p>Card Content</p>
        </CardContent>
        <CardFooter>
          <p>Card Footer</p>
        </CardFooter>
      </Card>
    </>
  );
};

export default MenuPage;

import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from '@/components/ui/card';
import { Button } from '@/components/ui/button';
import { SaveIcon, CircleXIcon } from 'lucide-react';

const MenuPage = () => {
  return (
    <>
      <Card className="p-0 m-0">
        <CardHeader>
          <div className="flex justify-between items-center">
            <div>
              <CardTitle>Card Title</CardTitle>
              <CardDescription>Card Description</CardDescription>
            </div>
            <div className="flex gap-3">
              <Button
                variant={'outline'}
                className="text-primary bg-primary/10 hover:text-primary hover:font-medium"
              >
                <SaveIcon />
                Save
              </Button>
              <Button variant={'outline'}>
                <CircleXIcon />
                Cancel
              </Button>
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

'use client';
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table';
import {
  Collapsible,
  CollapsibleContent,
  CollapsibleTrigger,
} from '../ui/collapsible';
import LinksVisitors from './links-visitors';

export default function LinksTable() {
  const links = [
    {
      id: '1',
      name: 'Google',
      link: 'https://google.com',
      views: 100,
    },
    {
      id: '2',
      name: 'Youtube',
      link: 'https://youtube.com',
      views: 200,
    },
    {
      id: '3',
      name: 'Facebook',
      link: 'https://facebook.com',
      views: 300,
    },
  ]; // these are link objects, we'll get there later

  return (
    <div className="w-full sm:p-4">
      <h2 className="p-4">All links</h2>
      <div className="rounded-md sm:border">
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead className="font-medium">Name</TableHead>
              <TableHead className="font-medium">Link</TableHead>
              <TableHead className="font-medium">Views</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {links
              ? links.map((link) => (
                  <Collapsible key={link.id} asChild>
                    <>
                      <TableRow>
                        <TableCell>{link.name}</TableCell>
                        <TableCell>{link.id}</TableCell>
                        <TableCell>
                          {link.views}
                          <CollapsibleTrigger asChild>
                            <div>{link.views}</div>
                          </CollapsibleTrigger>
                        </TableCell>
                      </TableRow>
                      <CollapsibleContent asChild>
                        <LinksVisitors linkId={link.id} />
                      </CollapsibleContent>
                    </>
                  </Collapsible>
                ))
              : null}
          </TableBody>
        </Table>
      </div>
    </div>
  );
}

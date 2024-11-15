'use client';
import { TableCell, TableRow } from '@/components/ui/table';
import { Gauge } from './gauge';

export default function LinksVisitors() {
  const visitors = [
    {
      id: '1',
      name: 'John Doe',
      totalDuration: '100',
      completionRate: 0.5,
    },
    {
      id: '2',
      name: 'Jane Doe',
      totalDuration: '200',
      completionRate: 0.75,
    },
    {
      id: '3',
      name: 'John Smith',
      totalDuration: '30',
      completionRate: 0.25,
    },
  ]; // these are the visitor objects based on the linkId

  return (
    <>
      {visitors
        ? visitors.map((visitor) => (
            <TableRow key={visitor.id}>
              <TableCell>{visitor.name}</TableCell>
              <TableCell>{visitor.totalDuration}</TableCell>
              <TableCell>
                <Gauge
                  value={visitor.completionRate}
                  size="small"
                  showValue={false}
                />
              </TableCell>
            </TableRow>
          ))
        : null}
    </>
  );
}

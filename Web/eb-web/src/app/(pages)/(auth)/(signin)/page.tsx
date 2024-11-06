import { Metadata } from 'next';
import { metadataLoginPage } from '@/data/MetaDataInfo';
import SignInViewPage from '../_components/sigin-view';

export const metadata: Metadata = metadataLoginPage;

export default function Page() {
  return <SignInViewPage />;
}

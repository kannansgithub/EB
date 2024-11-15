import { HiOutlineExclamationCircle } from 'react-icons/hi';
interface FormErrorProps {
  message: string;
}

const FormError = ({ message }: FormErrorProps) => {
  if (!message) return null;
  return (
    <div className="bg-destructive/15 p-3 rounded-md flex items-center gap-x-2 text-sm text-destructive font-thin">
      <HiOutlineExclamationCircle size={20} />
      <div>{message}</div>
    </div>
  );
};

export default FormError;

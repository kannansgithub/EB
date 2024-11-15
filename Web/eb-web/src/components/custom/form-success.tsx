import { HiOutlineCheckCircle } from 'react-icons/hi';
interface FormSuccessProps {
  message: string;
}

const FormSuccess = ({ message }: FormSuccessProps) => {
  if (!message) return null;
  return (
    <div className="bg-emerald-600/15 p-3 rounded-md flex items-center gap-x-2 text-sm font-thin text-emerald-600">
      <HiOutlineCheckCircle size={20} />
      <div>{message}</div>
    </div>
  );
};

export default FormSuccess;

import { Bounce, toast, ToastOptions } from 'react-toastify';

const tosterOptions: ToastOptions = {
  position: 'bottom-right',
  autoClose: 5000,
  hideProgressBar: false,
  closeOnClick: true,
  pauseOnHover: true,
  draggable: true,
  progress: undefined,
  transition: Bounce,
};

const toasterMessage = {
  success: (message: string) => {
    toast.success(message, tosterOptions);
  },
  error: (message: string) => {
    toast.error(message, tosterOptions);
  },
  warn: (message: string) => {
    toast.warn(message, tosterOptions);
  },
  info: (message: string) => {
    toast.info(message, tosterOptions);
  },
  default: (message: string) => {
    toast(message, tosterOptions);
  },
};

export default toasterMessage;

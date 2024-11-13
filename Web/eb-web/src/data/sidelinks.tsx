export interface NavLink {
  name: string;
  caption: string;
  url: string;
  isAuthorized: boolean;
  index: number;
  parentIndex: number;
  icon: string;
  label: string;
  hasReadAccess: boolean;
  hasWriteAccess: boolean;
  hasUpdateAccess: boolean;
  hasDeleteAccess: boolean;
}

export interface SideLink extends NavLink {
  sub?: NavLink[];
}

// export const sidelinks: SideLink[] = [
//   {
//     title: 'Dashboard',
//     label: '',
//     href: '/',
//     icon: <IconLayoutDashboard size={18} />,
//   },
//   {
//     title: 'Tasks',
//     label: '3',
//     href: '/tasks',
//     icon: <IconChecklist size={18} />,
//   },
//   {
//     title: 'Chats',
//     label: '9',
//     href: '/chats',
//     icon: <IconMessages size={18} />,
//   },
//   {
//     title: 'Apps',
//     label: '',
//     href: '/apps',
//     icon: <IconApps size={18} />,
//   },
//   {
//     title: 'Authentication',
//     label: '',
//     href: '',
//     icon: <IconUserShield size={18} />,
//     sub: [
//       {
//         title: 'Sign In (email + password)',
//         label: '',
//         href: '/sign-in',
//         icon: <IconHexagonNumber1 size={18} />,
//       },
//       {
//         title: 'Sign In (Box)',
//         label: '',
//         href: '/sign-in-2',
//         icon: <IconHexagonNumber2 size={18} />,
//       },
//       {
//         title: 'Sign Up',
//         label: '',
//         href: '/sign-up',
//         icon: <IconHexagonNumber3 size={18} />,
//       },
//       {
//         title: 'Forgot Password',
//         label: '',
//         href: '/forgot-password',
//         icon: <IconHexagonNumber4 size={18} />,
//       },
//       {
//         title: 'OTP',
//         label: '',
//         href: '/otp',
//         icon: <IconHexagonNumber5 size={18} />,
//       },
//     ],
//   },
//   {
//     title: 'Users',
//     label: '',
//     href: '/users',
//     icon: <IconUsers size={18} />,
//   },
//   {
//     title: 'Requests',
//     label: '10',
//     href: '/requests',
//     icon: <IconRouteAltLeft size={18} />,
//     sub: [
//       {
//         title: 'Trucks',
//         label: '9',
//         href: '/trucks',
//         icon: <IconTruck size={18} />,
//       },
//       {
//         title: 'Cargos',
//         label: '',
//         href: '/cargos',
//         icon: <IconBoxSeam size={18} />,
//       },
//     ],
//   },
//   {
//     title: 'Analysis',
//     label: '',
//     href: '/analysis',
//     icon: <IconChartHistogram size={18} />,
//   },
//   {
//     title: 'Extra Components',
//     label: '',
//     href: '/extra-components',
//     icon: <IconComponents size={18} />,
//   },
//   {
//     title: 'Error Pages',
//     label: '',
//     href: '',
//     icon: <IconExclamationCircle size={18} />,
//     sub: [
//       {
//         title: 'Not Found',
//         label: '',
//         href: '/404',
//         icon: <IconError404 size={18} />,
//       },
//       {
//         title: 'Internal Server Error',
//         label: '',
//         href: '/500',
//         icon: <IconServerOff size={18} />,
//       },
//       {
//         title: 'Maintenance Error',
//         label: '',
//         href: '/503',
//         icon: <IconBarrierBlock size={18} />,
//       },
//       {
//         title: 'Unauthorised Error',
//         label: '',
//         href: '/401',
//         icon: <IconLock size={18} />,
//       },
//     ],
//   },
//   {
//     title: 'Settings',
//     label: '',
//     href: '/settings',
//     icon: <IconSettings size={18} />,
//   },
// ];

export const topNavLinks = [
  {
    title: 'Overview',
    href: 'dashboard/overview',
    isActive: true,
  },
  {
    title: 'Customers',
    href: 'dashboard/customers',
    isActive: false,
  },
  {
    title: 'Products',
    href: 'dashboard/products',
    isActive: false,
  },
  {
    title: 'Settings',
    href: 'dashboard/settings',
    isActive: false,
  },
];

export const chartData = [
  {
    name: 'Jan',
    total: Math.floor(Math.random() * 5000) + 1000,
  },
  {
    name: 'Feb',
    total: Math.floor(Math.random() * 5000) + 1000,
  },
  {
    name: 'Mar',
    total: Math.floor(Math.random() * 5000) + 1000,
  },
  {
    name: 'Apr',
    total: Math.floor(Math.random() * 5000) + 1000,
  },
  {
    name: 'May',
    total: Math.floor(Math.random() * 5000) + 1000,
  },
  {
    name: 'Jun',
    total: Math.floor(Math.random() * 5000) + 1000,
  },
  {
    name: 'Jul',
    total: Math.floor(Math.random() * 5000) + 1000,
  },
  {
    name: 'Aug',
    total: Math.floor(Math.random() * 5000) + 1000,
  },
  {
    name: 'Sep',
    total: Math.floor(Math.random() * 5000) + 1000,
  },
  {
    name: 'Oct',
    total: Math.floor(Math.random() * 5000) + 1000,
  },
  {
    name: 'Nov',
    total: Math.floor(Math.random() * 5000) + 1000,
  },
  {
    name: 'Dec',
    total: Math.floor(Math.random() * 5000) + 1000,
  },
];

import 'next-auth';
declare module 'next-auth' {
  interface User {
    accessToken: string;
    refreshToken: string;
    email: string;
    name: string;
    profileChar: string;
    userRoles: string[];
    mainNavigations: Menu[];
  }
  interface Menu {
    name: string;
    caption: string;
    url: string;
    isAuthorized: boolean;
    sub: Menu[];
    index: number;
    parentIndex: number;
    icon: string;
    label: string;
    hasReadAccess: boolean;
    hasWriteAccess: boolean;
    hasUpdateAccess: boolean;
    hasDeleteAccess: boolean;
  }
  interface Session extends DefaultSession {
    user: User;
    expires_in: string;
    error: string;
  }
}

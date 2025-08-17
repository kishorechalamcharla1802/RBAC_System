export interface UserInfo {
  id: number;
  username: string;
  role: string;
}

export interface User extends UserInfo {
  password: string;
}

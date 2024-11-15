export type Todo = {
  id: number;
  name: string;
  done: boolean;
};
export type TodoState = {
  list: Todo[];
  user: string;
};

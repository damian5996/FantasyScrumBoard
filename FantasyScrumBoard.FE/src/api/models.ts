export interface ApiResponse<R> {
  data: R;
  errors: string[];
  hasErrors: boolean;
  success: boolean;
}

export interface WorkItem {
  id: number;
  name: string;
  description: string;
  createdAt: string;
  editedAt: string;
  status: string;
  storyPoints: string;
  projectId: number;
  sprintId: number;
  assignedId: string;
}

export interface User {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  level: number;
  nick: string;
  exp: number;
  createdAt: Date;
  deletedAt?: Date;
}

export interface Sprint {
  id: number;
  startDate: Date;
  estimatedEndDate?: Date;
  projectId: number;
  mvpId: number;
  closedAt: Date;
  createdAt: Date;
  number: number;
}


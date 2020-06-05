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

export interface Project {
  id: number;
  name: string;
  description: string;
  startDate: Date;
  endDate: Date;
  deletedAt: Date;
  createdAt: Date;
  editedAt: Date;
}


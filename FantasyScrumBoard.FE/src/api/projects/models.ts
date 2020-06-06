import { User, Sprint } from 'api';

export interface Project {
  id: number;
  name: string;
  description: string;
  startDate: Date | string;
  endDate: Date | string;
  deletedAt: Date;
  createdAt: Date;
  editedAt: Date;
}

export interface ProjectDetails {
  projectId: number;
  name: string;
  description: string;
  users: User[];
  sprints: Sprint[];
}

import { User, Sprint } from 'api';

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

export interface ProjectDetails {
  projectId: number;
  name: string;
  description: string;
  users: User[];
  sprints: Sprint[];
}
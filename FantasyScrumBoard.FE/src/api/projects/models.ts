export interface Project {
  id: number;
  name: string;
  description: string;
  startDate: string;
  endDate: string;
  createdAt: string;
  deletedAt?: string;
  editedAt?: string;
}
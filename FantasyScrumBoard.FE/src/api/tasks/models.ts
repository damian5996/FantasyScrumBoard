export interface ProjectTask {
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

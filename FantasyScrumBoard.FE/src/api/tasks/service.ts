import { ProjectTask } from '..';

const getItems = (count, offset = 0): ProjectTask[] =>
  Array.from({ length: count }, (v, k) => k).map(k => ({
    id: `item-${k + offset}-${new Date().getTime()}`,
    name: 'Crete account',
    description: 'Lorem ipsumdescription for testin gpurposes',
    createdAt: '19-12-1994',
    editedAt: '',
    status: 'To do',
    storyPoints: 1,
    projectId: 1,
    sprintId: 0,
    assignedId: 1
  })) as any[];

export const getTasks = (): Promise<ProjectTask[][]> => {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve([getItems(10), getItems(5, 10), getItems(5, 20), getItems(5, 30), getItems(5, 40)]);
    }, 1500);
  });
};

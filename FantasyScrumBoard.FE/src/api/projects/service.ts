import { Project } from '.';

export const addProject = (): Promise<Project> => {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve(null);
    }, 1500);
  });
};

export const editProject = (): Promise<Project> => {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve(null);
    }, 1500);
  });
};

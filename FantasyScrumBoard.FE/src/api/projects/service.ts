import { ProjectDetails } from '.';
import { Sprint, User } from 'api';

const createSprint = (id: number): Sprint => {
  return {
    id: id,
    projectId: 0,
    closedAt: new Date(Date.now()),
    createdAt: new Date(Date.now()),
    mvpId: 0,
    number: 1,
    startDate: new Date(Date.now()),
    estimatedEndDate: new Date(Date.now())
  };
};

const createUser = (id: number): User => {
  return {
    id: id,
    createdAt: new Date(Date.now()),
    email: 'email@abrakadabra.pl',
    exp: 1000 * id,
    firstName: 'firstname',
    lastName: 'lastname',
    level: (1000 * id) / 5,
    nick: 'nickkkk',
    deletedAt: null
  };
};

const getProjectDetailsItems = (): ProjectDetails => {
  return {
    description: 'description',
    name: 'name',
    projectId: 1,
    sprints: [createSprint(0), createSprint(1), createSprint(2), createSprint(3)],
    users: [createUser(0), createUser(1), createUser(2), createUser(3)]
  };
};

export const getProjectDetails = (projectId: number): Promise<ProjectDetails> => {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve(getProjectDetailsItems());
    }, 1500);
  });
};

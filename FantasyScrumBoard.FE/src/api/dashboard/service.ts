import { Project } from 'api';

import { News } from '.';

const getProjectItems = (count: number): Project[] => 
  Array.from({ length: count}, (v, k) => k).map(k => ({
    id: k,
    name: 'Name',
    description: 'Description',
    startDate: new Date(Date.now()),
    endDate: new Date(Date.now()),
    deletedAt: new Date(Date.now()),
    createdAt: new Date(Date.now()),
    editedAt: new Date(Date.now())
  })) as any[];

export const getProjects = (): Promise<Project[]> => {
  return new Promise((resolve,  reject) => {
    setTimeout(() => {
      resolve(getProjectItems(10))
    }, 1500);
  });
}

const getNewsItems = (count: number): News[] => 
  Array.from({ length: count}, (v, k) => k).map(k => ({
    id: k,
    date: new Date(Date.now()),
    news: `news ${Date.now()}`,
  })) as any[];

export const getNews = (): Promise<News[]> => {
  return new Promise((resolve,  reject) => {
    setTimeout(() => {
      resolve(getNewsItems(10))
    }, 1500);
  });
}
import { call, Sprint } from '..';
import { coreInstance } from '../config';

export const addSprint = (sprint: {
  startDate: string;
  estimatedEndDate: string;
  project: number;
}) => {
  call<Sprint>(coreInstance.post('Sprint', sprint));
};

export const getSprints = () => call<Sprint[]>(coreInstance.get('Sprint'));

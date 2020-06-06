import { call, coreInstance } from '..';

export const logInFb = (payload: { token: string }) => {
  return call<any>(coreInstance.post('User/login/facebook', payload));
};

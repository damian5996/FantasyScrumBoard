import axios from 'axios';

import { parseError } from '.';

import { API } from 'consts';

axios.defaults.headers.common = {
  Authorization: `Bearer ${
    localStorage.getItem('user') ? JSON.parse(localStorage.getItem('user')).token : 's'
  }`
};

export const coreInstance = axios.create({
  baseURL: API,
  headers: { 'Content-Type': 'application/json' },
  withCredentials: true
});

coreInstance.interceptors.response.use(
  response => response,
  error => parseError(error)
);

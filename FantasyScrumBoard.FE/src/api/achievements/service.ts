import { Achievement } from '.';

const getAchievementsItems = (count: number) =>
  Array.from({ length: count }, (v, k) => k).map((k) => ({
    id: k,
    name: 'achievement' + k,
    description: 'description' + k,
    type: k
  })) as any[];

export const getUserAchievements = (userId: number): Promise<Achievement[]> => {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve(getAchievementsItems(10))
    }, 1500);
  });
};


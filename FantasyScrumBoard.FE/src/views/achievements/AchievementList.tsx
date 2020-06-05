import React, { useState, useEffect } from 'react';

import { Achievement, getUserAchievements } from 'api';

import { AchievementTile, AchievementListProps } from '.';

import csx from './AchievementList.scss';

const AchievementList = ({ match }: AchievementListProps) => {
  const [isLoading, setIsLoading] = useState(true);
  const [achievements, setAchievements] = useState<Achievement[]>([]);

  const handleGetUserAchievements = async (id: number) => {
    if (!isLoading) {
      setIsLoading(true);
    }

    try {
      const achievementList = await getUserAchievements(id);
      setAchievements(achievementList);
      setIsLoading(false);
    } catch (error) {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    handleGetUserAchievements(+match.params.id);
  }, []);

  if (isLoading) return <div>Loading user achievements....</div>;

  return (
    <div className={csx.achievementList}>
      {achievements.map((achievement) => {
        return <AchievementTile key={achievement.id} achievement={achievement} />;
      })}
    </div>
  );
};

export default AchievementList;

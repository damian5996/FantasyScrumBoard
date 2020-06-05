import React from 'react';

import { AchievementTileProps } from '.';

import csx from './AchievementTile.scss';

export const AchievementTile = ({ achievement }: AchievementTileProps) => {
  return (
    <section className={csx.achievementTile}>
      <div>
        {achievement.type}
        {achievement.name}
      </div>
      <p>{achievement.description}</p>
    </section>
  );
};

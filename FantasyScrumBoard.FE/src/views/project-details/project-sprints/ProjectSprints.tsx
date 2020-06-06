import React from 'react';

import { Sprint } from 'api';
import { Button } from 'shared/ui';

import csx from './ProjectSprints.scss';

interface ProjectSprintsProps {
  sprints: Sprint[];
}

export const ProjectSprints = ({ sprints }: ProjectSprintsProps) => {
  return (
    <div className={csx.projectSprints}>
      <Button className={csx.buttonHeader}>SPRINTS</Button>
    </div>
  );
};

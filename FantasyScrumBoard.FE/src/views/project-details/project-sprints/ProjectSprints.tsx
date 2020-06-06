import React from 'react';

import { Sprint } from 'api';
import { Button } from 'shared/ui';

import { ProjectSprintTile } from '.';

import csx from './ProjectSprints.scss';

interface ProjectSprintsProps {
  sprints: Sprint[];
}

export const ProjectSprints = ({ sprints }: ProjectSprintsProps) => {
  return (
    <div className={csx.projectSprints}>
      <Button className={csx.buttonHeader}>SPRINTS</Button>
      <div className={csx.sprints}>
        <ProjectSprintTile name="asd" id={1} />
        <ProjectSprintTile name="asd" id={1} />
        <ProjectSprintTile name="asd" id={1} />
        <ProjectSprintTile name="asd" id={1} />
      </div>
    </div>
  );
};

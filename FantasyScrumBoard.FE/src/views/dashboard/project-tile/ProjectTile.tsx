import React from 'react';

import { IconButton } from '@material-ui/core';

import { BoardIcon, MapIcon } from 'shared/icons';

import csx from './ProjectTile.scss';

interface ProjectTileProps {
  name: string;
  id: number;
}

export const ProjectTile = ({ name, id }: ProjectTileProps) => {
  return (
    <div className={csx.projectTile}>
      <h3>{name}</h3>
      <span>
        <IconButton color="secondary">
          <BoardIcon />
        </IconButton>
        <IconButton color="secondary">
          <MapIcon />
        </IconButton>
      </span>
    </div>
  );
};

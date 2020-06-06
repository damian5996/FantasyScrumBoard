import React from 'react';

import { IconButton } from '@material-ui/core';

import { BoardIcon, MapIcon } from 'shared/icons';

import AddIcon from '@material-ui/icons/Add';

import csx from './ProjectTile.scss';

interface ProjectTileProps {
  name?: string;
  id?: number;
  addNew?: boolean;
}

export const ProjectTile = ({ name, id, addNew }: ProjectTileProps) => {
  if (addNew)
    return (
      <div className={csx.addNew}>
          <IconButton>
            <AddIcon fontSize="large"/>
          </IconButton>
      </div>
    );

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

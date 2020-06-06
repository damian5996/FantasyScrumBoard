import React from 'react';
import { Link } from 'react-router-dom';

import EditIcon from '@material-ui/icons/Edit';

import { IconButton } from '@material-ui/core';

import { BoardIcon, MapIcon } from 'shared/icons';



import csx from './ProjectTile.scss';

interface ProjectTileProps {
  name: string;
  id: number;
  onEdit(id: number): void;
}

export const ProjectTile = ({ name, id, onEdit }: ProjectTileProps) => {
  return (
    <div className={csx.projectTile}>
      <h3>{name}</h3>

      <span>
        <Link to={`project/${id}/board`}>
          <IconButton color="secondary">
            <BoardIcon />
          </IconButton>
        </Link>
        <IconButton style={{ color: 'white' }} onClick={() => onEdit(id)}>
          <EditIcon />
        </IconButton>
        <IconButton color="secondary">
          <MapIcon />
        </IconButton>
      </span>
    </div>
  );
};

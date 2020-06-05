import React from 'react';
import { Link } from 'react-router-dom';

import EditIcon from '@material-ui/icons/Edit';

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

      <EditIcon onClick={() => onEdit(id)} />

      <span>
        <Link to={`project/${id}/board`}>BOARD</Link>
        <button>MAP</button>
      </span>
    </div>
  );
};

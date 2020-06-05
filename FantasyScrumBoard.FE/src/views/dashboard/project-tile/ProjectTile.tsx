import React from 'react';

import csx from './ProjectTile.scss';

interface ProjectTileProps {
  name: string;
  id: number;
}

export const ProjectTile = ({name, id}: ProjectTileProps) => {
  return (
    <div className={csx.projectTile}>
      <h3>{name}</h3>
      <span>
        <button>BOARD</button>
        <button>MAP</button>
      </span>
    </div>
  );
};

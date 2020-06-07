import React, { useState } from 'react';

import { IconButton, Tooltip, Menu, MenuItem } from '@material-ui/core';

import { BoardIcon, MapIcon } from 'shared/icons';

import MoreVertIcon from '@material-ui/icons/MoreVert';
import DeleteIcon from '@material-ui/icons/Delete';

import csx from './ProjectSprintTile.scss';

interface ProjectSprintTileProps {
  name: string;
  id: number;
  projectId: number;
}

export const ProjectSprintTile = ({ name, id, projectId }: ProjectSprintTileProps) => {
  const [anchorEl, setAnchorEl] = useState(null);

  const handleClick = event => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const handleEdit = (id: number) => {
    handleClose();
  };

  return (
    <div className={csx.projectTile}>
      <IconButton
        style={{ color: 'white', position: 'absolute', right: '0' }}
        onClick={handleClick}
      >
        <MoreVertIcon />
      </IconButton>
      <h3>{name}</h3>
      <div style={{ backgroundColor: 'white' }}>
        <span>
          <a href={`${window.location.origin}/project/${projectId}/${id}/board`}>
            <Tooltip title="Go to board view">
              <IconButton color="secondary">
                <BoardIcon />
              </IconButton>
            </Tooltip>
          </a>
          <Tooltip title="Go to map view">
            <IconButton color="secondary">
              <MapIcon />
            </IconButton>
          </Tooltip>
        </span>
      </div>
      <Menu
        id="simple-menu"
        anchorEl={anchorEl}
        keepMounted
        open={Boolean(anchorEl)}
        onClose={handleClose}
      >
        <MenuItem onClick={handleClose}>
          <DeleteIcon style={{ marginRight: '10px' }} /> Delete project
        </MenuItem>
      </Menu>
    </div>
  );
};

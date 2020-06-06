import React, { useState } from 'react';
import { Link } from 'react-router-dom';

import { IconButton, Tooltip, Menu, MenuItem } from '@material-ui/core';

import EditIcon from '@material-ui/icons/Edit';
import MoreVertIcon from '@material-ui/icons/MoreVert';
import DeleteIcon from '@material-ui/icons/Delete';

import { BoardIcon, MapIcon } from 'shared/icons';

import csx from './ProjectTile.scss';
import { Button } from 'shared/ui';

interface ProjectTileProps {
  name: string;
  id: number;
  onEdit(id: number): void;
}

export const ProjectTile = ({ name, id, onEdit }: ProjectTileProps) => {
  const [anchorEl, setAnchorEl] = useState(null);

  const handleClick = event => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const handleEdit = (id: number) => {
    handleClose();
    onEdit(id);
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
          <a href={`${window.location.origin}/main/project/${id}/details`}>DETAILS</a>
        </span>
      </div>
      <Menu
        id="simple-menu"
        anchorEl={anchorEl}
        keepMounted
        open={Boolean(anchorEl)}
        onClose={handleClose}
      >
        <MenuItem onClick={() => handleEdit(id)}>
          <EditIcon style={{ marginRight: '10px' }} /> Edit project
        </MenuItem>
        <MenuItem onClick={handleClose}>
          <DeleteIcon style={{ marginRight: '10px' }} /> Delete project
        </MenuItem>
      </Menu>
    </div>
  );
};

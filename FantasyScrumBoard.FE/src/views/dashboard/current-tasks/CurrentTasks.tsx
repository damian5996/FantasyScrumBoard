import React from 'react';

import {
  TableContainer,
  Table,
  Paper,
  TableHead,
  TableRow,
  TableCell,
  TableBody
} from '@material-ui/core';

import { CurrentTasksProps } from '.';

import csx from './CurrentTasks.scss';

export const CurrentTasks = ({workItems}: CurrentTasksProps) => {
  return (
    <TableContainer>
      <Table className={csx.table}>
        <TableHead>
          <TableRow>
            <TableCell>Project Name</TableCell>
            <TableCell>Task description</TableCell>
            <TableCell>User</TableCell>
            <TableCell>Points</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
        {workItems.map((row, idx) => (
            <TableRow key={idx}>
              <TableCell>
                {row.projectId}
              </TableCell>
              <TableCell>{row.description}</TableCell>
              <TableCell>{row.assignedId}</TableCell>
              <TableCell>{row.storyPoints}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

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

export const CurrentTasks = ({workItems}: CurrentTasksProps) => {
  return (
    <TableContainer component={Paper}>
      <Table>
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
              <TableCell component="th" scope="row">
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

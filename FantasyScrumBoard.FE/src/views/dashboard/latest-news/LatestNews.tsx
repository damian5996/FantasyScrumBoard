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

import { LatestNewsProps } from '.';

export const LatestNews = ({news}: LatestNewsProps) => {
  return (
    <TableContainer component={Paper}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Date</TableCell>
            <TableCell>News</TableCell>
            <TableCell></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {news.map((row, idx) => (
            <TableRow key={idx}>
              <TableCell component="th" scope="row">
                {row.date.toISOString()}
              </TableCell>
              <TableCell>{row.news}</TableCell>
              <TableCell>
                <button>show on map</button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

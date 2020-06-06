import React from 'react';

import {
  TableContainer,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Button
} from '@material-ui/core';

import { LatestNewsProps } from '.';

import csx from './LatestNews.scss';

export const LatestNews = ({news}: LatestNewsProps) => {
  return (
    <TableContainer>
      <Table className={csx.table}>
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
                <Button className={csx.button}>Show on map</Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

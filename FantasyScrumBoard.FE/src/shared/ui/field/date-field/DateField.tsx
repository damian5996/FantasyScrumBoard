import React, { useState, useCallback } from 'react';

import CalendarIcon from '@material-ui/icons/CalendarToday';
import { IconButton } from '@material-ui/core';

import { DateFieldProps, FieldBase, DatePicker, PickerDate } from '..';

import csx from './DateField.scss';

export const DateField = ({ label, error, onSelect, ...inputProps }: DateFieldProps) => {
  const [isPickerOpen, setIsPickerOpen] = useState(false);

  const togglePicker = useCallback(() => {
    setIsPickerOpen(!isPickerOpen);
  }, [isPickerOpen]);

  const handleSelect = useCallback(({ day, month, year }: PickerDate) => {
    onSelect(`${day >= 10 ? day : `0${day}`}/${month >= 10 ? month : `0${month}`}/${year}`);
  }, []);

  return (
    <>
      {isPickerOpen && (
        <DatePicker value={inputProps.value} onSave={handleSelect} onClose={togglePicker} />
      )}
      <FieldBase label={label} error={error} className={csx.dateField}>
        <input {...inputProps} placeholder="DD/MM/YYYY" />
        <IconButton className={csx.expandBtn} onClick={togglePicker}>
          <CalendarIcon />
        </IconButton>
      </FieldBase>
    </>
  );
};

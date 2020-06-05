import React, { useState, useCallback } from 'react';

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
          <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
            <path
              fill="#D30000"
              fill-rule="evenodd"
              d="M16.562 0c.428 0 .782.315.839.724l.007.113.001.947c3.474.234 5.602 2.439 5.591 5.999v10.186C23 21.743 20.61 24 16.771 24H7.23C3.394 24 1 21.705 1 17.885V7.783c0-3.559 2.134-5.765 5.602-6V.838c0-.462.379-.837.846-.837.429 0 .783.315.839.724l.007.113v.925h7.421V.837c0-.462.38-.837.847-.837zm4.745 9.939H2.692v7.946c0 2.8 1.533 4.35 4.29 4.437l.247.004h9.542c2.922 0 4.537-1.525 4.537-4.357l-.001-8.03zm-4.285 7.024c.467 0 .846.375.846.837 0 .424-.318.775-.731.83l-.115.008c-.478 0-.857-.375-.857-.838 0-.423.319-.774.732-.83l.125-.007zm-5.006 0c.467 0 .846.375.846.837 0 .424-.319.775-.732.83l-.114.008c-.478 0-.857-.375-.857-.838 0-.423.318-.774.731-.83l.126-.007zm-5.017 0c.467 0 .846.375.846.837 0 .424-.318.775-.731.83l-.126.008c-.467 0-.846-.375-.846-.838 0-.423.319-.774.732-.83l.125-.007zm10.023-4.338c.467 0 .846.375.846.837 0 .424-.318.774-.731.83l-.115.007c-.478 0-.857-.375-.857-.837 0-.424.319-.774.732-.83l.125-.007zm-5.006 0c.467 0 .846.375.846.837 0 .424-.319.774-.732.83l-.114.007c-.478 0-.857-.375-.857-.837 0-.424.318-.774.731-.83l.126-.007zm-5.017 0c.467 0 .846.375.846.837 0 .424-.318.774-.731.83l-.126.007c-.467 0-.846-.375-.846-.837 0-.424.319-.774.732-.83l.125-.007zm8.716-9.188H8.294v1.074c0 .462-.378.837-.846.837-.428 0-.782-.315-.838-.724l-.008-.113V3.462c-2.523.208-3.91 1.706-3.91 4.32v.483h18.615V7.78c.009-2.616-1.37-4.111-3.898-4.318v1.049c0 .462-.38.837-.847.837-.428 0-.782-.315-.838-.724l-.008-.113-.001-1.074z"
            />
          </svg>
        </IconButton>
      </FieldBase>
    </>
  );
};

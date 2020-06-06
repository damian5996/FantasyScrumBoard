import React, { useState } from 'react';

import { addSprint, Sprint } from 'api';

import { useForm, FormConfig, date } from 'shared/forms';

import { Modal, Button, DateField, Alert } from 'shared/ui';

import csx from './SprintForm.scss';

interface SprintFormProps {
  projectId: number;
  data: Sprint | null;
  onAdd(sprint: Sprint): void;
  onEdit(sprint: Sprint): void;
  onClose(): void;
}

const config: FormConfig = [
  { label: 'Start date', validators: [date] },
  { label: 'Estimated end date', validators: [date] }
];

const getConfig = (data: Sprint | null) => {
  if (data) {
    const values = [data.startDate, data.estimatedEndDate];

    return config.map((c, idx) => ({ ...c, value: values[idx] }));
  }

  return config;
};

const SprintForm = ({ data, onAdd, onEdit, onClose, projectId }: SprintFormProps) => {
  const [alertData, setAlertData] = useState(null);
  const [isPending, setIsPending] = useState(false);

  const [{ fields, isDirty, isInvalid }, change, directChange, submit] = useForm(getConfig(data));

  const handleSubmit = async e => {
    if (submit(e)) {
      return;
    }

    if (!isPending) {
      setIsPending(true);
    }

    try {
      const [{ value: startDate }, { value: estimatedEndDate }] = fields;

      const parsedStartDate = startDate
        .split('/')
        .reverse()
        .join('/');

      const parsedEndDate = estimatedEndDate
        .split('/')
        .reverse()
        .join('/');

      const sprint = await addSprint({
        startDate: new Date(parsedStartDate).toJSON(),
        estimatedEndDate: new Date(parsedEndDate).toJSON(),
        project: projectId
      });

      onAdd(sprint as any);
    } catch (message) {
      setIsPending(false);
      setAlertData({
        message: 'Error while adding new project',
        type: 'error'
      });
    }
  };

  return (
    <>
      {alertData && <Alert {...alertData} onClose={() => setAlertData(null)} />}

      <Modal onClose={onClose} isLoading={isPending}>
        <form className={csx.sprintForm} onSubmit={handleSubmit}>
          <p>Add new sprint</p>

          <div className={csx.formField}>
            <DateField
              data-idx={0}
              label="Start date *"
              error={isDirty ? fields[0].error : ''}
              value={fields[0].value}
              onChange={change}
              onSelect={value => {
                directChange([0], [value]);
              }}
            />
          </div>

          <div className={csx.formField}>
            <DateField
              data-idx={1}
              label="Estimated end date *"
              error={isDirty ? fields[1].error : ''}
              value={fields[1].value}
              onChange={change}
              onSelect={value => {
                directChange([1], [value]);
              }}
            />
          </div>

          <Button type="submit" disabled={isPending || (isDirty && isInvalid)}>
            CREATE
          </Button>
        </form>
      </Modal>
    </>
  );
};

export default SprintForm;

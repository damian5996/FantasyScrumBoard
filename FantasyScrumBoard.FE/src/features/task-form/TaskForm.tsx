import React, { useState } from 'react';

import { WorkItem } from 'api';

import { useForm, FormConfig, req, min, max, date, nmb } from 'shared/forms';

import { Modal, Field, TextareaField, Button, DateField, Select } from 'shared/ui';

import csx from './TaskForm.scss';

const taskStatusesLabels = ['To do', 'In progress', 'Code review', 'Testing', 'Done'];

interface TaskFormProps {
  data: WorkItem | null;
  onClose(): void;
}

const config: FormConfig = [
  { label: 'Name', validators: [req, min(2), max(100)] },
  { label: 'Description', validators: [min(2), max(1000)] },
  {
    label: 'Status',
    value: [
      { id: 0, label: 'To do', value: false },
      { id: 1, label: 'In progress', value: false },
      { id: 2, label: 'Code review', value: false },
      { id: 3, label: 'Testing', value: false },
      { id: 4, label: 'Done', value: false }
    ]
  },
  { label: 'Story points', validators: [req, nmb] }
];

const getConfig = (data: WorkItem | null) => {
  if (data) {
    const values = [data.name, data.description, config[2].value, data.storyPoints];

    return config.map((c, idx) => ({ ...c, value: values[idx] }));
  }

  return config;
};

const TaskForm = ({ onClose, data }: TaskFormProps) => {
  const [isPending, setIsPending] = useState(false);

  const [{ fields, isDirty, isInvalid }, change, directChange, submit] = useForm(getConfig(data));

  const updateStatus = (e: React.ChangeEvent<HTMLInputElement>, idx: number, value?: boolean) => {
    const id = +e.currentTarget.getAttribute('data-id');
    const items = fields[idx].value.map(item =>
      id === item.id
        ? {
            ...item,
            value: value === undefined ? false : value
          }
        : { ...item, value: false }
    );
    directChange([idx], [items]);
  };

  const handleSubmit = async e => {
    if (submit(e)) {
      return;
    }

    if (!isPending) {
      setIsPending(true);
    }

    try {
      // await addProject();

      setIsPending(false);
    } catch (err) {
      setIsPending(false);
    }
  };

  return (
    <Modal onClose={onClose}>
      <form className={csx.taskForm} onSubmit={handleSubmit}>
        <p>Add new task</p>

        <Field
          data-idx={0}
          className={csx.formField}
          label="Project name *"
          placeholder="Type your project name.."
          error={isDirty ? fields[0].error : ''}
          value={fields[0].value}
          onChange={change}
        />

        <TextareaField
          data-idx={1}
          className={csx.formField}
          onChange={change}
          value={fields[1].value}
          error={isDirty ? fields[1].error : ''}
          placeholder="Add description..."
          label="Description *"
        />

        <div className={csx.formField}>
          <Select
            label="Status *"
            placeholder="Select your template status..."
            items={fields[2].value}
            error={isDirty ? fields[2].error : ''}
            onSelect={(e, value) => {
              updateStatus(e, 2, value);
            }}
          />
        </div>

        <div className={csx.formField}>
          <Field
            data-idx={3}
            className={csx.formField}
            label="Story points *"
            placeholder="Type your story points..."
            error={isDirty ? fields[3].error : ''}
            value={fields[3].value}
            onChange={change}
          />
        </div>

        <Button type="submit" disabled={isPending || (isDirty && isInvalid)}>
          CREATE
        </Button>
      </form>
    </Modal>
  );
};

export default TaskForm;

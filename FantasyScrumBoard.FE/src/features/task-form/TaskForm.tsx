import React, { useState } from 'react';

import { WorkItem, addWorkItem } from 'api';

import { useForm, FormConfig, req, min, max, nmb } from 'shared/forms';

import { Modal, Field, TextareaField, Button } from 'shared/ui';

import csx from './TaskForm.scss';

interface TaskFormProps {
  sprintId: number;
  projectId: number;
  data: WorkItem | null;
  onClose(): void;
}

const config: FormConfig = [
  { label: 'Name', validators: [req, min(2), max(100)] },
  { label: 'Description', validators: [min(2), max(1000)] },
  { label: 'Story points', validators: [req, nmb] }
];

const getConfig = (data: WorkItem | null) => {
  if (data) {
    const values = [data.name, data.description, config[2].value, data.storyPoints];

    return config.map((c, idx) => ({ ...c, value: values[idx] }));
  }

  return config;
};

const TaskForm = ({ onClose, data, sprintId, projectId }: TaskFormProps) => {
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
      const [{ value: name }, { value: description }, { value: storyPoints }] = fields;

      await addWorkItem({
        name,
        description,
        storyPoints: +storyPoints,
        project: projectId,
        sprint: sprintId
      });

      setIsPending(false);
    } catch (err) {
      setIsPending(false);
    }
  };

  return (
    <Modal onClose={onClose} isLoading={isPending}>
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
          <Field
            data-idx={2}
            className={csx.formField}
            label="Story points *"
            placeholder="Type your story points..."
            error={isDirty ? fields[2].error : ''}
            value={fields[2].value}
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

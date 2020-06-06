import React, { useState } from 'react';

import { addProject, editProject, Project } from 'api';

import { useForm, FormConfig, req, min, max, date } from 'shared/forms';

import { Modal, Field, TextareaField, Button, DateField, Alert } from 'shared/ui';

import csx from './ProjectForm.scss';

interface ProjectFormProps {
  data: Project | null;
  onAdd(project: Project): void;
  onEdit(project: Project): void;
  onClose(): void;
}

const config: FormConfig = [
  { label: 'Name', validators: [req, min(2), max(100)] },
  { label: 'Description', validators: [min(2), max(1000)] },
  { label: 'Start date', validators: [date] }
];

const getConfig = (data: Project | null) => {
  if (data) {
    const values = [data.name, data.description, data.startDate];

    return config.map((c, idx) => ({ ...c, value: values[idx] }));
  }

  return config;
};

const ProjectForm = ({ data, onAdd, onEdit, onClose }: ProjectFormProps) => {
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
      const [{ value: name }, { value: description }, { value: startDate }] = fields;

      const parsedStartDate = startDate
        .split('/')
        .reverse()
        .join('/');

      const project = await addProject({
        name,
        description,
        startDate: new Date(startDate).toJSON()
      });
      onAdd(project);
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
        <form className={csx.projectForm} onSubmit={handleSubmit}>
          <p>Add new project</p>

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
            <DateField
              data-idx={2}
              label="Start date *"
              error={isDirty ? fields[2].error : ''}
              value={fields[2].value}
              onChange={change}
              onSelect={value => {
                directChange([2], [value]);
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

export default ProjectForm;

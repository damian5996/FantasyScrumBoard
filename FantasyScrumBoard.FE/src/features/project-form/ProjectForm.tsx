import React, { useState } from 'react';

import { addProject, editProject } from 'api';

import { useForm, FormConfig, req, min, max, date } from 'shared/forms';

import { Modal, Field, TextareaField, Button, DateField } from 'shared/ui';

import csx from './ProjectForm.scss';

const config: FormConfig = [
  { label: 'Name', validators: [req, min(2), max(100)] },
  { label: 'Description', validators: [min(2), max(1000)] },
  { label: 'Start date', validators: [date] },
  { label: 'End date', validators: [date] }
];

const ProjectForm = () => {
  const [isPending, setIsPending] = useState(false);

  const [{ fields, isDirty, isInvalid }, change, directChange, submit] = useForm(config);

  const handleSubmit = async e => {
    if (submit(e)) {
      return;
    }

    if (!isPending) {
      setIsPending(true);
    }

    try {
      await addProject();

      setIsPending(false);
    } catch (err) {
      setIsPending(false);
    }
  };

  return (
    <Modal>
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
            onSelect={value => directChange([2], [value])}
          />
        </div>

        <div className={csx.formField}>
          <DateField
            data-idx={3}
            label="End date *"
            error={isDirty ? fields[3].error : ''}
            value={fields[3].value}
            onChange={change}
            onSelect={value => directChange([3], [value])}
          />
        </div>

        <Button type="submit" disabled={isPending || (isDirty && isInvalid)}>
          CREATE
        </Button>
      </form>
    </Modal>
  );
};

export default ProjectForm;

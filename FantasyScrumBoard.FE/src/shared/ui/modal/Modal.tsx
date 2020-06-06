import React from 'react';

import CloseIcon from '@material-ui/icons/Close';

import { usePortal } from 'shared/utils';

import { Button } from 'shared/ui';

import csx from './Modal.scss';
import { CircularProgress } from '@material-ui/core';

interface ModalProps {
  children: React.ReactNode;
  isLoading?: boolean;
  onClose(): void;
}

export const Modal = ({ children, isLoading, onClose }: ModalProps) => {
  const render = usePortal();

  return render(
    <div className={csx.modal} onClick={close}>
      <Button variant="icon" onClick={onClose}>
        <CloseIcon />
      </Button>

      <div className={csx.content}>
        {isLoading && (
          <div className={csx.loader}>
            <CircularProgress color="secondary" />
          </div>
        )}
        {children}
      </div>
    </div>
  );
};

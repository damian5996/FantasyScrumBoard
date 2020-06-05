import React from 'react';

import CloseIcon from '@material-ui/icons/Close';

import { usePortal } from 'shared/utils';

import { Button } from 'shared/ui';

import csx from './Modal.scss';

interface ModalProps {
  children: React.ReactNode;
  onClose(): void;
}

export const Modal = ({ children, onClose }: ModalProps) => {
  const render = usePortal();

  return render(
    <div className={csx.modal} onClick={close}>
      <Button variant="icon" onClick={onClose}>
        <CloseIcon />
      </Button>
      {children}
    </div>
  );
};

import React from 'react';

import { usePortal } from 'shared/utils';

import csx from './Modal.scss';

interface ModalProps {
  children: React.ReactNode;
}

export const Modal = ({ children }: ModalProps) => {
  const render = usePortal();

  return render(<div className={csx.modal}>{children}</div>);
};

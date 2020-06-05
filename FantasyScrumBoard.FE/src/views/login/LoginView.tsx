import React, { useState } from 'react';
import FacebookLogin from 'react-facebook-login';

import { FB_APP_ID } from 'consts';

import csx from './LoginView.scss';

const LoginView = () => {
  const [isPending, setIsPending] = useState(false);

  const onFbLoginClick = () => {
    setIsPending(true);
  };

  const onFbResponse = r => {
    setIsPending(false);
  };

  return (
    <div className={csx.loginView}>
      <FacebookLogin
        autoLoad
        appId={FB_APP_ID}
        fields="name,email,picture"
        onClick={onFbLoginClick}
        callback={onFbResponse}
      />
    </div>
  );
};

export default LoginView;

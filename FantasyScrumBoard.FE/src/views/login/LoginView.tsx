import React, { useState } from 'react';
import FacebookLogin from 'react-facebook-login';

import { FB_APP_ID } from 'consts';

import { Field, Button } from 'shared/ui';

import { FormConfig, min, req, max, email, useForm } from 'shared/forms';

import csx from './LoginView.scss';

const config: FormConfig = [
  { label: 'Email', validators: [req, email] },
  { label: 'Password', validators: [req, min(8), max(20)] }
];

const LoginView = () => {
  const [isPending, setIsPending] = useState(false);

  const [{ fields, isDirty, isInvalid }, change, directChange, submit] = useForm(config);

  const onFbLoginClick = () => {
    setIsPending(true);
  };

  const onFbResponse = r => {
    console.log(r);
    setIsPending(false);
  };

  const onFbFailure = e => {
    console.log(e);
  };

  return (
    <div className={csx.loginView}>
      <form className={csx.loginForm}>
        <p>Login with email</p>

        <Field
          data-idx={0}
          className={csx.formField}
          label="Email adress *"
          placeholder="Type your email adress.."
          error={isDirty ? fields[0].error : ''}
          value={fields[0].value}
          onChange={change}
        />

        <Field
          data-idx={1}
          className={csx.formField}
          label="Password *"
          placeholder="Type password.."
          error={isDirty ? fields[1].error : ''}
          value={fields[1].value}
          onChange={change}
        />

        <Button type="submit" disabled={isPending || (isDirty && isInvalid)}>
          Login
        </Button>

        <span>Login with</span>

        <FacebookLogin
          autoLoad
          appId={FB_APP_ID}
          fields="name,email,picture"
          onClick={onFbLoginClick}
          callback={onFbResponse}
          onFailure={onFbFailure}
          textButton="Facebook"
          icon={
            <svg xmlns="http://www.w3.org/2000/svg" width="25" height="24" viewBox="0 0 25 24">
              <path
                fill="#FBFBFB"
                d="M16.244 3.819c-1.481 0-1.91.658-1.91 2.107V8.33h3.951l-.395 3.885h-3.555V24H9.594V12.214H6.401V8.329h3.193V5.992C9.594 2.074 11.174 0 15.586 0c.955 0 2.074.066 2.765.165v3.654h-2.107"
              />
            </svg>
          }
        />

        <Button type="button" disabled={isPending}>
          <svg xmlns="http://www.w3.org/2000/svg" width="25" height="24" viewBox="0 0 25 24">
            <path
              fill="#FBFBFB"
              d="M12.4 24c-6.6 0-12-5.37-12-12s5.37-12 12-12c3.052 0 5.84 1.086 8.04 3.14l.205.175-3.609 3.463-.176-.147C16.01 5.839 14.572 4.9 12.4 4.9c-3.843 0-6.982 3.198-6.982 7.1 0 3.902 3.14 7.1 6.983 7.1 4.02 0 5.75-2.552 6.22-4.283h-6.484v-4.548h11.589l.03.205c.116.616.146 1.174.146 1.79C23.902 19.16 19.178 24 12.4 24z"
            />
          </svg>
          Google
        </Button>
      </form>

      <div className={csx.text}>
        <h1>WELCOME</h1>
        <p>to FantasyScrumbBoard</p>

        <span className={csx.title}>Every project can be an adventure</span>
        <span className={csx.description}>(and we know it is true)</span>

        <span className={csx.title}>Every task can be a challange</span>
        <span className={csx.description}>(oh, yes... they can!)</span>

        <span className={csx.title}>Every success should be rewarded</span>
        <span className={csx.description}>(why not? we work so hard after all :D)</span>

        <span className={csx.title}>
          Start they journey, take on the challanges, get rewards you dream of (story points).
        </span>
      </div>
    </div>
  );
};

export default LoginView;

import React from 'react';
import { withRouter } from 'react-router';
import { ReactFacebookLoginInfo } from 'react-facebook-login';

import { INIT_STATE, AuthProviderState, AuthProviderProps, AuthContext } from '.';
import { logInFb } from 'api';

class AuthProvider extends React.Component<AuthProviderProps, AuthProviderState> {
  init = () => {
    const { isPending } = this.state;

    if (!isPending) {
      this.setState({ ...INIT_STATE, isPending: true });
    }
  };

  logIn = async (data: ReactFacebookLoginInfo) => {
    try {
      const user = await logInFb({ token: data.accessToken });

      this.setState({ ...INIT_STATE, isAuthorized: true, user }, () => {
        localStorage.setItem('user', JSON.stringify(user));
        this.props.history.push('/dashboard');
      });
    } catch {
      this.setState({ ...INIT_STATE });
    }
  };

  isAuthorized = () => {
    const user = localStorage.getItem('user');
    return !!user;
  };

  readonly state: AuthProviderState = {
    ...INIT_STATE,
    isAuthorized: this.isAuthorized(),
    logIn: this.logIn,
    init: this.init
  };

  render() {
    return <AuthContext.Provider value={this.state}>{this.props.children}</AuthContext.Provider>;
  }
}

export default withRouter(AuthProvider);

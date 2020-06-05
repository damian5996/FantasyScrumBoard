import React from 'react';
import { withRouter } from 'react-router';

import { INIT_STATE, AuthProviderState, AuthProviderProps, AuthContext } from '.';

class AuthProvider extends React.Component<AuthProviderProps, AuthProviderState> {
  componentDidMount() {}

  // authorize = async () => {
  //   const { isPending } = this.state;

  //   if (!isPending) {
  //     this.setState({ ...INIT_STATE, isPending: true });
  //   }

  //   try {
  //     const user = await getAuthorizedUser();
  //     this.setState({ ...INIT_STATE, isAuthorized: true, user });
  //   } catch {
  //     this.setState({ ...INIT_STATE });
  //   }
  // };

  // logIn = async (credentials: LogInPayload) => {
  //   const { isPending } = this.state;

  //   if (!isPending) {
  //     this.setState({ ...INIT_STATE, isPending: true });
  //   }

  //   try {
  //     const user = await logIn(credentials);
  //     this.setState({ ...INIT_STATE, isAuthorized: true, user }, () => {
  //       this.props.history.replace('/app');
  //     });
  //   } catch (error) {
  //     this.setState({ ...INIT_STATE, error });
  //   }
  // };

  // logOut = async () => {
  //   try {
  //     await logOut();
  //     this.setState({ ...INIT_STATE });
  //   } catch (error) {
  //     this.setState({ error });
  //   }
  // };

  readonly state: AuthProviderState = {
    ...INIT_STATE
  };

  render() {
    return <AuthContext.Provider value={this.state}>{this.props.children}</AuthContext.Provider>;
  }
}

export default withRouter(AuthProvider);

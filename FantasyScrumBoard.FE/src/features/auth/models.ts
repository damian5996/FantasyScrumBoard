import { RouteProps, RouteComponentProps } from 'react-router';

export interface AuthUser {

}

export interface AuthProviderProps extends RouteComponentProps {
  children: React.ReactNode;
}

export interface AuthProviderState {
  isPending: boolean;
  isAuthorized: boolean;
  error: string;
  user: AuthUser;
}

export interface GuardInjectedState extends Omit<AuthProviderState, 'isAuthorized' | 'isPending'> {}

export type RenderGuardChildren = (injectedState: GuardInjectedState | null) => JSX.Element;

export interface GuardProps {
  children: JSX.Element | RenderGuardChildren;
}

export interface RouteGuardProps extends Omit<RouteProps, 'render'> {
  component: React.ComponentType;
  redirect: string;
}

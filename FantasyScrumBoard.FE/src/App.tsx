import React from 'react';
import { Switch, Route } from 'react-router';
import { BrowserRouter } from 'react-router-dom';

import { UnprotectedRoute, ProtectedRoute } from 'features/auth';

import { withLazy } from 'shared/utils';
import ProjectForm from 'features/project-form';

const LoginView = withLazy(() => import('views/login'));
const ProjectBoardView = withLazy(() => import('views/project-board'));
const GraphView = withLazy(() => import('views/graph'));
const DashboardView = withLazy(() => import('views/dashboard'));

const App = () => {
  return (
    <BrowserRouter>
      <Switch>
        <Route
          exact
          path="/"
          render={() => {
            return <div>Helo world</div>;
          }}
        />

        <ProtectedRoute exact path="/dashboard" redirect="/login" component={DashboardView} />

        <UnprotectedRoute exact path="/login" redirect="/" component={LoginView} />

        <ProtectedRoute
          exact
          path="/project/:id/board"
          redirect="/login"
          component={ProjectBoardView}
        />

        <ProtectedRoute exact path="/graph" redirect="/login" component={GraphView} />

        <Route path="**" render={() => <div>Not Found Page </div>} />

      </Switch>
      {/* <ProjectForm /> */}

    </BrowserRouter>
  );
};

export default App;

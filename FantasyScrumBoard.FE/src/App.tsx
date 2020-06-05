import React from 'react';
import { Switch, Route } from 'react-router';
import { BrowserRouter } from 'react-router-dom';

import { UnprotectedRoute, ProtectedRoute } from 'features/auth';
import ProjectForm from 'features/project-form';

import { withLazy } from 'shared/utils';

const LoginView = withLazy(() => import('views/login'));
const ProjectBoardView = withLazy(() => import('views/project-board'));
const ProjectDetailsView = withLazy(() => import('views/project-details'));
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

        <Route
        exact
        path="/dashboard"
        component={DashboardView}
        />

        <UnprotectedRoute exact path="/login" redirect="/" component={LoginView} />

        <ProtectedRoute
          exact
          path="/project/:id/board"
          redirect="/login"
          component={ProjectBoardView}
        />

        <Route
        exact
        path="/project/:id/details"
        component={ProjectDetailsView}
        />

        <ProtectedRoute exact path="/graph" redirect="/login" component={GraphView} />

        <Route path="**" render={() => <div>Not Found Page </div>} />
      </Switch>

      {/* <ProjectForm /> */}
    </BrowserRouter>
  );
};

export default App;

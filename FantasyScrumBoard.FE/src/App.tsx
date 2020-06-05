import React from 'react';
import { Switch, Route } from 'react-router';
import { BrowserRouter } from 'react-router-dom';

import { UnprotectedRoute, ProtectedRoute } from 'features/auth';

import { withLazy } from 'shared/utils';
import ProjectForm from 'features/project-form';

const LoginView = withLazy(() => import('views/login'));
const ProjectBoardView = withLazy(() => import('views/project-board'));
const ProjectDetailsView = withLazy(() => import('views/project-details'));
const GraphView = withLazy(() => import('views/graph'));
const DashboardView = withLazy(() => import('views/dashboard'));
const AchievementListView = withLazy(() => import('views/achievements'));

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

        <UnprotectedRoute exact path="/dashboard" redirect="/login" component={DashboardView} />

        <UnprotectedRoute exact path="/login" redirect="/" component={LoginView} />

        <Route exact path="/user/:id/achievement" component={AchievementListView} />

        <UnprotectedRoute
          exact
          path="/project/:id/board"
          redirect="/login"
          component={ProjectBoardView}
        />

        <Route exact path="/project/:id/details" component={ProjectDetailsView} />

        <UnprotectedRoute exact path="/graph" redirect="/login" component={GraphView} />

        <Route path="**" render={() => <div>Not Found Page </div>} />
      </Switch>
      {/* <ProjectForm /> */}
    </BrowserRouter>
  );
};

export default App;

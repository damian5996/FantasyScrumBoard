import React from 'react';
import { Switch, Route } from 'react-router';
import { BrowserRouter } from 'react-router-dom';

import AuthProvider, { UnprotectedRoute, ProtectedRoute } from 'features/auth';

import { withLazy } from 'shared/utils';

const LoginView = withLazy(() => import('views/login'));
const ProjectBoardView = withLazy(() => import('views/project-board'));
const ProjectDetailsView = withLazy(() => import('views/project-details'));
const GraphView = withLazy(() => import('views/graph'));
const DashboardView = withLazy(() => import('views/dashboard'));
const AchievementListView = withLazy(() => import('views/achievements'));

const App = () => {
  return (
    <BrowserRouter>
      <AuthProvider>
        <Switch>
          <Route
            exact
            path="/"
            render={() => {
              return <div>Helo world</div>;
            }}
          />

          <Route exact path="/dashboard" component={DashboardView} />

          <Route exact path="/login" component={LoginView} />

          <Route exact path="/user/:id/achievement" component={AchievementListView} />

          <Route exact path="/project/:id/board" component={ProjectBoardView} />

          <Route exact path="/project/:id/details" component={ProjectDetailsView} />

          <Route exact path="/graph" component={GraphView} />

          <Route path="**" render={() => <div>Not Found Page </div>} />
        </Switch>
      </AuthProvider>
    </BrowserRouter>
  );
};

export default App;

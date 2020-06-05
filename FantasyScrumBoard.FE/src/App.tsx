import React from 'react';
import { Switch, Route } from 'react-router';
import { BrowserRouter } from 'react-router-dom';

import { UnprotectedRoute, ProtectedRoute } from 'features/auth';

import { withLazy } from 'shared/utils';

const LoginView = withLazy(() => import('views/login'));
const ProjectBoardView = withLazy(() => import('views/project-board'));

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

        <UnprotectedRoute exact path="/login" redirect="/" component={LoginView} />

        <ProtectedRoute
          exact
          path="/project/:id/board"
          redirect="/login"
          component={ProjectBoardView}
        />

        <Route path="**" render={() => <div>Not Found Page </div>} />
      </Switch>
    </BrowserRouter>
  );
};

export default App;

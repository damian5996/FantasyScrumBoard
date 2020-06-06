import React from 'react';
import { Switch, Route } from 'react-router';
import { BrowserRouter } from 'react-router-dom';

import AuthProvider from 'features/auth';

import { withLazy } from 'shared/utils';

const LoginView = withLazy(() => import('views/login'));
const ProjectBoardView = withLazy(() => import('views/project-board'));
const GraphView = withLazy(() => import('views/graph'));
const MainView = withLazy(() => import('views/main'));

const App = () => {
  return (
    <BrowserRouter>
      <AuthProvider>
        <Switch>
          <Route exact path="/login" component={LoginView} />

          <Route path="/main" component={MainView} />

          <Route exact path="/project/:id/board" component={ProjectBoardView} />

          <Route exact path="/graph" component={GraphView} />

          <Route
            exact
            path="/"
            render={() => {
              return <div>Helo world</div>;
            }}
          />

          <Route path="**" render={() => <div>Not Found Page </div>} />
        </Switch>
      </AuthProvider>
    </BrowserRouter>
  );
};

export default App;

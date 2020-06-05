import React from 'react';
import { Switch, Route } from 'react-router';
import { BrowserRouter } from 'react-router-dom';

import { withLazy } from 'shared/utils';

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

        <Route
        exact
        path="/dashboard"
        component={DashboardView}
        />

        <Route
          exact
          path="/project/:id/board"
          component={ProjectBoardView}
        />
        
        <Route 
        exact
        path="/graph"
        component={GraphView}
        />

        <Route path="**" render={() => <div>Not Found Page </div>} />
      </Switch>
    </BrowserRouter>
  );
};

export default App;

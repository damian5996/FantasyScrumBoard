import React from 'react';
import { Switch, Route } from 'react-router';
import { BrowserRouter } from 'react-router-dom';

import GraphView from 'viewsgraph-view/GraphView';

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
        <GraphView />
        <Route path="**" render={() => <div>Not Found Page </div>} />
      </Switch>
    </BrowserRouter>
  );
};

export default App;

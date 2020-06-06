import React from 'react';

import csx from './Main.scss';
import { Sidebar } from 'views/dashboard';
import { Route, Switch, RouteChildrenProps } from 'react-router';
import { withLazy } from 'shared/utils';

const DashboardView = withLazy(() => import('views/dashboard'));
const ProjectDetailsView = withLazy(() => import('views/project-details'));
const AchievementListView = withLazy(() => import('views/achievements'));

const Main = ({ match }: RouteChildrenProps) => {
  return (
    <div className={csx.mainView}>
      <div className={csx.fluid}>
        <Sidebar />

        <div className={csx.content}>
          <Switch>
            <Route exact path={`${match.path}/dashboard`} component={DashboardView} />

            <Route
              exact
              path={`${match.path}/project/:id/details`}
              component={ProjectDetailsView}
            />

            <Route
              exact
              path={`${match.path}/user/:id/achievement`}
              component={AchievementListView}
            />
          </Switch>
        </div>
      </div>
    </div>
  );
};

export default Main;

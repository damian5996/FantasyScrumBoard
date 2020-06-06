import React, { useContext } from 'react';

import csx from './ProjectTeam.scss';
import { User } from 'api';
import { AuthContext } from 'features/auth';

import { Button } from 'shared/ui';
import { Link } from 'react-router-dom';

interface ProjectTeamProps {
  team: User[];
}

const teamMock: User[] = [
  {
    nick: 'Zarzadca chaosu',
    id: 0,
    firstName: 'Adrian',
    lastName: 'Polubinski',
    email: 'polubik1994@gmail.com',
    level: 1,
    exp: 78,
    createdAt: new Date()
  },

  {
    nick: 'Zarzadca chaosu',
    id: 1,
    firstName: 'Adrian',
    lastName: 'Polubinski',
    email: 'polubik1994@gmail.com',
    level: 1,
    exp: 78,
    createdAt: new Date()
  },

  {
    nick: 'Zarzadca chaosu',
    id: 2,
    firstName: 'Adrian',
    lastName: 'Polubinski',
    email: 'polubik1994@gmail.com',
    level: 1,
    exp: 78,
    createdAt: new Date()
  },

  {
    nick: 'Zarzadca chaosu',
    id: 3,
    firstName: 'Adrian',
    lastName: 'Polubinski',
    email: 'polubik1994@gmail.com',
    level: 1,
    exp: 78,
    createdAt: new Date()
  },

  {
    nick: 'Zarzadca chaosu',
    id: 3,
    firstName: 'Adrian',
    lastName: 'Polubinski',
    email: 'polubik1994@gmail.com',
    level: 1,
    exp: 78,
    createdAt: new Date()
  },

  {
    nick: 'Zarzadca chaosu',
    id: 3,
    firstName: 'Adrian',
    lastName: 'Polubinski',
    email: 'polubik1994@gmail.com',
    level: 1,
    exp: 78,
    createdAt: new Date()
  },

  {
    nick: 'Zarzadca chaosu',
    id: 3,
    firstName: 'Adrian',
    lastName: 'Polubinski',
    email: 'polubik1994@gmail.com',
    level: 1,
    exp: 78,
    createdAt: new Date()
  },

  {
    nick: 'Zarzadca chaosu',
    id: 3,
    firstName: 'Adrian',
    lastName: 'Polubinski',
    email: 'polubik1994@gmail.com',
    level: 1,
    exp: 78,
    createdAt: new Date()
  }
];

export const ProjectTeam = ({ team = teamMock }) => {
  const { user } = useContext(AuthContext);

  return (
    <div className={csx.projectTeam}>
      <Button className={csx.buttonHeader}>TEAM</Button>

      <ul>
        {team.map(member => (
          <li className={csx.member}>
            <figure>
              <img src="https://www.wprost.pl/_thumb/5f/09/909272231d1fcb0bd2a3bcd3d8c3.jpeg" />
            </figure>
            <h2>{member.nick}</h2>
            <span className={csx.class}>frontend - warrior</span>

            <div className={csx.detailSection}>
              <span>POINTS</span>
              <div className={csx.points}>
                <div className={csx.point}>
                  <span>25</span>
                  <span>sprint</span>
                </div>

                <div className={csx.point}>
                  <span>25</span>
                  <span>sprint</span>
                </div>
              </div>
            </div>

            <div className={csx.detailSection}>
              <span>SKILLS</span>
              <div>Lorem ipsum</div>
            </div>

            <Link to="/">
              <Button>Profile</Button>
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
};

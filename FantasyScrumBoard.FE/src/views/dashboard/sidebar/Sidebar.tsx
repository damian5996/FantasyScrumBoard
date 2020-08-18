import React, { useState, useContext } from 'react';

import { SwordIcon } from 'shared/icons';

import csx from './Sidebar.scss';
import { AuthContext } from 'features/auth';

const SIDEBAR_LINKS = ['Main', 'Projects', 'Board', 'Map', 'User Details'];

const USER_INFO: UserInfoList[] = [
  {
    icon: <SwordIcon />,
    label: 'ui-paladin'
  },
  {
    icon: '25',
    label: 'sprint2'
  },
  {
    icon: '78',
    label: 'total'
  }
];

interface UserInfoList {
  icon: React.ReactNode | string;
  label: string;
}

export const Sidebar = () => {
  const [activeLink, setActiveLink] = useState('Main');
  const [open, setOpen] = useState(true);

  const user = useContext(AuthContext);

  const handleClick = () => {
    setOpen(!open);
  };

  const handleChangeLink = (event: any, link: string) => setActiveLink(link);

  const email = user.user.email as any;

  return (
    <div className={csx.sidebar}>
      <section className={csx.userSection}>
        <div className={csx.avatar}>
          <img src="https://upload.wikimedia.org/wikipedia/en/thumb/c/cb/Robert_Downey_Jr._as_Iron_Man_in_Avengers_Infinity_War.jpg/220px-Robert_Downey_Jr._as_Iron_Man_in_Avengers_Infinity_War.jpg" />
        </div>
        <div className={csx.userInfo}>
          <p className={csx.userLogin}>{email}</p>

          <p style={{ textAlign: 'center' }}>{USER_INFO[0].label}</p>
          <p
            style={{
              textAlign: 'center',
              fontWeight: 'bold',
              marginTop: '24px',
              marginBottom: '8px'
            }}
          >
            POINTS
          </p>

          <ul>
            <li className={csx.listElement}>
              <span>{USER_INFO[1].icon}</span> <span>{USER_INFO[1].label}</span>
            </li>
            <li className={csx.listElement}>
              <span>{USER_INFO[2].icon}</span> <span>{USER_INFO[2].label}</span>
            </li>
          </ul>
        </div>
      </section>

      <nav className={csx.nav}>
        <ul>
          {SIDEBAR_LINKS.map((link) => {
            return (
              <li
                key={link}
                className={`${csx.link} ${activeLink === link ? csx.linkActive : ''}`}
                onClick={(event) => handleChangeLink(event, link)}
              >
                {link.toLocaleUpperCase()}
              </li>
            );
          })}
        </ul>
      </nav>
    </div>
  );
};

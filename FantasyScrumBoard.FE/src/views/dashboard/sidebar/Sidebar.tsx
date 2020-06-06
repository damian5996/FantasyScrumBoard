import React, { useState } from 'react';

import { SwordIcon } from 'shared/icons';

import csx from './Sidebar.scss';

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
  const handleChangeLink = (event: any, link: string) => setActiveLink(link);

  return (
    <div className={csx.sidebar}>
      <section className={csx.userSection}>
        <div className={csx.avatar}>img</div>
        <div className={csx.userInfo}>
          <p className={csx.userLogin}>USERNAME</p>

          <p style={{ textAlign: 'center' }}>{USER_INFO[0].label}</p>
          <p style={{ textAlign: 'center', fontWeight: 'bold', marginTop: '24px', marginBottom: '8px' }}>POINTS</p>

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
          {SIDEBAR_LINKS.map((link) => (
            <li
              key={link}
              className={`${csx.link} ${activeLink === link ? csx.linkActive : ''}`}
              onClick={(event) => handleChangeLink(event, link)}
            >
              {link.toLocaleUpperCase()}
            </li>
          ))}
        </ul>
      </nav>
    </div>
  );
};

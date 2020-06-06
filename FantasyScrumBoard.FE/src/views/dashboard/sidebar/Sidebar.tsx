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
    label: 'points this sprint'
  },
  {
    icon: '78',
    label: 'points total'
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
          <ul style={{marginLeft: '16px'}}>
            {USER_INFO.map((user, id) => {
              return (
                <li key={id} className={csx.listElement}>
                  <span>{user.icon}</span> <span>{user.label}</span>
                </li>
              );
            })}
          </ul>
        </div>
      </section>

      <nav className={csx.nav}>
        <ul>
          {SIDEBAR_LINKS.map((link) => (
            <li key={link} className={`${csx.link} ${activeLink === link ? csx.linkActive : ''}`} onClick={(event) => handleChangeLink(event, link)}>{link.toLocaleUpperCase()}</li>
          ))}
        </ul>
      </nav>
    </div>
  );
};

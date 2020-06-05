import React from 'react';

import Tree, { ReactD3TreeItem } from 'react-d3-tree';

import csx from './GraphView.scss';

const myTreeData: ReactD3TreeItem[] = [
  {
    name: 'Top Level',
    attributes: {
      keyA: 'val A',
      keyB: 'val B',
      keyC: 'val C'
    },
    children: [
      {
        name: 'Level 2: A',
        attributes: {
          keyA: 'val A',
          keyB: 'val B',
          keyC: 'val C'
        },
        children: [
          {
            name: 'Level 3: A',
            attributes: {
              essa:
                'essunia',
              memy: 'z papiezem'
            }
          },
          {
            name: 'children 2',
            attributes: {
              gitara: 'siema'
            }
          }
        ]
      },
      {
        name: 'Level 2: B',
        attributes: {
          ebebe: 'ebebe',
          rogal: 'ddl'
        },
        children: [
          {
            name: 'level 3',
            attributes: {
              gitgit: 'gitgit'
            }
          }
        ]
      }
    ]
  }
];

const GraphView = () => {
  const handleClick = (targetNode: ReactD3TreeItem, event: Event) => {
    console.log(targetNode);
    console.log(event);
  };

  return (
    <div className={csx.graphView}>
      <Tree
        orientation="vertical"
        onClick={handleClick}
        data={myTreeData}
        zoomable={false}
        textLayout={{ textAnchor: 'start', x: 10, y: -10, transform: undefined }}
        separation={{ nonSiblings: 1, siblings: 2 }}
        translate={{ x: window.innerWidth / 2, y: 100 }}
      />
    </div>
  );
};

export default GraphView;

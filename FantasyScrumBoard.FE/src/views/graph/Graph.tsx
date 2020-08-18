import React from 'react';

import Tree, { ReactD3TreeItem } from 'react-d3-tree';

import csx from './Graph.scss';

const myTreeData: ReactD3TreeItem[] = [
  {
    name: 'Sprint 1',
    attributes: {
      keyA: 'Task 1',
      keyB: 'Task 2',
      keyC: 'Task 3'
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
              test:
                'test',
              t: 'test'
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

const Graph = () => {
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

export default Graph;

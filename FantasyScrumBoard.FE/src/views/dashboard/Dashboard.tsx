import React, { useEffect, useState } from 'react';

import ProjectForm from 'features/project-form';
import { Button, CircularProgress } from '@material-ui/core';
import AddIcon from '@material-ui/icons/Add';

import { ProjectTile, CurrentTasks, LatestNews } from '.';

import { WorkItem, getWorkItemsDashboard, News, getNews, Project, getProjects } from 'api';

import { DataWrapper } from 'shared/utils';

import csx from './Dashboard.scss';

const INIT_STATE: DataWrapper<any> = {
  isLoading: false,
  data: [],
  error: ''
};

const Dashboard = () => {
  const [projectFormData, setProjectFormData] = useState({
    isOpen: false,
    data: null
  });

  const [projects, setProjects] = useState<DataWrapper<Project>>(INIT_STATE);
  const [workItems, setWorkItems] = useState<DataWrapper<WorkItem>>(INIT_STATE);
  const [news, setNews] = useState<DataWrapper<News>>(INIT_STATE);

  const [viewProjects, setViewProjects] = useState(true);
  const [viewTasks, setViewTasks] = useState(true);
  const [viewNews, setViewNews] = useState(true);

  const handleGetProjects = async () => {
    if (!projects.isLoading) {
      setProjects({
        ...projects,
        isLoading: true
      });
    }

    try {
      const projectsApi = await getProjects();
      setProjects({
        ...projects,
        isLoading: false,
        data: projectsApi
      });
    } catch (error) {
      setProjects({
        isLoading: false,
        data: [],
        error: error
      });
    }
  };

  const handleGetWorkItems = async () => {
    if (!workItems.isLoading) {
      setWorkItems({
        ...workItems,
        isLoading: true
      });
    }

    try {
      const workItemsApi = await getWorkItemsDashboard();
      setWorkItems({
        ...workItems,
        data: workItemsApi,
        isLoading: false
      });
    } catch (error) {
      setWorkItems({
        isLoading: false,
        data: [],
        error: error
      });
    }
  };

  const handleGetNews = async () => {
    if (!news.isLoading) {
      setNews({
        ...news,
        isLoading: true
      });
    }

    try {
      const newsApi = await getNews();
      setNews({
        ...news,
        data: newsApi,
        isLoading: false
      });
    } catch (error) {
      setNews({
        isLoading: false,
        data: [],
        error: error
      });
    }
  };

  const startProjectEdit = (id: number) => {
    const project = projects.data.find(p => p.id === id);

    setProjectFormData({ isOpen: true, data: project });
  };

  const onProjectAdd = (project: Project) => {
    setProjectFormData({ isOpen: false, data: null });
    setProjects({
      ...projects,
      data: [...projects.data, project]
    });
  };

  useEffect(() => {
    handleGetProjects();
    handleGetWorkItems();
    handleGetNews();
  }, []);

  return (
    <>
      {projectFormData.isOpen && (
        <ProjectForm
          data={projectFormData.data}
          onAdd={onProjectAdd}
          onEdit={() => {}}
          onClose={() => {
            setProjectFormData({
              isOpen: false,
              data: null
            });
          }}
        />
      )}

      <div className={csx.dashboardWrapper}>
        <section>
          <div className={csx.header}>
            <Button
              onClick={() => setViewProjects(true)}
              className={`${csx.buttonHeader} ${
                viewProjects ? csx.activeButton : csx.unActiveButton
              }`}
            >
              PROJECTS
            </Button>
            <Button
              onClick={() => setViewProjects(false)}
              className={`${csx.buttonHeader} ${
                !viewProjects ? csx.activeButton : csx.unActiveButton
              }`}
              style={{ marginLeft: '40px' }}
            >
              ALL PROJECTS
            </Button>
          </div>
          <h1>
            <span>PROJECTS</span>
            <Button
              onClick={() => {
                setProjectFormData({
                  isOpen: true,
                  data: null
                });
              }}
              style={{ backgroundColor: '#d30000', marginLeft: '10px', color: 'white' }}
            >
              <AddIcon />
            </Button>
          </h1>
          
          <div className={csx.projects}>
            {projects.isLoading && <CircularProgress color="secondary" />}
            {projects.data.length > 0 &&
              projects.data.map(project => {
                return (
                  <ProjectTile
                    key={project.id}
                    id={project.id}
                    name={project.name}
                    onEdit={startProjectEdit}
                  />
                );
              })}
          </div>
        </section>

        <section>
          <div className={csx.header} style={{ marginTop: '49px' }}>
            <Button
              onClick={() => setViewTasks(true)}
              className={`${csx.buttonHeader} ${viewTasks ? csx.activeButton : csx.unActiveButton}`}
            >
              TASKS
            </Button>
            <Button
              onClick={() => setViewTasks(false)}
              className={`${csx.buttonHeader} ${
                !viewTasks ? csx.activeButton : csx.unActiveButton
              }`}
              style={{ marginLeft: '40px' }}
            >
              MY TASKS
            </Button>
          </div>
          <div className={csx.center}>
            {workItems.isLoading && <CircularProgress color="secondary" />}
            {workItems.data.length > 0 && <CurrentTasks workItems={workItems.data} />}
          </div>
          {!workItems.isLoading && <Button className={csx.button}>More tasks</Button>}
        </section>

        <section>
          <div className={csx.header} style={{ marginTop: '49px' }}>
            <Button
              onClick={() => setViewNews(true)}
              className={`${csx.buttonHeader} ${viewNews ? csx.activeButton : csx.unActiveButton}`}
            >
              LATEST NEWS
            </Button>
            <Button
              onClick={() => setViewNews(false)}
              className={`${csx.buttonHeader} ${!viewNews ? csx.activeButton : csx.unActiveButton}`}
              style={{ marginLeft: '40px' }}
            >
              ACHIEVEMENTS
            </Button>
          </div>
          <div className={csx.center}>
            {news.isLoading && <CircularProgress color="secondary" />}
            {news.data.length > 0 && <LatestNews news={news.data} />}
          </div>
          {!news.isLoading && <Button className={csx.button}>More news</Button>}
        </section>
      </div>
    </>
  );
};

export default Dashboard;

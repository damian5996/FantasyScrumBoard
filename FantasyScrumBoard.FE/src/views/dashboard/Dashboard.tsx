import React, { useEffect, useState } from 'react';

import { ProjectTile, CurrentTasks, LatestNews, DataWrapper } from '.';

import { getProjects, WorkItem, getWorkItemsDashboard, News, getNews, Project } from 'api';

import csx from './Dashboard.scss';

const INIT_STATE: DataWrapper<any> = {
  isLoading: false,
  data: [],
  error: ''
}

const Dashboard = () => {

  const [projects, setProjects] = useState<DataWrapper<Project>>(INIT_STATE);
  const [workItems, setWorkItems] = useState<DataWrapper<WorkItem>>(INIT_STATE);
  const [news, setNews] = useState<DataWrapper<News>>(INIT_STATE);


  const handleGetProjects = async () => {
    if (!projects.isLoading) {
      setProjects({
        ...projects,
        isLoading: true
      })
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
      })
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
      })
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
  

  useEffect(() => {
    handleGetProjects();
    handleGetWorkItems();
    handleGetNews();
  }, []);

  return (
    <div>
      <section>
        <h1>PROJECTS</h1>
        <div className={csx.projects}>
          {projects.isLoading && "Loading projects"}
          {projects.data.length > 0 && projects.data.map(project => {
            return <ProjectTile key={project.id} name={project.name} id={project.id}/>
          })}
        </div>
      </section>

      <section>
        <h1>CURRENT TASKS / MY TASKS</h1>
        <div className={csx.center}>
          {workItems.isLoading && "Loading current tasks"}
          {workItems.data.length > 0 && <CurrentTasks workItems={workItems.data}/>}
        </div>
        {!workItems.isLoading && <button>LOAD MORE</button>}
      </section>

      <section>
        <h1>LATEST NEWS</h1>
        <div className={csx.center}>
        {news.isLoading && "Loading latest news"}
        {news.data.length > 0 && <LatestNews news={news.data}/>}
        </div>
        {!news.isLoading && <button>LOAD MORE</button>}
      </section>
    </div>
  );
};

export default Dashboard;
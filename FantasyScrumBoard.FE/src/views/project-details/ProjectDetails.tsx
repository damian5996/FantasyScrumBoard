import React, { useState, useEffect } from 'react';
import { RouteChildrenProps } from 'react-router';

import { ProjectDetails, getProjectDetails } from 'api';

import { ProjectTeam } from '.';

import csx from './ProjectDetails.scss';
import { CircularProgress } from '@material-ui/core';

interface ProjectDetailsProps extends RouteChildrenProps<{ id: string }> {}

const ProjectDetails = ({ match }: ProjectDetailsProps) => {
  const [isLoading, setIsLoading] = useState(true);
  const [projectDetails, setProjectDetails] = useState<ProjectDetails>();

  const handleGetProjectDetails = async (id: number) => {
    if (!isLoading) {
      setIsLoading(true);
    }

    try {
      const project = await getProjectDetails(id);
      setProjectDetails(project);
      setIsLoading(false);
    } catch (error) {
      setProjectDetails(null);
      setIsLoading(false);
    }
  };

  useEffect(() => {
    handleGetProjectDetails(+match.params.id);
  }, []);

  return (
    <div className={csx.projectDetails}>
      {isLoading ? (
        <div className={csx.loader}>
          <CircularProgress color="secondary" />
        </div>
      ) : (
        <>
          <h2>
            <span>PROJECTS / Project name</span>
          </h2>
          <ProjectTeam />
        </>
      )}
    </div>
  );
};

export default ProjectDetails;

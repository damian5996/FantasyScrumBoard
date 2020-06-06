import React, { useState, useEffect } from 'react';
import { RouteChildrenProps } from 'react-router';

import { CircularProgress } from '@material-ui/core';

import { ProjectDetails, getProjectDetails, Sprint } from 'api';

import SprintForm from 'features/sprint-form';

import { ProjectTeam, ProjectSprints } from '.';

import csx from './ProjectDetails.scss';


interface ProjectDetailsProps extends RouteChildrenProps<{ id: string }> {}

const ProjectDetails = ({ match }: ProjectDetailsProps) => {
  const [sprintFormData, setSprintFormData] = useState({
    isOpen: false,
    data: null
  });
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

          {sprintFormData.isOpen && (
            <SprintForm
              projectId={+match.params.id}
              data={sprintFormData.data}
              onClose={() =>
                setSprintFormData({
                  isOpen: false,
                  data: null
                })
              }
              onAdd={() => {}}
              onEdit={() => {}}
            />
          )}

          <ProjectSprints sprints={[]} />

          <ProjectTeam />
        </>
      )}
    </div>
  );
};

export default ProjectDetails;

import React, { useState, useEffect } from 'react';
import { RouteChildrenProps } from 'react-router';

import { ProjectDetails, getProjectDetails } from 'api';

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

  if (isLoading) return <div>Loading project details...</div>;
  if (projectDetails === null && !isLoading) return <div>No details</div>;
  
  console.log(projectDetails);
  return <div>siema szczegoly projektu here</div>;
};

export default ProjectDetails;

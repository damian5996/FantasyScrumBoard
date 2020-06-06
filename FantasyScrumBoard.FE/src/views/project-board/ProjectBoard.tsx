import React, { useState, useEffect } from 'react';
import { DragDropContext, Droppable, Draggable } from 'react-beautiful-dnd';
import CircularProgress from '@material-ui/core/CircularProgress';

import { getTasks } from 'api';

import csx from './ProjectBoard.scss';

const taskStatusesLabels = ['To do', 'In progress', 'Code review', 'Testing', 'Done'];

const reorder = (list, startIndex, endIndex) => {
  const result = Array.from(list);
  const [removed] = result.splice(startIndex, 1);
  result.splice(endIndex, 0, removed);

  return result;
};

/**
 * Moves an item from one list to another list.
 */
const move = (source, destination, droppableSource, droppableDestination) => {
  const sourceClone = Array.from(source);
  const destClone = Array.from(destination);
  const [removed] = sourceClone.splice(droppableSource.index, 1);

  destClone.splice(droppableDestination.index, 0, removed);

  const result = {};
  result[droppableSource.droppableId] = sourceClone;
  result[droppableDestination.droppableId] = destClone;

  return result;
};

const getItemStyle = (isDragging, draggableStyle) => ({
  background: isDragging ? '#5e0042' : 'linear-gradient(to top right, #4d0043, #1a006c)',
  ...draggableStyle
});

function ProjectBoardView() {
  const [isLoading, setIsLoading] = useState(true);
  const [state, setState] = useState([]);

  const handleGetTasks = async () => {
    if (!isLoading) {
      setIsLoading(true);
    }

    try {
      const tasks = await getTasks();
      setIsLoading(false);
      setState(tasks);
    } catch (err) {
      setIsLoading(false);
      setState([]);
    }
  };

  useEffect(() => {
    handleGetTasks();
  }, []);

  function onDragEnd(result) {
    const { source, destination } = result;

    // dropped outside the list
    if (!destination) {
      return;
    }
    const sInd = +source.droppableId;
    const dInd = +destination.droppableId;

    if (sInd === dInd) {
      const items = reorder(state[sInd], source.index, destination.index);
      const newState = [...state];
      newState[sInd] = items as any;
      setState(newState);
    } else {
      const result = move(state[sInd], state[dInd], source, destination);
      const newState = [...state];
      newState[sInd] = result[sInd];
      newState[dInd] = result[dInd];

      setState(newState.filter(group => group.length));
    }
  }

  return (
    <div className={csx.projectBoardView}>
      {isLoading ? (
        <CircularProgress color="secondary" />
      ) : (
        <div className={csx.projectTasks}>
          <DragDropContext onDragEnd={onDragEnd}>
            {state.map((el, ind) => (
              <Droppable key={ind} droppableId={`${ind}`}>
                {(provided, snapshot) => (
                  <div
                    ref={provided.innerRef}
                    className={csx.boardColumn}
                    {...provided.droppableProps}
                  >
                    <p>{taskStatusesLabels[ind]}</p>

                    <div className={csx.tasks}>
                      {el.map((item, index) => (
                        <Draggable key={item.id} draggableId={item.id} index={index}>
                          {(provided, snapshot) => (
                            <div
                              ref={provided.innerRef}
                              className={csx.task}
                              {...provided.draggableProps}
                              {...provided.dragHandleProps}
                              style={getItemStyle(
                                snapshot.isDragging,
                                provided.draggableProps.style
                              )}
                            >
                              <span className={csx.name}>{item.name}</span>
                              <span className={csx.description}>{item.description}</span>
                              {/* <button
                                  type="button"
                                  onClick={() => {
                                    const newState = [...state];
                                    newState[ind].splice(index, 1);
                                    setState(newState.filter(group => group.length));
                                  }}
                                >
                                  delete
                                </button> */}
                            </div>
                          )}
                        </Draggable>
                      ))}
                      {provided.placeholder}
                    </div>
                  </div>
                )}
              </Droppable>
            ))}
          </DragDropContext>
        </div>
      )}
    </div>
  );
}

export default ProjectBoardView;

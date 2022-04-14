import { FaTimes } from 'react-icons/fa'

const Task = ({ task, onDelete, onToggle }) => {
  return (
    <div
      className={`task ${task.name && 'name'}`}
      onDoubleClick={() => onToggle(task.id)}
    >
      <h3>
        {task.name}{' '}
        <FaTimes
          style={{ color: 'red', cursor: 'pointer' }}
          onClick={() => onDelete(task.id)}
        />
      </h3>

      <p>H:{task.height}, M:{task.mass}, 
      C:{task.eye_color}, S:{task.gender}</p>
    </div>
  )
}


export default Task

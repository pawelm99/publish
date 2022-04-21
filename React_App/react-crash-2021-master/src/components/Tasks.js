import Task from './Task'

const Tasks = ({ tasks, onDelete, onToggle,sortHeight }) => {
 
  if(sortHeight ===true)
  {
    tasks.sort((a,b)=>{
      if (a.height < b.height) {
        return -1;
      }
      if (a.height > b.height) {
        return 1;
      }
      return 0;
    })
  }
  else
  {
    tasks.sort((a,b)=>{
      if (a.mass < b.mass) {
        return -1;
      }
      if (a.mass > b.mass) {
        return 1;
      }
      return 0;
    })
  }

  console.log(tasks);
  return (
    <>
      { 
      
      tasks.map((task, index) => (
        <Task key={index} task={task} onDelete={onDelete} onToggle={onToggle} />
      ))}
    </>
  )
}



export default Tasks

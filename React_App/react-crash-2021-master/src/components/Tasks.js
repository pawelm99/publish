
import Task from './Task'

const Tasks = ({ tasks, onDelete, onToggle,sortHeight,filterName }) => {
 

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
  else if(sortHeight === false)
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

  if(filterName != null )
  {
  
   console.log(filterName)
    tasks = filterName;
    
  }
  

  
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

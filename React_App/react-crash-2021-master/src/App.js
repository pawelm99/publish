import { useState, useEffect } from 'react'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import Header from './components/Header'
import Footer from './components/Footer'
import Tasks from './components/Tasks'
import AddTask from './components/AddPerson'
import About from './components/About'
import { get } from 'jquery'

const App = ({ onAdd }) => {
  const [showAddTask, setShowAddTask] = useState(false)
  const [tasks, setTasks] = useState([])
  const [names,setName] = useState('');
  const [sortH, setSortH] = useState(false);


  useEffect(() => {
    const getTasks = async () => {
      const tasksFromServer = await fetchTasks()
     
      setTasks(tasksFromServer)
    }

    getTasks()
  }, [])

   

 
  // Fetch Tasks
  const fetchTasks = async () => {
    const res = await fetch('http://localhost:5000/tasks')
    const data = await res.json()
 

    return data
  }

  // Fetch Task
  const fetchTask = async (id) => {
    const res = await fetch(`http://localhost:5000/tasks/${id}`)
    const data = await res.json()

    

    return data
  }

  // Add Task
  const addTask = async (task) => {
    const res = await fetch('http://localhost:5000/tasks', {
      method: 'POST',
      headers: {
        'Content-type': 'application/json',
      },
      body: JSON.stringify(task),
    })

    const data = await res.json()

    setTasks([...tasks, data])

    // const id = Math.floor(Math.random() * 10000) + 1
    // const newTask = { id, ...task }
    // setTasks([...tasks, newTask])
  }

  // Delete Task
  const deleteTask = async (id) => {
    const res = await fetch(`http://localhost:5000/tasks/${id}`, {
      method: 'DELETE',
    })
    //We should control the response status to decide if we will change the state or not.
    res.status === 200
      ? setTasks(tasks.filter((task) => task.id !== id))
      : alert('Error Deleting This Task')
  }

  // Toggle Reminder
  const toggleReminder = async (id) => {
    const taskToToggle = await fetchTask(id)
    const updTask = { ...taskToToggle, reminder: !taskToToggle.reminder }

    const res = await fetch(`http://localhost:5000/tasks/${id}`, {
      method: 'PUT',
      headers: {
        'Content-type': 'application/json',
      },
      body: JSON.stringify(updTask),
    })


    const data = await res.json()
  
    setTasks(
      tasks.map((task) =>
        task.id === id ? { ...task, reminder: data.reminder } : task
      )
    )
  }

  //Comparer Function    
function GetSortOrder(prop) {    
  return function(a, b) {    
      if (a[prop] > b[prop]) {    
          return 1;    
      } else if (a[prop] < b[prop]) {    
          return -1;    
      }    
      return 0;    
  }    
}    



  function refreshPage()
  {
      window.location.reload();
  }

  const updateTaskHeight=()=> setSortH(true)
  const updateTaskMass=()=> setSortH(false)

const onSubmit = (e)=>{
  e.preventDefault();

  if (!names) {
    alert('Please write name')
    return
  }

  onAdd({ names })

  setName('')
  
}

function filter()
{
  
  console.log(names);
  var res =tasks.map(x=>x.name).filter(name => name.includes(names)).map(filteredName => (filteredName));
  var toString = res.toString(); 
  alert(toString);
}

  return (
    
    <Router>
     
      <div className='container'>
        <Header
          onAdd={() => setShowAddTask(!showAddTask)}
          showAdd={showAddTask}
        />
        <Routes>
          <Route
            path='/'
            element={
              <>
                {showAddTask && <AddTask onAdd={addTask}  />}
                {tasks.length > 0 ? 
                (
                  <Tasks 
                    tasks={tasks}
                    onDelete={deleteTask}
                    onToggle={toggleReminder}
                    sortHeight={sortH}
                    sortMass={sortH}
                  />
                  
                ) : (
                  'No CHaracter To Show'
                )}
              </>
            }
          />
          
          <Route path='/about' element={<About />} />
        </Routes>
        <Footer />
        <button onClick={updateTaskHeight} className="btn" >Sort Height</button>
        <button onClick={updateTaskMass} className="btn" >Sort Mass</button>
        <button onClick={refreshPage} className="btn" >Refresh Page</button>
        <div className='form-control'>
        <label>Filter input first name</label>
        <input
          type='text'
          placeholder='Wrtie first-name'
          value={names}
          onChange={(e) => setName(e.target.value)}
        />
      </div>
        <button onClick={filter} className="btn" >Filter</button>
      </div>
    </Router>
  )
}

export default App

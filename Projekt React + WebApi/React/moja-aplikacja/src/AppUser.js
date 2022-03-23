import React,{useState} from 'react'
import UserCreateForm from './components/UserCreateForm';

export default function App() {
const [users,setUsers] = useState([]);
const [showingCreateNewPostFrom, setShowingCreateNewPostForm] = useState(false);

function getUsers(){
  const url = 'https://localhost:7156/api/User';
  fetch(url,{
    method: 'GET'
  })
  .then(response => response.json())
  .then(userFromServer => {
    console.log(userFromServer);
    setUsers(userFromServer);
  })
  .catch((error) =>{
    console.log(error);
    alert(error);
  })
}

return (
  <div className='container'>
    <div className='row min-vh-100'>
      <div className='col d-flex flex-cloum justify-content-center align-items-center'>

     {(showingCreateNewPostFrom === false ) && (
       <div>
           <h1>Hello !</h1>

  <div className='mt-5'>
  <button onClick={getUsers} className="btn btn-dark btn-lg w-100">Get User  </button>
  <button onClick={()=>setShowingCreateNewPostForm(true)} className="btn btn-dark btn-lg w-100">Create User </button>
  </div>
  </div>
     )}
     
       
        {(users.length > 0 && showingCreateNewPostFrom === false)  && renderUserTable()}
        {showingCreateNewPostFrom && <UserCreateForm onUserCreated = {onPostCreated}/>}
    
        </div>
      </div>
      </div>
    
   
  
);

  function renderUserTable()
  {
    return(
      <div className='table-reponsive mt-5'>
        <table className='table table-bordered border-dark'>
          <thead>
            <tr>
              <th scope='col'>UserId</th>
              <th scope='col'>Login</th>
              <th scope='col'>Password</th>
              <th scope='col'>CRUD OPERATION</th>
              </tr>
              </thead>
              
              <tbody>
                {users.map((user)=>(
                  <tr key={user.id}>
                    <td>{user.id}</td>
                    <td>{user.login}</td>
                    <td>{user.password}</td>
                    <td><button className='btn btn-dark btn-lg mx-3 my-3'>UPDATE</button>
                    <button className='btn btn-secondary btn-lg'>DELETE</button>
                     
                     </td>
                    </tr> 
                ))}
              </tbody>
              </table>
              <button onClick={()=> setUsers([])} className="btn btn-dark btn-lg w-100">Empy React users array</button>
              </div>
    )
  }
  function onPostCreated(cretePost)
  {
    setShowingCreateNewPostForm(false);

    if(cretePost === null){
      return;
    }

    alert("User successfully created.");

    getUsers();
  }
}


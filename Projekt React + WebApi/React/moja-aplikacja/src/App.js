import React,{useState} from 'react'


export default function App() {
const [users,setUsers] = useState([]);

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
            </tr>
            </thead>
            
            <tbody>
              {users.map((user)=>(
                <tr key={user.id}>
                  <td>{user.id}</td>
                  <td>{user.login}</td>
                  <td>{user.password}</td>
                  
                  </tr> 
              ))}
            </tbody>
            </table>
            <button onClick={()=> setUsers([])} className="btn btn-dark-lg w-100">Empy React users array</button>
            </div>
  )
}
  return (
    <div className='container'>
      <dvi className='row min-vh-100'>
        <div className='col d-flex flex-cloum justify-content-center align-items-center'>
          <h1>Hello Bootstrap!</h1>
          <div className='mt-5'>
            <button onClick={getUsers} className="btn btn-dark btn-lg w-100">Get Users from server</button></div>

           
          </div>
          {users.length > 0 && renderUserTable()}
        </dvi>
      
      </div>
    
  );
}


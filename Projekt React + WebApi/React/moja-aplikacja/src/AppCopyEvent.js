import React, { useState } from "react";
import EventCreateForm from "./components/EventCreateForm";
export default function App(){
  const [events,setEvents] = useState([]);
  const [showingCreateNewEventFrom, setShowingCreateNewEventForm] = useState(false);

  function getEvents(){
    const url = 'https://localhost:7156/api/Event';
    fetch(url,{
      method:'GET'
    })
    .then(res=> res.json())
    .then(useFromServer =>{
      console.log(useFromServer);
      setEvents(useFromServer);
    })
    .catch((error)=>{
      console.log(error);
      alert(error);
    })
  }

  return (
    <div className='container'>
      <div className='row min-vh-100'>
        <div className='col d-flex flex-cloum justify-content-center align-items-center'>
       {showingCreateNewEventFrom === false && (
         <div>
             <h1>Hello !</h1>

    <div className='mt-5'>
    <button onClick={getEvents} className="btn btn-dark btn-lg w-100">Get Event  </button>
    <button onClick={()=>setShowingCreateNewEventForm(true)} className="btn btn-dark btn-lg w-100">Create Event </button>
    </div>
    </div>
       )}
       
         
          {(events.length > 0 && showingCreateNewEventFrom ===false ) && renderUserTable()}
          {showingCreateNewEventFrom && <EventCreateForm onEventCreated = {onEventCreated}/>}
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
              <th scope='col'>EventId</th>
              <th scope='col'>Name</th>
              <th scope='col'>Password</th>

              </tr>
              </thead>
              
              <tbody>
                {events.map((event)=>(
                  <tr key={event.id}>
                    <td>{event.id}</td>
                    <td>{event.name}</td>
                    <td>{event.date}</td>

                     
                 
                    </tr> 
))}
</tbody>
</table>

</div>
)
}

function onEventCreated(createdEvent)
{
  setShowingCreateNewEventForm(false);
  if(createdEvent === null){
    return;
  }
  alert(`Event Created!, "${createdEvent.name}"`);
}

      
    

}

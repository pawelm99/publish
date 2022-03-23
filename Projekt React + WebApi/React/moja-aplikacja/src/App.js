import React, { useState } from "react";
import EventCreateForm from "./components/EventCreateForm";
import EventUpdateForm from "./components/EventUpdateForm";

export default function App(){
  const [events,setEvents] = useState([]);
  const [showingCreateNewEventFrom, setShowingCreateNewEventForm] = useState(false);
  const [eventCurrentlyBegingUpdated, setEventCurrentlyBegingUpdated] = useState(null);

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
    });
  }
function deleteEvent(eventId){
  const url = `https://localhost:7156/api/Event/${eventId}`;
  fetch(url,{
    method:'DELETE'
  })
  .then(response=> response.json())
  .then(resFromServer => {
    console.log(resFromServer);
    onEventDelete(eventId);
  })
  .catch((error) => {
    console.log(error);
    alert(error);
  });
}



  return (
    <div className='container'>
      <div className='row min-vh-100'>
        <div className='col d-flex flex-cloum justify-content-center align-items-center'>

       {(showingCreateNewEventFrom === false && eventCurrentlyBegingUpdated === null)&&(
         <div>
             <h1>Hello !</h1>

    <div className='mt-5'>
    <button onClick={getEvents} className="btn btn-dark btn-lg w-100">Get Event  </button>
    <button onClick={()=>setShowingCreateNewEventForm(true)} className="btn btn-dark btn-lg w-100">Create Event </button>
    </div>
    </div>
       )}
       
         
          {(events.length > 0 && showingCreateNewEventFrom === false && eventCurrentlyBegingUpdated ===null)  && renderUserTable()}
          {showingCreateNewEventFrom && <EventCreateForm onEventCreated = {onEventCreated}/>}
          {eventCurrentlyBegingUpdated != null && <EventUpdateForm event ={eventCurrentlyBegingUpdated} onEventUpdate={onEventUpdate}/>}
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
                    <td><button onClick={()=> setEventCurrentlyBegingUpdated(event) } className='btn btn-dark btn-lg mx-3 my-3'>UPDATE</button>
                    <button onClick={()=> {if(window.confirm('Are you sure delete this event?')) deleteEvent(event.id)}} className='btn btn-secondary btn-lg'>DELETE</button>
                     
                     </td>
                    </tr> 
                ))}
              </tbody>
              </table>
              <button onClick={()=> setEvents([])} className="btn btn-dark btn-lg w-100">Empy React event array</button>
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

function onEventUpdate(updateEvent)
{
  setEventCurrentlyBegingUpdated(null);

  if(updateEvent === null){
    return;
  }

  let eventsCopy= [...events];

  const index = eventsCopy.findIndex((eventsCopyEvent,currentIndex) =>{
    if(eventsCopyEvent.eventId === updateEvent.eventId) {
      return true;
    }
  });

  if(index !== -1){
    eventsCopy[index] = updateEvent;
  }
  setEvents(eventsCopy);

  alert (`Event updated`)
}
function onEventDelete(deleteEventEventId)
{
  let eventsCopy = [...events];
  
  const index = eventsCopy.findIndex((eventsCopyEvent,currentIndex) =>{
    if(eventsCopyEvent.eventId === deleteEventEventId) {
      return true;
    }
  });

  if(index !== -1){
    eventsCopy.splice(index,1);
  }
  setEvents(eventsCopy);

  alert (`Event successful delete`);
}  
}

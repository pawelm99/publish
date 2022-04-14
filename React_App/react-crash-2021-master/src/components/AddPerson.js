import { useState } from 'react'
import { useEffect, useRef } from "react";
import $ from "jquery";
import "../components/styless.css";
import "jquery-nice-select/css/style.css";

window.jQuery = window.$ = $;
require("jquery-nice-select");


  const AddPerson = ({ onAdd }) => {
    const [name, setName] = useState('')
    const [height, setHeight] = useState('')
    const [mass, setMass] = useState('')
    var [eye_color, setEye] = useState('')
    var [gender, setGender] = useState('')

    

    const selectRef = useRef();
    const selectRef2 = useRef();
    useEffect(() => {
      $(selectRef.current).niceSelect();
      $(selectRef2.current).niceSelect();
    }, []);

    

  


  const onSubmit = (e) => {
    e.preventDefault()
    let selected = $(selectRef.current).val();
    let selected2 = $(selectRef2.current).val();
    eye_color = selected;
    gender = selected2;

    if (!name) {
      alert('Please add a person')
      return
    }
    if (!eye_color) {
      alert('Please add a eye')
      return
    }

    onAdd({ name, height, mass, eye_color, gender })

    setName('')
    setHeight(0)
    setMass(0)
    setEye('')
    setGender('')

  }

  



  return (
    
    <form className='add-form' onSubmit={onSubmit}>
      <div className='form-control'>
        <label>Name</label>
        <input
          type='text'
          placeholder='Add Person'
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
      </div>
      <div className='form-control'>
        <label>Height</label>
        <input
          type='text'
          placeholder='Add Height'
          value={height}
          onChange={(e) => setHeight(e.target.value)}
        />
      </div>
      <div className='form-control'>
        <label>Mass</label>
        <input
          type='text'
          placeholder='Add Mass'
          value={mass}
          onChange={(e) => setMass(e.target.value)}
        />
      </div>

      <div className="form-control" onSubmit={onSubmit}>
    
      
      <label>Color</label>
        <select ref = {selectRef} className='wide'
       
         onClick={(e)=> setEye(e.target.value)}>
        <option value="blue">Blue</option>
        <option value="yellow">Yellow</option>
        <option value="brown">Brown</option>
        </select> 
       
      </div>
      
    <div className="form-control">
   
      
        <label>Gender</label>
        <select  ref = {selectRef2}
        value={gender} className="wide"
         onChange={(e)=> setGender(e.target.value)}>
        <option value="male">Male</option>
        <option value="female">Female</option>
        <option selected value="male">Male</option>
        </select> 
        
     
    
       

            
      </div>
      
      <input type='submit' value='Save Character' className='btn btn-block' />
    </form>
  )
}

export default AddPerson

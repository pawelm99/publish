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
    const [eye_color, setEye] = useState('')
    const [gender, setGender] = useState('')

    
  const onSubmit = (e) => {
    e.preventDefault()

    if (!name) {
      alert('Please add a person')
      return
    }

    onAdd({ name, height, mass, eye_color, gender })

    setName('')
    setHeight(0)
    setMass(0)
    setEye('')
    setGender('')
  }

  const selectRef = useRef();
  useEffect(() => {
    $(selectRef.current).niceSelect();
  }, []);

  const selectRef2 = useRef();
  useEffect(() => {
    $(selectRef2.current).niceSelect();
  }, []);
  



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

      <div className="App">
      <form onSubmit={onSubmit}>
        <p>
      <label>Color</label>
        <select ref={selectRef} className='wide'
        value={eye_color}
         onChange={(e)=> setEye(e.target.value)}>
        <option value="blue">Blue</option>
        <option value="yellow">Yellow</option>
        <option value="brown">Brown</option>
        <option selected value="brown">Brown</option>
        </select> 
        </p>
      </form>
      </div>
      
    <div className="App">
      <form onSubmit={onSubmit}>
        <p>
      
        <label>Gender</label>
        <select  ref={selectRef2}
        value={gender} className="wide"
         onChange={(e)=> setGender(e.target.value)}>
        <option value="male">Male</option>
        <option value="female">Female</option>
        <option selected value="male">Male</option>
        </select> 
        
        </p>
        </form>
        
    
       

            
      </div>
      
      <input type='submit' value='Save Character' className='btn btn-block' />
    </form>
  )
}

export default AddPerson

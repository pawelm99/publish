//import 'bootstrap/dist/css/bootstrap.css'
import {Nav, Navbar, NavDropdown} from 'react-bootstrap'
import NavbarToggle from 'react-bootstrap/esm/NavbarToggle';
  import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import React from 'react'
import './index.css';

import Home from './Home';
import Event from './Event';
import Login from './Login';
export default function App(){
return(
  <Router>
  <div className="App">
    <Navbar bg='dark' variant='dark' sticky='top' expand="lg">
      <Navbar.Brand>
         App
      </Navbar.Brand>

      <Navbar.Toggle/>
      <Navbar.Collapse>

     
    
      <Nav>
        <NavDropdown title ="Products">
          <NavDropdown.Item href="products/tea">Tea</NavDropdown.Item>
        </NavDropdown>
        <Nav.Link as={Link} to={"/Home"} href  >Home</Nav.Link>
        <Nav.Link as={Link} to={"/Event"}href = "Event">Event</Nav.Link>
        <Nav.Link as={Link} to={"/Login"}href = "Login">Login</Nav.Link>
      </Nav>

      </Navbar.Collapse>

    </Navbar>

  </div>
  <div>
  <Routes>
  <Route path="/Home" element={<Home />} />
  <Route path="/Event" element={<Event />} />
  <Route path="/Login" element={<Login />} />
   
    
  </Routes>
  </div>
    </Router>
);
}



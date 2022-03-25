//import 'bootstrap/dist/css/bootstrap.css'
import {Nav, Navbar, NavDropdown} from 'react-bootstrap'
import NavbarToggle from 'react-bootstrap/esm/NavbarToggle';
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";

import Home from './Home';
import Event from './Event';
export default function App(){
return(
  <Router>
  <div className="App">
    <Navbar bg='dark' variant='dark' sticky='top' expand="lg">
      <Navbar.Brand>
         Apps
      </Navbar.Brand>

      <Navbar.Toggle/>
      <Navbar.Collapse>

     
    
      <Nav>
        <NavDropdown title ="Products">
          <NavDropdown.Item href="products/tea">Tea</NavDropdown.Item>
        </NavDropdown>
        <Nav.Link as={Link} to={"/Home"} href  >Home</Nav.Link>
        <Nav.Link as={Link} to={"/AppOk"}href = "Event">Event</Nav.Link>
      </Nav>

      </Navbar.Collapse>

    </Navbar>

  </div>
  <div>
  <Routes>
  <Route path="/Home" element={<Home />} />
  <Route path="/AppOk" element={<Event />} />

   
    
  </Routes>
  </div>
    </Router>
);
}



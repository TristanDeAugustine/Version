import React, { Component } from 'react'
import Cal from '../images/Calendar.jpg'
import Jour from '../images/Journal.jpg'
import Tas from '../images/List.jpg'
import '../index.css'
import Journal from './Journal.jsx'
import Tasks from './Tasks.jsx'
// import Calendar from "./Calendar.jsx";
import { BrowserRouter as Router, Route, Switch, Link } from 'react-router-dom'

const Homepage = () => {
  return (
    <div class="container">
      <div class="topnav">
        <Link className="Link-Journal" to="/Journal">
          <header className="edit-h1">Journal</header>
          {<img id="img1" className="img-icon" src={Jour}></img>}
        </Link>
        <Link className="Link-Calendar" to="/Calendar">
          <header className="edit-h1">Calendar</header>
          {<img id="img3" className="img-icon" src={Cal}></img>}
        </Link>
        <Link className="Link-Tasks" to="/Tasks">
          <header className="edit-h1">To-Do List</header>
          {<img id="img2" className="img-icon" src={Tas}></img>}
        </Link>
      </div>
    </div>
  )
}

export default Homepage

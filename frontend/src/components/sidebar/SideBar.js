import React, { useEffect, useState } from "react";
import "./SideBar.css";
import { Link } from "react-router-dom";

export default function SideBar() {
  const [user, setUser] = useState({id : 0});

  useEffect(() => {
    fetch("/users/me")
    .then(response => response.json())
    .then(user => setUser(user));
  }, [])
  
  return (
      <section className="side-bar">
          <span>
            <h1>C</h1>
          </span>
            {(user.id === 0) ? loginTab() : ""}
            {(user.id > 0) ? userTab(user) : ""}
            <Link to="/projects">
                <section>Projects</section>
            </Link>
            <Link to="/contact-info">
                <section>Contacts</section>
            </Link>
      </section>
  );
}

function userTab(user) {
  return (<Link to="/users/me">
  <section id={user.id} className="user">
    <img src="/images/user-icon.png" alt="image"/>
    <p>{user.userName}</p>
  </section>;
  </Link>)
}

function loginTab() {
  return (<Link to="/login">
    <section>Login</section>
  </Link>)
}
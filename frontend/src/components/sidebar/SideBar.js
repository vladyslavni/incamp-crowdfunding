import React, { useEffect, useState } from "react";
import "./SideBar.css";
import { UseFetch } from "../../utils/Fetch";
import { Link, useHistory } from "react-router-dom";

export default function SideBar() {
  const user = UseFetch(`/users/me`, {id: 0});
  
  return (
      <section className="side-bar">
          <span>
            <h1>C</h1>
          </span>
            {(user.id === 0) ? LoginTab() : UserTab(user) }
            <Link to="/projects">
                <section>Projects</section>
            </Link>
            <Link to="/contact-info">
                <section>Contacts</section>
            </Link>
      </section>
  );
}

function UserTab(user) {
  return <Link to="/users/me">
          <section id={user.id} className="user">
            <img src="/images/user-icon.png" alt="image"/>
            <p>{user.userName}</p>
          </section>
        </Link>
}

function LoginTab() {
  return <Link to="/login">
          <section>Login</section>
        </Link>
}

function LogoutTab() {
  const history = useHistory();

  function HandleLogout() {
    fetch("account/logout", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      }
    }).then(history.push('login'))
  }

  return <section onClick={HandleLogout}>Logout</section>
}
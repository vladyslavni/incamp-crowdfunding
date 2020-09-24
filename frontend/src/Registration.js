import React, { useState } from "react";
// import "./Login.css";

export default function Login() {
  const sha1 = require('sha1');
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [password, setPassword] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");

  function validateForm() {
    return username.length && email.length && phoneNumber.length 
            && password.length && firstName.length && lastName.length;
  }

  function hashPassword(password)
  {
    return "$AQAAAAEAACcQAAAAEMkS9uMeF7f8HmgowkmNyE68OxWLlEUTFBlWnzu6zUAxdDRbRCvcF5+EVf9QohFj1w=="
    // return sha1(password, 5, "myHash"); 
  }

  const host = "http://localhost:5000/api"
  function handleSubmit(event) {
    event.preventDefault();

    let registrationDto = {UserName : username, 
                          Email : email, 
                          PhoneNumber : phoneNumber, 
                          PasswordHash : hashPassword(password), 
                          FirstName : firstName, 
                          LastName : lastName};

    fetch(host + "/account/registration", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(registrationDto)
    }).then(response => console.log(response.ok));
  }

  return (
    <section className="Register">
      <form onSubmit={handleSubmit}>
            <label>
                Username
                <input autoFocus type="text" value={username} onChange={e => setUsername(e.target.value)}/>
            </label>
            <label>
                Email
                <input type="email" value={email} onChange={e => setEmail(e.target.value)}/>
            </label>
            <label>
                Phone number
                <input type="text" value={phoneNumber} onChange={e => setPhoneNumber(e.target.value)}/>
            </label>
            <label>
                Password
                <input value={password} onChange={e => setPassword(e.target.value)} type="password" />
            </label>
            <label>
                First Name
                <input type="text" value={firstName} onChange={e => setFirstName(e.target.value)}/>
            </label>
            <label>
                Last Name
                <input type="text" value={lastName} onChange={e => setLastName(e.target.value)}/>
            </label>
            <button disabled={!validateForm()} type="submit">SignUp</button>
      </form>
    </section>
  );
}
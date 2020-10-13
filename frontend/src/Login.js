import React, { useState } from "react";
import { useHistory } from "react-router-dom";

function Login() {
  const [username, setUsername] = useState("Lonli");
  const [password, setPassword] = useState("$AQAAAAEAACcQAAAAEMkS9uMeF7f8HmgowkmNyE68OxWLlEUTFBlWnzu6zUAxdDRbRCvcF5+EVf9QohFj1w==");
  const history = useHistory();

  function validateForm() {
    return username.length > 0 && password.length > 0;
  }
  
  function handleSubmit(event) {
    event.preventDefault();
    
    let loginDto = {Login : username, PasswordHash : password};
    fetch("/account/login", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(loginDto)
    })
    .then(history.push("/users/me"))
  }

  return (
    <section className="Login">
      <form onSubmit={handleSubmit}>
            <label>
                Username, Email, Phone number
                <input autoFocus type="text" value={username} onChange={e => setUsername(e.target.value)}/>
            </label>
            <label>
                Password
                <input value={password} onChange={e => setPassword(e.target.value)} type="password" />
            </label>
            <button disabled={!validateForm()} type="submit">Login</button>
      </form>
    </section>
  );
}

export default Login;
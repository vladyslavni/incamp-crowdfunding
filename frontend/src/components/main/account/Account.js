import React, { useEffect, useState } from "react";
import { InvestmentList } from '../investments/InvestmentList'
import "./Account.css";

function Account(props) {
  const [account, setAccount] = useState({id: 0});

  useEffect(() => {
    fetch(`/users/${props.match.params.id}`)
    .then(response => response.json())
    .then(account => setAccount(account));
  }, [])

  return (
    <section className="account">
      <section id={account.id} className="user">
        <img src="/images/user-icon.png" alt="image"/>
        <section className="info-block">
          <p className="full-name">{account.firstName} {account.lastName}</p>
          <p className="email">Email: {account.email}</p>
        </section>
      </section>
      <InvestmentList path="users" id={account.id}/>
    </section>
  );
}

export default Account;
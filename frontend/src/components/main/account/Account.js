import React, { useEffect, useState } from "react";
import { InvestmentList } from '../investments/InvestmentList'
import "./Account.css";
import { UseFetch } from "../../../utils/Fetch";

function Account(props) {
  const account = UseFetch(`/users/${props.match.params.id}`, {id: 0});
  
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
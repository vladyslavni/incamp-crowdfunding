import React, { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { UseFetch } from "../../../utils/Fetch";
import "./InvestmentList.css";

export function InvestmentList(props) {
  const investments = UseFetch(`/${props.path}/${props.id}/investments`, []);
  
  return (
    <section className="investment-panel">
      <h2>Investments</h2>
      <section className="investment-list-panel">
        {investments.map(investment => InvestmentItem({investment}, props.path))}
      </section>
    </section>
  );
}

function InvestmentItem(props, path) {

  const {investmentId, projectName, projectId, userName, userId, investmentAmount} = props.investment;
  const history = useHistory();

  function HandleClick() {
    let redirectPath = path === 'projects' ? `/users/${userId}` : `/projects/${projectId}`;
    history.push(redirectPath);
  }

  return <section id={investmentId} onClick={HandleClick}>
            <img src={path === 'projects' ? "/images/user-icon.png" : "/images/project-icon.png"} alt="image"/>
            <p>{path === 'projects' ? userName : projectName}</p>
            <p>{investmentAmount}</p>
          </section>;
}
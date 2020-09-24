import React, { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import "./InvestmentList.css";

export function InvestmentList(props) {

  const [investments, setInvestments] = useState([]);
  
  useEffect(() => {
    fetch(`/${props.path}/${props.id}/investments`)
    .then(response => response.json())
    .then(investments => setInvestments(investments));
  }, [props.path, props.id])
  
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
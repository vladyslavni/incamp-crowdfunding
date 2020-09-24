import React, { useState, useEffect } from "react";
import { InvestmentList } from '../investments/InvestmentList'
// import { UseFetch } from "../../../utils/Fetch";
import "./Project.css";

function Project(props) {
  const [project, setProject] = useState({id: 0});

  const host = "http://localhost:5000/api";

  useEffect(() =>{
      fetch(host + `/projects/${props.match.params.id}`)
          .then(response => response.json())
          .then(project => setProject(project));
  }, [])

  function HandleInvestClick() {
    // let amount = {Amount : 250};
    // fetch(host + `/projects/${props.match.params.id}/investments`, {
    //   method: 'POST',
    //   headers: {
    //       'Content-Type': 'application/json'
    //   },
    //   body: JSON.stringify(amount)
    // })
  }

  return  (<section className="project-page">
            <section id={project.id} className="project">
              <section className="info-block">
                <h2 className="name">{project.name}</h2>
                <p>Description:</p>
                <p className="description">{project.description}</p>
              </section>
              <section className="project-image-block">
                <img src="/images/project-icon.png" alt="image"/>
                <progress value={project.collectedMoney} max={project.goal}></progress>
                <button>Invest</button>
              </section>
            </section>
            <InvestmentList path="projects" id={project.id}/>
          </section>)
}

export default Project;
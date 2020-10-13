import React, { useEffect, useState } from "react";
import "./ProjectListPage.css";
import { UseFetch } from "../../../utils/Fetch";
import { BrowserRouter as Router, Link } from "react-router-dom";

export default function ProjectListPage() {
  const projects = UseFetch(`/projects`, []);

  return (
    <section>
      <section className="project-list-title">Projects</section>
      <section className="project-list">
        {projects.map(project => ProjectItem({project}))}
      </section>
    </section>
  );
}

function ProjectItem(props) {
  const {id, name, description, goal, collectedMoney} = props.project;
  
  return  <section id={id} className="project">
            <section className="project-image-block">
              <img src="/images/project-icon.png" alt="image"/>
              <progress className="progress-bar" value={collectedMoney} max={goal}></progress>
            </section>
            <section className="info-block">
              <h2 className="name">{name}</h2>
              <p>Description:</p>
              <p className="description">{description}</p>
              <Link to={"/projects/" + id}>Read more</Link>
            </section>
          </section>
}
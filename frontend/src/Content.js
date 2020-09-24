import React from "react";
import { Switch, Route } from 'react-router-dom'
import Account from './components/main/account/Account';
import ProjectListPage from './components/main/project/ProjectListPage';
import Project from './components/main/project/Project';
import Login from './Login'

export default function Content() {
    return (
            <Switch>
                <Route path="/login" component={Login} />
                <Route path="/users/:id" component={Account} />
                <Route exact path="/projects/:id" component={Project} />
                <Route path="/projects">
                    <ProjectListPage />
                </Route>
            </Switch>
    )
}
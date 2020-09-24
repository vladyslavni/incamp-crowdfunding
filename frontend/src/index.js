import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import * as serviceWorker from './serviceWorker';
import { BrowserRouter as Router, Switch, Route, Link} from "react-router-dom";
import SideBar from './components/sidebar/SideBar';
import Content from './Content'
import Footer from './components/footer/Footer';

ReactDOM.render(
  <React.StrictMode>
    <Router>
      <SideBar />
      <main>
        <Content />
      </main>
      <Footer />
    </Router>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();

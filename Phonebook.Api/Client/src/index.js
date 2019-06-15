import React from "react";
import ReactDOM from "react-dom";
import { Router, Switch, Route } from "react-router-dom";
import { createBrowserHistory } from "history";
import Header from "./components/Header";
import App from "./components/App";
import AddContact from "./components/AddContact";
import "./css/style.css";

ReactDOM.render(
  <Router history={createBrowserHistory()}>
    <Switch>
      <Route
        exact
        path="/"
        render={() => (
          <Header>
            <App />
          </Header>
        )}
      />
      <Route
        path="/add"
        render={() => (
          <Header>
            <AddContact />
          </Header>
        )}
      />
    </Switch>
  </Router>,
  document.getElementById("root")
);

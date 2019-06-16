import React from "react";
import ReactDOM from "react-dom";
import { Router, Switch, Route } from "react-router-dom";
import { createBrowserHistory } from "history";
import Header from "./components/Header";
import App from "./components/App";
import AddContact from "./components/AddContact";
import "./css/style.css";

const history = createBrowserHistory();

ReactDOM.render(
  <Router history={history}>
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
            <AddContact history={history} />
          </Header>
        )}
      />
    </Switch>
  </Router>,
  document.getElementById("root")
);

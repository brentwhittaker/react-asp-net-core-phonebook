import React from "react";
import { Link } from "react-router-dom";

const Header = ({ children }) => {
  return (
    <div className="container">
      <header className="header">
        <h1 className="heading__h1">Phonebook App</h1>
        <h3 className="heading__h3">
          <Link to="/">Home</Link>
        </h3>
        <h3 className="heading__h3">
          <Link to="/add">Add Contact</Link>
        </h3>
      </header>
      {children}
    </div>
  );
};

export default Header;

import React from "react";
import { Link } from "react-router-dom";

const Header = ({ children }) => {
  return (
    <div>
      <div>
        <h1>Phonebook App</h1>
        <h3>
          <Link to="/">Home</Link>
        </h3>
        <h3>
          <Link to="/add">Add Contact</Link>
        </h3>
      </div>
      {children}
    </div>
  );
};

export default Header;

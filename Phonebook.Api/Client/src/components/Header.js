import React from "react";
import { Link } from "react-router-dom";

const Header = ({ children }) => {
  return (
    <div className="container">
      <header className="header">
        <h1 className="header__h1">Phonebook App</h1>
        <div>
          <h3 className="header__h3">
            <Link to="/" className="header__link">
              Home
            </Link>
          </h3>
          <h3 className="header__h3">
            <Link to="/add" className="header__link">
              Add Contact
            </Link>
          </h3>
        </div>
      </header>
      {children}
    </div>
  );
};

export default Header;

import React, { Component } from "react";

class Contacts extends Component {
  render() {
    const { entries, pageNo, totalPages } = this.props;
    return (
      <div>
        <ul>
          {entries.map(entry => {
            const { id, name, phoneNumber } = entry;
            return (
              <li key={id}>
                <p>{name}</p>
                <p>{phoneNumber}</p>
              </li>
            );
          })}
        </ul>
        <button>Prev</button>
        <p>
          Page {pageNo} of {totalPages}
        </p>
        <button>Next</button>
      </div>
    );
  }
}

export default Contacts;

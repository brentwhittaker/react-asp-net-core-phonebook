import React, { Component } from "react";

class Contacts extends Component {
  pagePrev = () => {
    if (this.props.pageNo > 1) {
      var p = this.props.pageNo - 1;
      this.pageContacts(p);
    }
  };

  pageNext = () => {
    if (this.props.pageNo < this.props.totalPages) {
      var p = this.props.pageNo + 1;
      this.pageContacts(p);
    }
  };

  pageContacts = p => {
    const { searchTerm } = this.props;
    this.props.fetchContacts(searchTerm, p);
  };

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
        <button onClick={this.pagePrev}>Prev</button>
        <p>
          Page {pageNo} of {totalPages}
        </p>
        <button onClick={this.pageNext}>Next</button>
      </div>
    );
  }
}

export default Contacts;

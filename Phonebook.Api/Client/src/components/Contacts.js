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
      <div className="contact">
        <ul className="contact__list">
          {entries.map(entry => {
            const { id, name, phoneNumber } = entry;
            return (
              <li key={id} className="contact__item">
                <p className="contact__name">{name}</p>
                <p className="contact__number">{phoneNumber}</p>
              </li>
            );
          })}
        </ul>
        <hr className="form-line" />
        <div className="pager">
          <button onClick={this.pagePrev} className="pager__btn btn btn-small">
            Prev
          </button>
          <p className="pager__text">
            Page {pageNo} of {totalPages}
          </p>
          <button onClick={this.pageNext} className="pager__btn btn btn-small">
            Next
          </button>
        </div>
      </div>
    );
  }
}

export default Contacts;

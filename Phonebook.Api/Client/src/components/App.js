import React, { Component } from "react";
import Search from "./Search";
import Contacts from "./Contacts";
import { API_ADDRESS, DEFAULT_PAGE_SIZE } from "../config/settings";

class App extends Component {
  state = {
    entries: [],
    pageNo: 1,
    totalPages: null,
    searchTerm: null
  };

  componentDidMount() {
    this.fetchContacts();
  }

  fetchContacts = (searchTerm, pageNo) => {
    let address = `${API_ADDRESS}/contacts`;
    let hasParams = false;
    if (searchTerm !== undefined && searchTerm !== null && searchTerm !== "") {
      if (!hasParams) {
        address += "?";
        hasParams = true;
      } else {
        address += "&";
      }
      address += `searchTerm=${searchTerm}`;
    }
    if (pageNo !== undefined && pageNo !== null) {
      if (!hasParams) {
        address += "?";
        hasParams = true;
      } else {
        address += "&";
      }
      address += `pageNo=${pageNo}`;
    }
    if (DEFAULT_PAGE_SIZE !== undefined && DEFAULT_PAGE_SIZE !== null) {
      if (!hasParams) {
        address += "?";
        hasParams = true;
      } else {
        address += "&";
      }
      address += `pageSize=${DEFAULT_PAGE_SIZE}`;
    }
    fetch(address)
      .then(response => response.json())
      .then(json => {
        this.setState({ entries: json.entries });
        this.setState({ pageNo: json.pageNo });
        this.setState({ totalPages: json.totalPages });
        this.setState({ searchTerm: searchTerm });
      })
      .catch(error => alert(error.message));
  };

  render() {
    return (
      <section className="section">
        <Search fetchContacts={this.fetchContacts} pageNo={this.state.pageNo} />
        <Contacts
          fetchContacts={this.fetchContacts}
          entries={this.state.entries}
          pageNo={this.state.pageNo}
          totalPages={this.state.totalPages}
          searchTerm={this.state.searchTerm}
        />
      </section>
    );
  }
}

export default App;

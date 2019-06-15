import React, { Component } from "react";
import Search from "./Search";
import Contacts from "./Contacts";

const API_ADDRESS = "https://localhost:5001";
const defaultPageSize = 3;

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
    if (defaultPageSize !== undefined && defaultPageSize !== null) {
      if (!hasParams) {
        address += "?";
        hasParams = true;
      } else {
        address += "&";
      }
      address += `pageSize=${defaultPageSize}`;
    }
    fetch(address)
      .then(response => response.json())
      .then(json => {
        this.setState({ entries: json.entries });
        this.setState({ pageNo: json.pageNo });
        this.setState({ totalPages: json.totalPages });
        this.setState({ searchTerm: json.searchTerm });
      })
      .catch(error => alert(error.message));
  };

  render() {
    // console.log("this.state", this.state);
    return (
      <div>
        <h2>Phonebook App</h2>
        <button>Add Contact</button>
        <Search fetchContacts={this.fetchContacts} pageNo={this.state.pageNo} />
        <Contacts
          fetchContacts={this.fetchContacts}
          entries={this.state.entries}
          pageNo={this.state.pageNo}
          totalPages={this.state.totalPages}
          searchTerm={this.state.searchTerm}
        />
      </div>
    );
  }
}

export default App;

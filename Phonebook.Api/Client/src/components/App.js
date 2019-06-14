import React, { Component } from "react";
import Search from "./Search";
import Contacts from "./Contacts";

const API_ADDRESS = "https://localhost:5001";

class App extends Component {
  state = {
    entries: [],
    pageNo: null,
    totalPages: null,
    searchTerm: null
  };

  componentDidMount() {
    this.fetchContacts();
  }

  fetchContacts = () => {
    fetch(`${API_ADDRESS}/getbook`)
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
    console.log("this.state", this.state);
    return (
      <div>
        <h2>Phonebook App</h2>
        <button>Add Contact</button>
        <Search />
        <Contacts
          entries={this.state.entries}
          pageNo={this.state.pageNo}
          totalPages={this.state.totalPages}
        />
      </div>
    );
  }
}

export default App;

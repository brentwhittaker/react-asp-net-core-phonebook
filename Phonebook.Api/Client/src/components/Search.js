import React, { Component } from "react";

class Search extends Component {
  state = { searchTerm: null };

  updateSearchTerm = event => {
    this.setState({ searchTerm: event.target.value });
    if (event.target.value == "") {
      this.searchContacts();
    }
  };

  handlekeyPress = event => {
    if (event.key === "Enter") {
      this.searchContacts();
    }
  };

  searchContacts = () => {
    const { pageNo } = this.props;
    this.props.fetchContacts(this.state.searchTerm, pageNo);
  };
  render() {
    console.log("this.state", this.state);
    return (
      <div>
        <input
          onChange={this.updateSearchTerm}
          onKeyPress={this.handlekeyPress}
          placeholder="Search name or number"
        />
        <button onClick={this.searchContacts}>Search</button>
      </div>
    );
  }
}

export default Search;

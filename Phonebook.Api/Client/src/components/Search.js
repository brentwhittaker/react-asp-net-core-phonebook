import React, { Component } from "react";

class Search extends Component {
  state = { searchTerm: null };

  updateSearchTerm = event => {
    this.setState({ searchTerm: event.target.value });
    if (event.target.value == "") {
      const { pageNo } = this.props;
      this.props.fetchContacts(event.target.value, pageNo);
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
    return (
      <div className="search-contacts">
        <input
          onChange={this.updateSearchTerm}
          onKeyPress={this.handlekeyPress}
          placeholder="Search name or number"
          className="input input-search"
        />
        <button onClick={this.searchContacts} className="btn btn-small">
          Search
        </button>
      </div>
    );
  }
}

export default Search;

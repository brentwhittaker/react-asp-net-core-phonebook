import React, { Component } from "react";
import { API_ADDRESS } from "../config/settings";

class AddContact extends Component {
  state = { name: null, phoneNumber: null };

  saveContact = event => {
    event.preventDefault();
    const data = new FormData(event.target);

    fetch(`${API_ADDRESS}/save`, {
      method: "POST",
      body: data,
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json"
      }
    })
      .then(response => response.json())
      .then(json => {
        alert(json.message);
      })
      .catch(error => alert(error.message));
  };

  render() {
    return (
      <form onSubmit={this.saveContact}>
        <input name="name" placeholder="Name" />
        <input name="phoneNumber" placeholder="Phone number" />
        <button>Save</button>
      </form>
    );
  }
}

export default AddContact;

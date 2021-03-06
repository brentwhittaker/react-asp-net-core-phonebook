import React, { Component } from "react";
import { API_ADDRESS } from "../config/settings";

class AddContact extends Component {
  state = { name: null, phoneNumber: null };

  updateName = event => {
    this.setState({ name: event.target.value });
  };

  updatePhoneNumber = event => {
    this.setState({ phoneNumber: event.target.value });
  };

  saveContact = event => {
    event.preventDefault();
    const contact = {
      name: this.state.name,
      phoneNumber: this.state.phoneNumber
    };

    fetch(`${API_ADDRESS}/save`, {
      method: "POST",
      body: JSON.stringify(contact),
      headers: {
        "Content-Type": "application/json",
        accept: "application/json"
      }
    })
      .then(response => response.json())
      .then(json => {
        alert(json.message);
        if (json.code === 202) {
          let { history } = this.props;
          history.push({
            pathname: "/"
          });
        }
      })
      .catch(error => alert(error.message));
  };

  render() {
    return (
      <form onSubmit={this.saveContact} className="add-contact-form">
        <input
          name="name"
          placeholder="Name"
          onChange={this.updateName}
          className="input"
          required
        />
        <input
          type="tel"
          name="phoneNumber"
          placeholder="Phone number"
          onChange={this.updatePhoneNumber}
          className="input"
          required
        />
        <hr className="form-line" />
        <button className="btn">Save</button>
      </form>
    );
  }
}

export default AddContact;

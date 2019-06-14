import React, { Component } from "react";

class AddContact extends Component {
  render() {
    return (
      <div>
        <input placeholder="Name" />
        <input placeholder="Phone number" />
        <button>Cancel</button>
        <button>Save</button>
      </div>
    );
  }
}

export default AddContact;

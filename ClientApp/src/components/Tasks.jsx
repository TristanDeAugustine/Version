import React, { Component } from 'react'
import '../tasks.css'

class App extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      newItem: '',
      list: []
    }
  }
  updateInput(key, value) {
    // update react state
    this.setState({ [key]: value })
  }

  addItem(e) {
    e.preventDefault()
    // create a new item with unique id
    const newItem = {
      id: 1 + Math.random(),
      value: this.state.newItem.slice()
    }

    // copy current list of items
    const list = [...this.state.list]

    // add the new item to the list
    list.push(newItem)

    // update state with new list, reset the new item input
    this.setState({
      list,
      newItem: ''
    })
  }

  deleteItem(id) {
    // copy current list of items
    const list = [...this.state.list]
    // filter out the item being deleted
    const updatedList = list.filter(item => item.id !== id)

    this.setState({ list: updatedList })
  }

  render() {
    return (
      <div id="myDIV" class="header">
        <h1> MY LIST</h1>
        Add an Item...
        <br></br>
        <br></br>
        <form onSubmit={e => this.addItem(e)}>
          <input
            type="text"
            id="myInput"
            placeholder="Type item here"
            value={this.state.newItem}
            onChange={e => this.updateInput('newItem', e.target.value)}
          />
        </form>
        <br /> <br />
        <ul id="myUL">
          {this.state.list.map(item => {
            return (
              <li className="checked" key={item.id}>
                {item.value}
                <button
                  className="btn"
                  onClick={() => this.deleteItem(item.id)}
                >
                  <i className="material-icons">x</i>
                </button>
              </li>
            )
          })}
        </ul>
      </div>
    )
  }
}

export default App

import React, { Component } from 'react'
import '../journal.css'
import axios from 'axios'

class App extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      newItem: '',
      list: [],
      criticalClicker: false,
      normalClicker: false,
      infoClicker: false,
      clicker: ''
    }
  }
  componentDidMount() {
    axios.get('/api/Journal').then(resp => {
      console.log(resp)
    })
  }
  updateTextArea(key, value) {
    // update react state
    this.setState({ [key]: value })
  }

  updateClicker() {
    this.state.criticalClicker = true
  }

  addItem(e) {
    e.preventDefault()
    // create a new item with unique id
    const newItem = {
      id: 1 + Math.random(),
      value: this.state.newItem.slice(),
      level: this.state.clicker
    }
    axios.post('/api/Journal', newItem).then(resp => {
      console.log(resp)
    })

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

  // saveJournal = journal => {
  //   const data = { }
  // }

  render() {
    return (
      <div className="header-journal">
        <h1 className="h1"> Journal</h1>
        <header className="h2">What do you wish to record: </header>
        <br></br>
        <div className="journal-content">
          <form onSubmit={e => this.addItem(e)}>
            <textarea
              className="text-field"
              rows="10"
              type="text"
              id="myInput"
              value={this.state.newItem}
              onChange={e => this.updateTextArea('newItem', e.target.value)}
            />
            <div className="radio-button-container">
              <div className="radio-station">
                <input
                  onClick={() => this.setState({ clicker: 'critical' })}
                  type="radio"
                  name="color"
                  value="critical"
                />
                Critical
              </div>
              {console.log(this.state.criticalClicker)}
              <div className="radio-station-2">
                <input
                  type="radio"
                  name="color"
                  value="normal"
                  onClick={() => {
                    this.setState({ clicker: 'normal' })
                  }}
                />
                Normal
              </div>
              <div className="radio-station-3">
                <input
                  type="radio"
                  name="color"
                  value="info"
                  onClick={() => {
                    this.setState({ clicker: 'info' })
                  }}
                />
                Info
              </div>
            </div>
            <br></br>
            <input className="submit" type="submit" value="Submit"></input>
          </form>
        </div>
        <br /> <br />
        <ul className="journal-list">
          {this.state.list.map(item => {
            return (
              <li key={item.id} className={item.level}>
                {item.value}
              </li>
            )
          })}
        </ul>
      </div>
    )
  }
}

export default App

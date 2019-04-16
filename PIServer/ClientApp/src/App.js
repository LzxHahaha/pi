import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Home from './pages/home';
import { FetchData } from './pages/FetchData';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/air-conditioning' component={FetchData} />
      </Layout>
    );
  }
}

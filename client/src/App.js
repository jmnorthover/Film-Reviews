import React from 'react';
import MovieDetails from './Components/MovieDetails';
import SearchResults from './Components/SearchResults';
import Navbar from './Components/Navbar';
import Home from './Components/Home';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import './app.css';

function App() {
  return (
    <div className="container">
      <Router>
        <Navbar />
        <Switch>
          <Route exact path="/">
            <Home />
          </Route>
          <Route exact path="/search/:query">
            <SearchResults />
          </Route>
          <Route exact path="/movies/:movieId">
            <MovieDetails />
          </Route>
        </Switch>
      </Router>
    </div>
  );
}

export default App;

import React, { useState, useEffect } from 'react';
import { movieSearch } from '../Services/movieServices';
import { useParams } from 'react-router-dom';
import ResultCard from './ResultCard';
import './SearchResults.css';

const SearchResults = () => {
  const [results, setResults] = useState(null);

  const { query } = useParams();

  useEffect(() => {
    movieSearch(query).then((sResults) => {
      setResults(sResults.results);
    });
  }, [query]);

  return (
    <div className="search">
      <h1>Results for "{query}"</h1>
      <div className="results">
        {results &&
          results.map((result) => (
            <ResultCard details={result} key={result.id} />
          ))}
      </div>
    </div>
  );
};

export default SearchResults;

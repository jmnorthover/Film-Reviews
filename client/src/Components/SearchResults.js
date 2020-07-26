import React, { useState, useEffect } from 'react';
import { movieSearch } from '../Services/movieServices';
import { useParams } from 'react-router-dom';
import ResultCard from './ResultCard';
import './SearchResults.css';
import { Spin } from 'antd';

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
        {results ? (
          results.map((result) => (
            <ResultCard details={result} key={result.id} />
          ))
        ) : (
          <Spin size="large" />
        )}
      </div>
    </div>
  );
};

export default SearchResults;

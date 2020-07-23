import React from 'react';
import './ResultCard.css';
import { Link } from 'react-router-dom';

const ResultCard = ({ details }) => {
  return (
    <div className="result-card">
      <Link to={`/movies/${details.id}`}>
        {details.poster_Path && (
          <img
            src={`https://image.tmdb.org/t/p/w342/${details.poster_Path}`}
            alt={details.title}
          />
        )}
        <h2>{details.title}</h2>
        <div className="release-date">{details.release_Date}</div>
      </Link>
    </div>
  );
};

export default ResultCard;

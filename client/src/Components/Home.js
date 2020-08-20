import React from 'react';
import './Home.css';
import { Input } from 'antd';
import { useHistory } from 'react-router-dom';

const Home = () => {
  const handleSearch = (value) => {
    if (value) {
      history.replace(`/search/${value}`);
    }
  };

  const history = useHistory();

  return (
    <div className="home">
      <h1>Find and Review Your Favorite Films</h1>
      <div className="home-search">
        <Input.Search
          placeholder="Search for a film..."
          enterButton
          size="large"
          onSearch={handleSearch}
        />
      </div>
    </div>
  );
};

export default Home;

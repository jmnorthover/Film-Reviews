import React from 'react';
import './Navbar.css';
import { Input, Divider } from 'antd';
import { Link, useHistory } from 'react-router-dom';

const Navbar = () => {
  const handleSearch = value => {
    if (value) {
      history.replace(`/search/${value}`);
    }
  };

  const history = useHistory();

  console.log(history.location.pathname);

  return (
    <div>
      <nav className="navbar">
        <Link to="/">
          <div className="nav-logo">FILM REVIEWS</div>
        </Link>
        {history.location.pathname === '/' || (
          <div className="nav-search">
            <Input.Search
              placeholder="Search for a film"
              onSearch={handleSearch}
              style={{ width: 275 }}
            />
          </div>
        )}
      </nav>
      <Divider style={{ margin: 0 }} />
    </div>
  );
};

export default Navbar;

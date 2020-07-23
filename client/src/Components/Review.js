import React from 'react';
import './Review.css';
import { Rate } from 'antd';

const Review = ({ info }) => {
  return (
    <div className="review">
      <h3>Review by {info.author}</h3>
      <Rate allowHalf defaultValue={info.rating} disabled className="rating" />
      <div className="desc">"{info.description}"</div>
    </div>
  );
};

export default Review;

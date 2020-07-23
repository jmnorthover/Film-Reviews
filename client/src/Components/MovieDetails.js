import React, { useEffect, useState } from 'react';
import { getMovieDetails } from '../Services/movieServices';
import { getReviews } from '../Services/reviewServices';
import './MovieDetails.css';
import Review from './Review';
import { Button, Divider, Modal, Form, Input, Rate, message } from 'antd';
import { addReview } from '../Services/reviewServices';
import { useParams } from 'react-router-dom';

const MovieDetails = () => {
  const [movieInfo, setMovieInfo] = useState(null);
  const [reviews, setReviews] = useState([]);
  const [modalVisible, setModalVisible] = useState(false);

  const { movieId } = useParams();

  // Fetch movie info and reviews
  useEffect(() => {
    getMovieDetails(movieId).then((details) => {
      setMovieInfo(details);
    });

    getReviews(movieId).then((reviews) => {
      setReviews(reviews.sort((a, b) => b.reviewId - a.reviewId));
    });
  }, [movieId]);

  // Submit a new user review
  const submitReview = async (values) => {
    console.log(movieId);
    addReview(values, parseInt(movieId))
      .then(() => {
        setModalVisible(false);
        const newReview = {
          ...values,
          reviewId: reviews.length > 0 ? reviews[0].reviewId + 1 : 1,
        };
        setReviews([newReview].concat(reviews));
        message.success('Review added!');
      })
      .catch((error) => {
        message.error('Failed to add review');
      });
  };

  // render page contents once data has been fetched from API
  if (movieInfo && reviews) {
    return (
      <div className="details">
        <div className="description">
          <img
            alt="casino royale poster"
            src={`https://image.tmdb.org/t/p/w342/${movieInfo.poster_Path}`}
          />
          <div className="info">
            <h1>{movieInfo.title}</h1>
            <div className="tag">{movieInfo.tagline}</div>
            <div className="plot">{movieInfo.overview}</div>
          </div>
        </div>
        <Divider style={{ backgroundColor: '#9ab' }} />
        <div className="reviews">
          <div className="reviews-header">
            <h2>Reviews</h2>
            <Button type="primary" onClick={() => setModalVisible(true)}>
              Add Review
            </Button>
          </div>
          {reviews.length > 0 ? (
            reviews.map((review) => (
              <Review info={review} key={review.reviewId} />
            ))
          ) : (
            <div>No reviews added yet</div>
          )}
        </div>
        <Modal
          visible={modalVisible}
          onCancel={() => setModalVisible(false)}
          title="Add a review"
          footer={null}
        >
          <Form
            labelCol={{ span: 5 }}
            wrapperCol={{ span: 19 }}
            name="addReview"
            onFinish={submitReview}
          >
            <Form.Item
              label="Your name"
              name="author"
              rules={[{ required: true, message: 'Please enter a username' }]}
            >
              <Input />
            </Form.Item>
            <Form.Item
              label="Rating"
              name="rating"
              rules={[{ required: true, message: 'Please select a rating' }]}
            >
              <Rate allowHalf />
            </Form.Item>
            <Form.Item
              label="Details"
              name="description"
              rules={[{ required: true, message: 'Please enter your review' }]}
            >
              <Input.TextArea autoSize={{ minRows: 5, maxRows: 15 }} />
            </Form.Item>
            <Form.Item wrapperCol={{ offset: 5, span: 19 }}>
              <Button type="primary" htmlType="submit">
                Submit Review
              </Button>
            </Form.Item>
          </Form>
        </Modal>
      </div>
    );
  } else {
    return '';
  }
};

export default MovieDetails;

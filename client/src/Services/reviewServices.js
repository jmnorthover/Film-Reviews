const url = 'https://film-reviews-app.herokuapp.com';

export const getReviews = (movieId) => {
  return fetch(`${url}/api/reviews/${movieId}`).then((res) => res.json());
};

export const addReview = (reviewDetails, movieId) => {
  return fetch(`${url}/api/reviews`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({ movieId, ...reviewDetails }),
  }).then((response) => {
    if (!response.ok) {
      throw new Error('Failed to add review');
    }
  });
};

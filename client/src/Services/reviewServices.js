export const getReviews = (movieId) => {
  return fetch(`/api/reviews/${movieId}`).then((res) => res.json());
};

export const addReview = (reviewDetails, movieId) => {
  return fetch('/api/reviews', {
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

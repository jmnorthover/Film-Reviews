const url = 'https://film-reviews-app.herokuapp.com';

export const getMovieDetails = (movieId) => {
  return fetch(`${url}/api/movies/${movieId}`).then((res) => res.json());
};

export const movieSearch = (query) => {
  return fetch(`${url}/api/movies/search/${query}`).then((res) => res.json());
};

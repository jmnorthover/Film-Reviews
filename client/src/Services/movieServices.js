export const getMovieDetails = (movieId) => {
  return fetch(`/api/movies/${movieId}`).then((res) => res.json());
};

export const movieSearch = (query) => {
  return fetch(`/api/movies/search/${query}`).then((res) => res.json());
};

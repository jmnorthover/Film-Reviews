export const getMovieDetails = (movieId) => {
  return fetch(`http://localhost:5000/api/movies/${movieId}`).then((res) =>
    res.json(),
  );
};

export const movieSearch = (query) => {
  return fetch(`http://localhost:5000/api/movies/search/${query}`).then((res) =>
    res.json(),
  );
};

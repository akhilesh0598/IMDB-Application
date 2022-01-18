<template>
  <Row>
    <Col
      :xs="{ span: 24 }"
      :sm="{ span: 24 }"
      :md="{ span: 8 }"
      v-for="movie in movies"
      :key="movie.id"
    >
      <movie
        :movieId="movie.id"
        :movieName="movie.name"
        :movieReleaseDate="movie.yearOfRelease"
        :moviePlot="movie.plot"
        :movieProducer="movie.producer"
        :movieActors="movie.actors"
        :movieGenres="movie.genres"
        :movieImageUrl="movie.imageUrl"
      >
      </movie>
    </Col>
  </Row>
</template>
<script>
import Movie from "../components/Movie.vue";
import Vue from "vue";
import VueAxios from "vue-axios";
import Axios from "axios";
import { getMovies } from "../js/ApiCalls.js";
Vue.use(VueAxios, Axios);

export default {
  name: "MovieList",
  components: {
    Movie,
  },
  data: function () {
    return {
      movies: [],
    };
  },
  mounted: function () {
    getMovies().then((response) => {
      this.movies = response.data;
    });
  },
};
</script>

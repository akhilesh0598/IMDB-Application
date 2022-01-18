import Vue from "vue";
import VueAxios from "vue-axios";
import Axios from "axios";
Vue.use(VueAxios, Axios);
const axios = require('axios');

export const addActor = async function (actor) {
    return Axios.post("https://localhost:44363/api/Actors", actor).then(
        (response) => {
            return response;
        }
    );
}
export const addProducer = async function (producer) {
    return Axios.post(
        "https://localhost:44363/api/Producers",
        producer
    ).then((response) => {
        return response;
    });
}
export const updateMovie = async function (movieId, movie) {
    return Axios.put(
        "https://localhost:44363/api/Movies/" + movieId,
        movie
    ).then((response) => {
        return response;
    });
}
export const getMovie = async function (movieId) {
    return Axios.get("https://localhost:44363/api/Movies/" + movieId).then(
        (response) => {
            return response;
        }
    );
}
export const addMovie = async function (movie) {
    return Axios.post("https://localhost:44363/api/Movies", movie).then(
        (response) => {
            return response;
        }
    );
}

export const deleteMovie = async function (movieId) {
    return Axios.delete("https://localhost:44363/api/Movies/" + movieId).then(
        (response) => {
            return response;
        }
    );
}
export const getMovies = async function () {
    return Axios.get("https://localhost:44363/api/Movies").then((response) => {
        return response;
    })
}
export const getProducers = async function () {
    return Axios.get("https://localhost:44363/api/Producers").then((response) => {
        return response;
    });
}
export const getActors = async function () {

    return Axios.get('https://localhost:44363/api/Actors').then(response => {
        return response;
    });
}
export const getGenres = async function () {
    return Axios.get("https://localhost:44363/api/Genres").then(response => {
        return response;
    });
}

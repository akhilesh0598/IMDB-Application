import Vue from 'vue'
import VueRouter from 'vue-router'

import MovieList from '../views/MovieList.vue';
import ActorList from '../views/ActorList.vue';
import ProducerList from '../views/ProducerList.vue';
import EditMovie from "../components/EditMovie.vue";
import AddMovie from "../components/AddMovie.vue";


Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'MovieList',
    component: MovieList,
  },
  {
    path: '/actorList',
    name: 'ActorList',
    component: ActorList,
  },
  {
    path: '/producerList',
    name: 'ProducerList',
    component: ProducerList,
  },
  {
    path: '/editMovie/:movieId',
    name: 'EditMovie',
    component: EditMovie,
  },
  {
    path: '/addMovie',
    name: 'AddMovie',
    component: AddMovie,
  },


]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router

<template>
  <Row class="movieCard">
    <Col :span="24">
      <Row>
        <Col :span="24" class="movieTitle">
          <h2>{{ movieName }}</h2>
        </Col>
      </Row>

      <Row>
        <Col :span="24" class="movieImage">
          <img :src="movieImageUrl" alt="movieImage" id="movieImage" />
        </Col>
      </Row>
      <Row class="movieButtons">
        <Col :span="24">
          <Row>
            <Col :span="8">
              <Button type="primary" @click="GoToEdit()">Edit</Button>
            </Col>
            <Col :span="8">
              <Button type="error" @click="Delete()">Delete</Button>
            </Col>
            <Col :span="8">
              <Button type="warning" @click="movieModel = true">Details</Button>

              <Modal v-model="movieModel" :footer-hide="true">
                <div slot="header" id="movieModelHeader">
                  <H2>{{ movieName }} Details</H2>
                </div>
                <Row class="row">
                  <Col :span="8">
                    <Label>Name:</Label>
                  </Col>
                  <Col :span="16">
                    {{ movieName }}
                  </Col>
                </Row>
                <Row class="row">
                  <Col :span="8">
                    <Label>Release Date:</Label>
                  </Col>
                  <Col :span="16">
                    {{ movieReleaseDate }}
                  </Col>
                </Row>
                <Row class="row">
                  <Col :span="8">
                    <Label>Plot:</Label>
                  </Col>
                  <Col :span="16">
                    {{ moviePlot }}
                  </Col>
                </Row>
                <Row class="row">
                  <Col :span="8">
                    <Label>Producer:</Label>
                  </Col>
                  <Col :span="16">
                    {{ movieProducer.name }}
                  </Col>
                </Row>
                <Row class="row">
                  <Col :span="8">
                    <Label>Actors:</Label>
                  </Col>
                  <Col :span="16">
                    <Label
                      v-for="actor in movieActors"
                      :key="actor.id"
                      id="movieModelActors"
                      >{{ actor.name }}</Label
                    >
                  </Col>
                </Row>
                <Row class="row">
                  <Col :span="8">
                    <Label>Genres:</Label>
                  </Col>
                  <Col :span="16">
                    <Label
                      v-for="genre in movieGenres"
                      :key="genre.id"
                      id="movieModelGenres"
                      >{{ genre.name }}</Label
                    >
                  </Col>
                </Row>
                <Hr id="horizontalLine"></Hr>
                <Row class="row" id="buttonRow">
                  <Col :span="24">
                    <Button type="warning" @click="movieModel = false"
                      >Ok</Button
                    >
                  </Col>
                </Row>
              </Modal>
            </Col>
          </Row>
        </Col>
      </Row>
    </Col>
  </Row>
</template>
<script>
import Vue from "vue";
import VueAxios from "vue-axios";
import Axios from "axios";
import { deleteMovie } from "../js/ApiCalls.js";

Vue.use(VueAxios, Axios);

export default {
  name: "Movie",
  data: function () {
    return {
      movieModel: false,
    };
  },
  props: [
    "movieId",
    "movieName",
    "movieReleaseDate",
    "moviePlot",
    "movieProducer",
    "movieActors",
    "movieGenres",
    "movieImageUrl",
  ],
  methods: {
    GoToEdit() {
      this.$router.push("editMovie/" + this.movieId);
    },

    Delete() {
      deleteMovie(this.movieId).then((response) => {
        alert("Deleted Successfully!");
        location.reload();
      });
    },
    Details() {
      this.movieModel = true;
    },
  },
};
</script>
<style scoped>
.movieTitle {
  padding: auto;
  margin: auto;
  padding-top: 5px;
  padding-bottom: 10px;
}
.movieButtons {
  margin: auto;
  padding: auto;
  padding-top: 7px;
  padding-bottom: 10px;
}
#movieModelHeader {
  text-align: center;
  color: green;
}
.movieCard {
  border: 3px solid maroon;
  margin: auto;
  padding: auto;
  margin-top: 10px;
  margin-bottom: 10px;
  border-radius: 10px;
  width: 70%;
  background: mediumaquamarine;
}
.row {
  margin-top: 20px;
}
#horizontalLine {
  margin-top: 30px;
}
#movieImage {
  height: 350px;
  width: 100%;
  margin: auto;
}
#movieModelGenres {
  margin-right: 5px;
  padding-right: 10px;
}
#movieModelActors {
  margin-right: 5px;
  padding-right: 10px;
}
#buttonRow {
  text-align: right;
}
</style>

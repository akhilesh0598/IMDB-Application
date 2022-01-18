<template>
  <div>
    <Div id="actorHeading">
      <H2 id="actorHeadingTitle"> All Actor </H2>
    </Div>
    <Row class="actorRow">
      <Col :xs="{ span: 24 }" :md="{ span: 12, offset: 6 }" class="actorCol">
        <Row class="conentRow">
          <Col :span="6" class="leftPart">
            <H3>Index</H3>
          </Col>
          <Col :span="14" class="middle"> Actor Name </Col>
          <Col :span="4" class="rightPart"> Detail Button </Col>
        </Row>
      </Col>
    </Row>
    <div v-for="(actor, index) in actors" :key="actor.id">
      <Person
        :personIndex="index"
        :personName="actor.name"
        :personDOB="actor.dob"
        :personBio="actor.bio"
        :personGender="actor.gender"
      >
      </Person>
    </div>
  </div>
</template>
<script>
import Person from "../components/Person.vue";
import Vue from "vue";
import VueAxios from "vue-axios";
import Axios from "axios";
import { getActors } from "../js/ApiCalls.js";
Vue.use(VueAxios, Axios);

export default {
  name: "ActorList",
  data: function () {
    return {
      actors: [],
    };
  },
  components: {
    Person,
  },
  mounted() {
    getActors().then((response) => {
      this.actors = response.data;
    });
  },
};
</script>
<style scoped>
#actorHeading {
  margin: auto;
  margin-top: 10px;
  text-align: center;
  padding-top: 10px;
  padding-bottom: 10px;
  background: rgb(10, 150, 231);
}
#actorHeadingTitle {
  color: rgb(22, 18, 17);
}
.actorRow {
  margin-left: auto;
  margin-right: auto;
  margin-top: 20px;
  margin-bottom: 20px;
  padding: 10px;
  background: lightblue;
  border-radius: 10px;
}
.actorCol {
  background: rgb(42, 7, 240);
  border: 2px solid maroon;
  border-radius: 5px;
}
.conentRow {
  margin-top: 5px;
  margin-bottom: 5px;
  color: gold;
}
.leftPart {
  text-align: left;
  padding-left: 50px;
}
.middle {
  text-align: left;
  padding-left: 40px;
}
.rightPart {
  text-align: right;
  padding-right: 5px;
}
</style>

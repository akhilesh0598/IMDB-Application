<template>
  <div>
    <Div id="producerHeading">
      <H2 id="producerHeadingTitle"> All Producer </H2>
    </Div>
    <Row class="producerRow">
      <Col :xs="{ span: 24 }" :md="{ span: 12, offset: 6 }" class="producerCol">
        <Row class="conentRow">
          <Col :span="6" class="leftPart">
            <H3>Index</H3>
          </Col>
          <Col :span="14" class="middle"> Producer Name </Col>
          <Col :span="4" class="rightPart"> Detail Button </Col>
        </Row>
      </Col>
    </Row>
    <div v-for="(producer, index) in producers" :key="producer.id">
      <Person
        :personIndex="index"
        :personName="producer.name"
        :personDOB="producer.dob"
        :personBio="producer.bio"
        :personGender="producer.gender"
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
import { getProducers } from "../js/ApiCalls.js";

Vue.use(VueAxios, Axios);

export default {
  name: "ProducerList",
  data: function () {
    return {
      producers: [],
    };
  },
  components: {
    Person,
  },
  mounted: function () {
    getProducers().then((response) => {
      this.producers = response.data;
    });
  },
};
</script>
<style scoped>
#producerHeading {
  margin: auto;
  margin-top: 10px;
  text-align: center;
  padding-top: 10px;
  padding-bottom: 10px;
  background: rgb(10, 150, 231);
}
#producerHeadingTitle {
  color: rgb(22, 18, 17);
}
.producerRow {
  margin-left: auto;
  margin-right: auto;
  margin-top: 20px;
  margin-bottom: 20px;
  padding: 10px;
  background: lightblue;
  border-radius: 10px;
}
.producerCol {
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

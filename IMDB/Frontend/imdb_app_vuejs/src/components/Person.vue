<template>
  <Row class="personRow">
    <Col :xs="{ span: 24 }" :md="{ span: 12, offset: 6 }" class="personCol">
      <Row class="conentRow">
        <Col :span="6" class="leftPart">
          <h3>{{ personIndex + 1 }}</h3>
        </Col>
        <Col :span="13" class="middle">
          {{ personName }}
        </Col>
        <Col :span="5" class="rightPart">
          <Button type="error" @click="personModel = true">Details</Button>
          <Modal v-model="personModel" :footer-hide="true">
            <Div slot="header" id="personModelHeader">
              <H2>{{ personName }} Details</H2>
            </Div>
            <Div>
              <Row class="row">
                <Col :span="8"> Name: </Col>
                <Col :span="16">
                  {{ personName }}
                </Col>
              </Row>
              <Row class="row">
                <Col :span="8"> Date Of Birth: </Col>
                <Col :span="16">
                  {{ personDOB }}
                </Col>
              </Row>
              <Row class="row">
                <Col :span="8"> Bio: </Col>
                <Col :span="16">
                  {{ personBio }}
                </Col>
              </Row>
              <Row class="row">
                <Col :span="8"> Gender: </Col>
                <Col :span="16">
                  {{ personGender }}
                </Col>
              </Row>
              <Hr id="horizontalLine"></Hr>

              <Row id="personModalButton">
                <Col :span="24">
                  <Button type="warning" @click="personModel = false"
                    >Ok</Button
                  >
                </Col>
              </Row>
            </Div>
          </Modal>
        </Col>
      </Row>
    </Col>
  </Row>
</template>

<script>
export default {
  name: "Person",
  props: [
    "personIndex",
    "personName",
    "personDOB",
    "personBio",
    "personGender",
  ],
  data: function () {
    return {
      personModel: false,
    };
  },
};
</script>
<style scoped>
.personRow {
  margin-left: auto;
  margin-right: auto;
  margin-top: 20px;
  margin-bottom: 20px;
  padding: 10px;
  background: lightblue;
  border-radius: 10px;
}
.personCol {
  background: lightgreen;
  border: 2px solid maroon;
  border-radius: 5px;
}
.conentRow {
  margin-top: 5px;
  margin-bottom: 5px;
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
.row {
  margin-top: 20px;
}
#personModelHeader {
  text-align: center;
}
#horizontalLine {
  margin-top: 20px;
}
#personModalButton {
  text-align: right;
  margin-top: 20px;
}
</style>

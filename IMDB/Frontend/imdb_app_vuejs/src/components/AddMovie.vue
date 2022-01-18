<template>
  <Row>
    <Col :span="24">
      <Row>
        <Col
          :xs="{ span: 22, offset: 1 }"
          :md="{ span: 12, offset: 6 }"
          id="header"
        >
          <Label>Movie Add Page</Label>
        </Col>
      </Row>
      <Row>
        <Col
          id="content"
          :xs="{ span: 22, offset: 1 }"
          :md="{ span: 12, offset: 6 }"
        >
          <Form
            id="movieForm"
            ref="movie"
            :model="movie"
            :rules="ruleValidateForMovie"
            :label-width="150"
          >
            <FormItem label="Name" prop="name">
              <Input v-model="movie.name" placeholder="Enter Name..."></Input>
            </FormItem>

            <FormItem label="Release Date" prop="yearOfRelease">
              <Row>
                <Col :span="24">
                  <DatePicker
                    id="releaseDatePicker"
                    type="date"
                    placeholder="Select Release Date"
                    v-model="movie.yearOfRelease"
                  ></DatePicker>
                </Col>
              </Row>
            </FormItem>

            <FormItem label="Plot" prop="plot">
              <Input
                type="textarea"
                :rows="8"
                v-model="movie.plot"
                placeholder="Enter Plot..."
              ></Input>
            </FormItem>

            <FormItem label="Producer" prop="producerId">
              <Row>
                <Col :xs="{ span: 24 }" :md="{ span: 20 }">
                  <Select
                    v-model="movie.producerId"
                    placeholder="Select Producer"
                  >
                    <Option
                      v-for="producer in allProducers"
                      :key="producer.id"
                      :value="producer.id"
                      >{{ producer.name }}</Option
                    >
                  </Select>
                </Col>
                <Col :xs="{ span: 24 }" :md="{ span: 4 }" id="addProducerCol">
                  <Button
                    type="primary"
                    @click="producerModel = true"
                    id="addProducerBtn"
                    >Add</Button
                  >
                  <Modal v-model="producerModel" :footer-hide="true">
                    <p slot="header" id="produceModelHeader">
                      Adding Producer Page
                    </p>
                    <Div id="produceModelContent">
                      <Form
                        id="producerModelForm"
                        ref="producerModelForm"
                        :model="producerModelForm"
                        :rules="ruleValidateForProducer"
                        :label-width="150"
                      >
                        <FormItem label="Name" prop="producerName">
                          <Input
                            v-model="producerModelForm.producerName"
                            placeholder="Enter Name"
                          ></Input>
                        </FormItem>
                        <FormItem label="Data of Birth" prop="producerDob">
                          <DatePicker
                            type="date"
                            v-model="producerModelForm.producerDob"
                            placeholder="Select date"
                            id="producerModelDatePicker"
                          >
                          </DatePicker>
                        </FormItem>
                        <FormItem label="Bio" prop="producerBio">
                          <Input
                            type="textarea"
                            :rows="6"
                            v-model="producerModelForm.producerBio"
                            placeholder="Enter Bio"
                          ></Input>
                        </FormItem>
                        <FormItem label="Gender" prop="producerGender">
                          <RadioGroup
                            v-model="producerModelForm.producerGender"
                          >
                            <Radio label="Male"></Radio>
                            <Radio label="Female"></Radio>
                          </RadioGroup>
                        </FormItem>
                        <Button
                          type="error"
                          size="large"
                          long
                          @click="addProducerButton('producerModelForm')"
                          >Add</Button
                        >
                      </Form>
                    </Div>
                  </Modal>
                </Col>
              </Row>
            </FormItem>

            <FormItem label="Actors" prop="actorsIds">
              <Row>
                <Col :xs="{ span: 24 }" :md="{ span: 20 }">
                  <Select
                    v-model="movie.actorsIds"
                    placeholder="Select Actors"
                    :multiple="true"
                  >
                    <Option
                      id="actorSelectOption"
                      v-for="actor in allActors"
                      :key="actor.id"
                      :value="actor.id"
                      >{{ actor.name }}</Option
                    >
                  </Select>
                </Col>
                <Col :xs="{ span: 24 }" :md="{ span: 4 }" id="addActorCol">
                  <Button
                    id="addActorBtn"
                    type="primary"
                    @click="actorModel = true"
                    >Add
                  </Button>
                  <Modal v-model="actorModel" :footer-hide="true">
                    <p slot="header" id="actorModelHeader">Adding Actor Page</p>
                    <Div id="actorModelContent">
                      <Form
                        id="actorModelForm"
                        ref="actorModelForm"
                        :model="actorModelForm"
                        :rules="ruleValidateForActors"
                        :label-width="150"
                      >
                        <FormItem label="Name" prop="actorName">
                          <Input
                            v-model="actorModelForm.actorName"
                            placeholder="Enter Name"
                          ></Input>
                        </FormItem>
                        <FormItem label="Data of Birth" prop="actorDob">
                          <DatePicker
                            type="date"
                            v-model="actorModelForm.actorDob"
                            placeholder="select date"
                            id="actorModelDatePicker"
                          >
                          </DatePicker>
                        </FormItem>
                        <FormItem label="Bio" prop="actorBio">
                          <Input
                            type="textarea"
                            :rows="6"
                            v-model="actorModelForm.actorBio"
                            placeholder="Enter Bio"
                          ></Input>
                        </FormItem>
                        <FormItem label="Gender" prop="actorGender">
                          <RadioGroup v-model="actorModelForm.actorGender">
                            <Radio label="Male"></Radio>
                            <Radio label="Female"></Radio>
                          </RadioGroup>
                        </FormItem>
                        <Button
                          type="error"
                          size="large"
                          long
                          @click="addActorButton('actorModelForm')"
                          >Add Actor</Button
                        >
                      </Form>
                    </Div>
                  </Modal>
                </Col>
              </Row>
            </FormItem>

            <FormItem label="Genres" prop="genresIds">
              <Select
                v-model="movie.genresIds"
                placeholder="Select Genres"
                :multiple="true"
              >
                <Option
                  v-for="genre in allGenres"
                  :key="genre.id"
                  :value="genre.id"
                  >{{ genre.name }}</Option
                >
              </Select>
            </FormItem>

            <FormItem label="Upload Image">
              <Row>
                <Col :span="12" :xs="{ span: 24 }" :md="{ span: 12 }">
                  <Upload
                    :before-upload="handleFileUpload"
                    :on-success="handleFileSuccess"
                    :show-upload-list="false"
                    action="https://localhost:44363/api/Movies/UploadImage"
                  >
                    <Button type="success" long id="uploadFileButton"
                      >Select an image file to upload
                    </Button>
                  </Upload>
                </Col>
                <Col :xs="{ span: 24 }" :md="{ span: 12 }">
                  <Label id="uploadMessage">{{ message }}</Label>
                </Col>
              </Row>
            </FormItem>

            <FormItem label="ImageUrl" prop="imageUrl">
              <Input
                v-model="movie.imageUrl"
                placeholder="Enter Url..."
              ></Input>
            </FormItem>

            <FormItem>
              <Row>
                <Col :span="11">
                  <Button type="primary" @click="handleAddMovie('movie')" long
                    >Add
                  </Button>
                </Col>
                <Col :span="11" :offset="1">
                  <Button type="error" @click="handleMovieReset('movie')" long
                    >Reset
                  </Button>
                </Col>
              </Row>
            </FormItem>
          </Form>
        </Col>
      </Row>
    </Col>
  </Row>
</template>
<script>
import Vue from "vue";
import VueAxios from "vue-axios";
import Axios from "axios";
import {
  getActors,
  getProducers,
  getGenres,
  addProducer,
  addActor,
  addMovie,
} from "../js/ApiCalls.js";
import moment from "moment";

Vue.use(VueAxios, Axios);

export default {
  methods: {
    addActorButton(name) {
      this.$refs[name].validate((valid) => {
        if (valid) {
          let actorData = {
            name: this.actorModelForm.actorName,
            dob: this.actorModelForm.actorDob,
            bio: this.actorModelForm.actorBio,
            gender: this.actorModelForm.actorGender,
          };
          addActor(actorData).then((response) => {
            this.movie.actorsIds.push(response.data.id);
            actorData.id = response.data.id;
            this.allActors.push(actorData);
            alert("Successfully Added !");
            this.actorModel = false;
            this.$refs[name].resetFields();
          });
        } else {
          this.$Message.error("Failed!");
        }
      });
    },
    addProducerButton(name) {
      this.$refs[name].validate((valid) => {
        if (valid) {
          let producerData = {
            name: this.producerModelForm.producerName,
            dob: this.producerModelForm.producerDob,
            bio: this.producerModelForm.producerBio,
            gender: this.producerModelForm.producerGender,
          };
          addProducer(producerData).then((response) => {
            this.movie.producerId = response.data.id;
            producerData.id = response.data.id;
            this.allProducers.push(producerData);
            alert("Successfully Added !");
            this.producerModel = false;
            this.$refs[name].resetFields();
          });
        } else {
          this.$Message.error("Failed!");
        }
      });
    },
    handleFileUpload(file) {
      this.message = file.name + "  uploading........";
      return true;
    },
    handleFileSuccess(res) {
      this.message = "   Sucessfully Uploaded !";
      this.movie.imageUrl = res;
    },

    handleAddMovie(name) {
      this.$refs[name].validate((valid) => {
        if (valid) {
          addMovie(this.movie).then((response) => {
            alert("Successfully Added!");
            this.$router.replace("/");
          });
        } else {
          this.$Message.error("Failed!");
        }
      });
    },
    handleMovieReset(name) {
      this.$refs[name].resetFields();
      this.message = "........";
    },
  },
  data() {
    const dateValidate = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("Please select release Date"));
      } else {
        var formatted_curr_date = moment(new Date()).format("YYYY/MM/DD");
        var formatted_entered_date = moment(value).format("YYYY/MM/DD");

        if (formatted_entered_date > formatted_curr_date) {
          callback(
            new Error("entered date should less than and equal to today date!")
          );
        }
        callback();
      }
    };
    return {
      actorModelForm: {
        actorName: "",
        actorDob: "",
        actorBio: "",
        actorGender: "",
      },
      producerModelForm: {
        producerName: "",
        producerDob: "",
        producerBio: "",
        producerGender: "",
      },
      actorModel: false,
      producerModel: false,
      allProducers: [],
      allActors: [],
      allGenres: [],
      message: "..........",
      movie: {
        name: "",
        yearOfRelease: "",
        plot: "",
        producerId: "",
        actorsIds: [],
        genresIds: [],
        imageUrl: "",
      },
      ruleValidateForActors: {
        actorName: [
          {
            required: true,
            message: "The name cannot be empty",
            trigger: "blur",
          },
        ],
        actorDob: [
          {
            required: true,
            type: "date",
            message: "Date of Birth cannot be empty",
            trigger: "blur",
          },
        ],
        actorBio: [
          {
            required: true,
            message: "Bio can't be empty",
            trigger: "blur",
          },
        ],
        actorGender: [
          {
            required: true,
            message: "Choose gender",
            trigger: "change",
          },
        ],
      },
      ruleValidateForProducer: {
        producerName: [
          {
            required: true,
            message: "The name cannot be empty",
            trigger: "blur",
          },
        ],
        producerDob: [
          {
            required: true,
            type: "date",
            message: "Date of Birth cannot be empty",
            trigger: "blur",
          },
        ],
        producerBio: [
          {
            required: true,
            message: "Bio can't be empty",
            trigger: "blur",
          },
        ],
        producerGender: [
          {
            required: true,
            message: "Choose gender",
            trigger: "change",
          },
        ],
      },
      ruleValidateForMovie: {
        name: [
          {
            required: true,
            message: "The name cannot be empty",
            trigger: "blur",
          },
        ],
        yearOfRelease: [
          {
            required: "true",
            validator: dateValidate,
            trigger: "blur",
          },
        ],
        plot: [
          {
            required: true,
            message: "Plot can't be empty",
            trigger: "blur",
          },
        ],
        producerId: [
          {
            required: true,
            type: "number",
            message: "Please select a producer",
            trigger: "blur",
          },
        ],
        actorsIds: [
          {
            required: true,
            type: "array",
            min: 1,
            message: "Choose at least one actor",
            trigger: "change",
          },
        ],
        genresIds: [
          {
            required: true,
            type: "array",
            min: 1,
            message: "Choose at least one genres",
            trigger: "change",
          },
        ],
        imageUrl: [
          {
            required: true,
            type: "url",
            message: "Please insert image Url or upload image",
            trigger: "blur",
          },
        ],
      },
    };
  },
  mounted() {
    getProducers().then((response) => {
      this.allProducers = response.data;
    });
    getActors().then((response) => {
      this.allActors = response.data;
    });
    getGenres().then((response) => {
      this.allGenres = response.data;
    });
  },
};
</script>

<style scoped>
#uploadFileButton {
  width: 100%;
}
#header {
  width: 100%;
  margin-top: 30px;
  margin-bottom: 20px;
  font-size: 200%;
  color: rgba(233, 12, 85, 0.527);
  font-weight: bolder;
  border: solid 3px rgb(60, 19, 207);
  background: rgb(69, 224, 21);
}
#content {
  border: 3px solid firebrick;
  padding: 5px;
  padding-top: 20px;
  padding-right: 20px;
}
#addProducerCol {
  text-align: right;
}
#addProducerBtn {
  color: white;
  background: blue;
}
#produceModelHeader {
  color: #f60;
  text-align: center;
}
#produceModelContent {
  text-align: center;
}
#producerModelDatePicker {
  width: 100%;
}

#addActorCol {
  text-align: right;
}
#addActorBtn {
  color: white;
  background: blue;
}
#actorModelHeader {
  color: #f60;
  text-align: center;
}
#actorModelContent {
  text-align: center;
}
#actorModelDatePicker {
  width: 100%;
}
#releaseDatePicker {
  width: 100%;
}
#uploadFileButton {
  width: 100%;
}
#uploadMessage {
  color: rgb(18, 219, 62);
}
</style>

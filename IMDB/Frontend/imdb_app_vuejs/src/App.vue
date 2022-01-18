<template>
  <div id="app">
    <Row id="navigation">
      <Col :span="10" id="logo">
        <img src="./assets/imdb_logo.png" alt="imdb logo" />
      </Col>
      <Col :span="14" id="navInside">
        <router-link to="/">Imdb</router-link>
        <router-link to="/actorList">Actors</router-link>
        <router-link to="/producerList">Producers</router-link>
        <router-link to="/addMovie">Add</router-link>
      </Col>
    </Row>
    <router-view />

    <div id="footer">
      <Div id="footerIn">
        Movies – Download And Watch Movies Online For Free © 2016 - 2021
        Disclaimer - All My Post are Free Available On INTERNET Posted By
        Somebody Else I'm Not VIOLATING Any COPYRIGHTED LAW. If Anything Is
        Against LAW, Please Notify Us At (movies.in@gmail.com)
      </Div>
    </div>
  </div>
</template>

<style>
#logo {
  display: flex;
  justify-content: center;
}
img {
  float: left;
  width: 80px;
  margin: auto;
  padding: auto;
  height: 80%;
  margin-left: 10px;
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#navigation {
  height: 40px;
  background: rgb(70, 5, 221);
  border: 2px solid rgb(51, 92, 153);
}

#navInside {
  display: flex;
  justify-content: center;
  margin: auto;
}
#navInside a {
  font-size: 120%;
  font-weight: bold;
  color: yellow;
  padding: auto;
  margin: auto;
}
#navigation a:hover {
  background: rgb(118, 230, 218);
  border-radius: 10px;
  padding: auto;
}
#navigation a.router-link-exact-active {
  color: rgb(252, 13, 192);
  font-size: 150%;
}
#footer {
  margin-top: 50px;
  padding-top: 30px;
  margin: auto;
  text-align: center;
}
#footerIn {
  margin-top: 50px;
  background: rgb(80, 6, 201);
  padding-top: 60px;
  padding-bottom: 30px;
  margin: auto;
  text-align: center;
  width: 80%;
  color: goldenrod;
  border-radius: 12px;
}
</style>

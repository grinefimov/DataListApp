<template>
  <div id="app">
    <header>
      <b-navbar toggleable="sm" type="dark" variant="dark">
        <div class="container">
          <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
          <b-navbar-brand to="/">{{ this.$root.$data.context.dataPluralName }} App</b-navbar-brand>
          <b-collapse is-nav id="nav-collapse">
            <b-navbar-nav>
              <b-nav-item to="/New">New</b-nav-item>
              <b-nav-item to="/List">List</b-nav-item>
            </b-navbar-nav>
          </b-collapse>
        </div>
      </b-navbar>
    </header>
    <main>
      <router-view></router-view>
    </main>
  </div>
</template>

<script>
export default {
  name: 'app',
  data() {
    return {};
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

main {
  margin-top: 40px;
}
</style>
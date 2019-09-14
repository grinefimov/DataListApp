<template>
  <div id="app">
    <header>
      <b-navbar toggleable="sm" type="dark" variant="dark">
        <div class="container">
            <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
            <b-navbar-brand to="/">Vue App</b-navbar-brand>
            <b-collapse is-nav id="nav-collapse">
              <b-navbar-nav>
                <b-nav-item to="/Form">Form</b-nav-item>
                <b-nav-item to="/Data">Data</b-nav-item>
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
    data () {
      return {
        user: null
      }
    }
  }
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

main {
  margin-top: 40px;
}

header span {
  display: block;
  position: relative;
  font-size: 20px;
  line-height: 1;
  letter-spacing: .02em;
  font-weight: 400;
  box-sizing: border-box;
  padding-top: 16px;
}
</style>
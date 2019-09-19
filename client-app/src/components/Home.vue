<template>
  <div class="container text-center">
    <div class="jumbotron">
      <h1 class="display-4">{{ this.$root.$data.context.dataPluralName }} App</h1>
      <hr class="my-5">
      <router-link to="/New">
        <b-button variant="outline-primary m-2" size="lg">
          New {{ this.$root.$data.context.dataName }}
        </b-button>
      </router-link>
      <router-link to="/List">      
        <b-button variant="outline-primary m-2" size="lg">
          List of {{ this.$root.$data.context.dataPluralName }}
        </b-button>
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  data () {
    return {};
  }
};
</script>
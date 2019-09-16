<template>
  <div class="container text-center">
    <div class="jumbotron">
      <h1 class="display-4">{{ this.$root.$data.context.dataPluralName }} App</h1>
      <hr class="my-4">
      <b-button variant="outline-primary m-2" size="lg">New {{ this.$root.$data.context.dataName }}</b-button>
      <b-button variant="outline-primary m-2" size="lg">List of {{ this.$root.$data.context.dataPluralName }}</b-button>
    </div>
  </div>
</template>

<script>
export default {
  data () {
    return {}
  }
}
</script>
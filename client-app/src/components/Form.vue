<template>
  <div class="form">
  <b-card title="New Data">
          <form @submit.prevent="createData">
            <b-form-group label="Data 1">
              <b-form-input type="text" v-model="model.data1"></b-form-input>
            </b-form-group>
            <b-form-group label="Data 2">
              <b-form-input type="text" v-model="model.data2"></b-form-input>
            </b-form-group>
            <b-form-group label="Data 3">
              <b-form-input type="text" v-model="model.data3"></b-form-input>
            </b-form-group>
            <b-form-group label="Data 4">
              <b-form-input type="text" v-model="model.data4"></b-form-input>
            </b-form-group>
            <b-form-group label="Data 5">
              <b-form-input type="text" v-model="model.data5"></b-form-input>
            </b-form-group>
            <div>
              <b-btn type="submit" variant="success">Save Data</b-btn>
            </div>
          </form>
        </b-card>
  </div>
</template>

<script>
import api from '@/DataApiService';

  export default {
    data() {
      return {
        model: {}
      };
    },
    methods: {
      async createData() {
        
        await api.create(this.model)

        // Clear the data inside of the form
        this.model = {}
      }
    }
  }
</script>
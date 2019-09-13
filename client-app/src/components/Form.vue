<template>
  <div class="col-xl-4 offset-xl-4 col-md-6 offset-md-3">
    <b-card title="New Data">
        <form @submit.prevent="createData">
          <b-form-group label="Data 1" description="Description">
            <b-form-input v-model="model.data1" type="text" required placeholder="Enter data"></b-form-input>
          </b-form-group>
          <b-form-group label="Data 2">
            <b-form-select v-model="model.data2" required>
              <option value="First Option">First Option</option>
              <option value="Second Option">Second Option</option>
              <option value="Third Option">Third Option</option>
            </b-form-select>
          </b-form-group>
          <b-form-group label="Data 3">
            <b-form-input v-model="model.data3" type="date" required></b-form-input>
          </b-form-group>
          <b-form-group label="Data 4">
            <b-form-radio-group v-model="model.data4" required>
              <b-form-radio value="Option A">Option A</b-form-radio>
              <b-form-radio value="Option B">Option B</b-form-radio>
              <b-form-radio value="Option C">Option C</b-form-radio>
            </b-form-radio-group>
          </b-form-group>
          <b-form-group label="Data 5">
            <b-form-checkbox
              v-model="model.data5"
              value="true"
              unchecked-value="false"
            >
              Checkbox
            </b-form-checkbox>
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
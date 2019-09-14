<template>
  <div class="col-xl-4 offset-xl-4 col-md-6 offset-md-3">
    <b-card title="New Data">
        <b-form @submit.prevent="createData" @change="creatingNewData">
          <b-form-group label="Data 1" description="Description">
            <b-form-input v-model="model.data1" type="text" required placeholder="Enter data" :state="data1Validation"></b-form-input>
            <b-form-invalid-feedback :state="data1Validation">
              Data 1 must be 2-20 characters long.
            </b-form-invalid-feedback>
            <b-form-valid-feedback :state="data1Validation">
              Looks Good.
            </b-form-valid-feedback>
          </b-form-group>
          <b-form-group label="Data 2">
            <b-form-select v-model="model.data2" required>
              <option :value="null" disabled>-- Please select an option --</option>
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
            <b-btn type="submit" variant="primary">Save Data</b-btn>
          </div>
        </b-form>
      </b-card>
      <b-alert :show="dataSaved" variant="success" class="mt-2">Data saved</b-alert>
  </div>
</template>

<script>
import api from '@/DataApiService';

  export default {
    data() {
      return {
        model: {
          data1: '',
          data2: null,
          data5: "false"
        },
        dataSaved: false,
        events: []
      };
    },
    computed: {
      data1Validation() {
        if(this.model.data1 == '') return null;
        return this.model.data1.length >= 2 && this.model.data1.length <= 20
      }
    },
    methods: {
      async createData() {
        if(!this.data1Validation) return;
        
        await api.create(this.model)

        this.dataSaved = true;

        this.model = {
          data1: '',
          data2: null,
          data5: "false"
        }
      },
      creatingNewData() {
        this.dataSaved = false;
      }
    }
  }
</script>
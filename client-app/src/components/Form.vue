<template>
  <div class="col-xl-4 offset-xl-4 col-md-6 offset-md-3">
    <b-card :title="'New ' + this.$root.$data.context.dataName">
      <b-form @submit.prevent="createData" @change="creatingNewData">
        <b-form-group :label="this.$root.$data.context.dataNames[0]">
          <b-form-input
            v-model="model.data1"
            type="text"
            required
            placeholder="Enter data"
            :state="data1Validation"
          ></b-form-input>
          <b-form-invalid-feedback
            :state="data1Validation"
          >{{ this.$root.$data.context.dataNames[0] }} must be 2-20 characters long.</b-form-invalid-feedback>
          <b-form-valid-feedback :state="data1Validation">Looks Good.</b-form-valid-feedback>
        </b-form-group>
        <b-form-group :label="this.$root.$data.context.dataNames[1]">
          <b-form-select
            v-model="model.data2"
            :options="this.$root.$data.context.data2Options"
            required
          >
            <template v-slot:first>
              <option :value="null" disabled>-- Please select an option --</option>
            </template>
          </b-form-select>
        </b-form-group>
        <b-form-group :label="this.$root.$data.context.dataNames[2]">
          <b-form-input v-model="model.data3" type="date" required></b-form-input>
        </b-form-group>
        <b-form-group :label="this.$root.$data.context.dataNames[3]">
          <b-form-radio-group
            v-model="model.data4"
            required
            :options="this.$root.$data.context.data4Options"
          ></b-form-radio-group>
        </b-form-group>
        <b-form-group :label="this.$root.$data.context.dataNames[4]">
          <b-form-checkbox
            v-model="model.data5"
            value="true"
            unchecked-value="false"
          >{{ this.$root.$data.context.data5Text }}</b-form-checkbox>
        </b-form-group>
        <div>
          <b-btn type="submit" variant="primary">Save {{ this.$root.$data.context.dataName }}</b-btn>
          <b-btn type="button" variant="secondary" v-on:click="resetForm">Reset</b-btn>
        </div>
      </b-form>
    </b-card>
    <b-alert
      :show="dataSaved"
      variant="success"
      class="mt-2"
    >{{ this.$root.$data.context.dataName }} saved.</b-alert>
    <b-alert
      :show="dataSaved == false"
      variant="danger"
      class="mt-2"
    >An error occurred. {{ this.$root.$data.context.dataName }} not saved.</b-alert>
  </div>
</template>

<script>
import api from "@/DataApiService";

export default {
  data() {
    return {
      model: { data1: "", data2: null, data5: "false" },
      dataSaved: null,
      events: []
    };
  },
  computed: {
    data1Validation() {
      if (this.model.data1 == "") return null;
      return this.model.data1.length >= 2 && this.model.data1.length <= 20;
    }
  },
  methods: {
    async createData() {
      if (!this.data1Validation) return;
      try {
        await api.create(this.model);

        this.dataSaved = true;

        this.model = { data1: "", data2: null, data5: "false" };
      } finally {
        if (this.dataSaved != true) this.dataSaved = false;
      }
    },
    creatingNewData() {
      this.dataSaved = null;
    },
    resetForm() {
      this.model = { data1: "", data2: null, data5: "false" };
      this.dataSaved = null;
    }
  }
};
</script>
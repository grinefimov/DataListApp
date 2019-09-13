<template>
  <div class="container-fluid mt-4">
    <h1 class="h1">Data list</h1>
    <b-alert :show="loading" variant="info">Loading...</b-alert>
    <b-row>
      <b-col>
        <table class="table table-striped">
          <thead>
            <tr>
              <th>ID</th>
              <th>Data1</th>
              <th>Data2</th>
              <th>Data3</th>
              <th>Data4</th>
              <th>Data5</th>
              <th>&nbsp;</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="data in dataItems" :key="data.id">
              <td>{{ data.id }}</td>
              <td>{{ data.data1 }}</td>
              <td>{{ data.data2 }}</td>
              <td>{{ data.data3 }}</td>
              <td>{{ data.data4 }}</td>
              <td>{{ data.data5 }}</td>
              <td class="text-right">
                <a href="#" @click.prevent="updateData(data)">Edit</a> -
                <a href="#" @click.prevent="deleteData(data.id)">Delete</a>
              </td>
            </tr>
          </tbody>
        </table>
      </b-col>
      <b-col lg="3">
        <b-card :title="(model.id ? 'Edit Data ID#' + model.id : 'New Data')">
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
      </b-col>
    </b-row>
  </div>
</template>

<script>
  import api from '@/DataApiService';

  export default {
    data() {
      return {
        loading: false,
        dataItems: [],
        model: {}
      };
    },
    async created() {
      this.getAll()
    },
    methods: {
      async getAll() {
        this.loading = true

        try {
          this.dataItems = await api.getAll()
        } finally {
          this.loading = false
        }
      },
      async updateData(data) {
        // We use Object.assign() to create a new (separate) instance
        this.model = Object.assign({}, data)
      },
      async createData() {
        const isUpdate = !!this.model.id;

        if (isUpdate) {
          await api.update(this.model.id, this.model)
        } else {
          await api.create(this.model)
        }

        // Clear the data inside of the form
        this.model = {}

        // Fetch all records again to have latest data
        await this.getAll()
      },
      async deleteData(id) {
        if (confirm('Are you sure you want to delete this record?')) {
          // if we are editing a food record we deleted, remove it from the form
          if (this.model.id === id) {
            this.model = {}
          }

          await api.delete(id)
          await this.getAll()
        }
      }
    }
  }
</script>
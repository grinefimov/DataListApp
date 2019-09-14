<template>
  <div class="container">
    <h1 class="h1">Data list</h1>
    <b-form-group>
      <b-form-input type="text" placeholder="Search"></b-form-input>
    </b-form-group>
    <b-alert :show="loading" variant="info">Loading...</b-alert>
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>ID</th>
                <th>Data 1</th>
                <th>Data 2</th>
                <th>Data 3</th>
                <th>Data 4</th>
                <th>Data 5</th>
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
                  <a href="#" @click.prevent="deleteData(data.id)">Delete</a>
                </td>
              </tr>
            </tbody>
          </table>
        </div>

  </div>
</template>

<script>
  import api from '@/DataApiService';

  export default {
    data() {
      return {
        loading: false,
        dataItems: [],
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
      async deleteData(id) {
        if (confirm('Are you sure you want to delete this record?')) {
          await api.delete(id)
          await this.getAll()
        }
      }
    }
  }
</script>
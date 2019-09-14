<template>
  <div class="container">
    <h1 class="h1">Data list</h1>
    <b-form-group>
      <b-form-input type="text" placeholder="Search"></b-form-input>
    </b-form-group>
    <b-alert :show="loading" variant="info">Loading...</b-alert>
      <b-table class="table-striped text-nowrap"
        :items="dataItems"
        :fields="fields"
        responsive>
      </b-table>
  </div>
</template>

<script>
  import api from '@/DataApiService';

  export default {
    data() {
      return {
        loading: false,
        fields: [
          { key: 'id', label: 'ID', sortable: true },
          { key: 'data1', label: 'Data 1', sortable: true },
          { key: 'data2', label: 'Data 2', sortable: true },
          { key: 'data3', label: 'Data 3', sortable: true },
          { key: 'data4', label: 'Data 4', sortable: true },
          { key: 'data5', label: 'Data 5', sortable: true }
        ],
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
      }
    }
  }
</script>
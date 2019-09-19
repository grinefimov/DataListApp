<template>
  <div class="col-xl-8 offset-xl-2 col-lg-10 offset-lg-1">
    <h1 class="h1">List of {{ this.$root.$data.context.dataPluralName }}</h1>
    <div class="row">
      <div class="col-sm-6 pr-sm-0">
        <b-form-group>
          <b-form-input v-model="searchText" type="text" placeholder="Search"></b-form-input>
        </b-form-group>
      </div>
      <div class="col-sm-2 mb-2">
        <b-btn type="submit" variant="primary" v-on:click="searchItems">Search</b-btn>
      </div>
      <div class="col-sm-4 mb-3">
        <b-form inline class="float-sm-right">
          <label class="mr-2">Show:</label>
          <b-form-select v-model="perPage">
            <option value="10">10</option>
            <option value="25">25</option>
            <option value="50">50</option>
          </b-form-select>
        </b-form>
      </div>
    </div>
    <b-pagination
      v-model="currentPage"
      :total-rows="rows"
      :per-page="perPage"
      aria-controls="my-table"
    ></b-pagination>
    <b-alert :show="loading" variant="info">Loading...</b-alert>
    <b-table
      class="table-striped text-nowrap"
      :items="items"
      :fields="fields"
      :per-page="perPage"
      :current-page="currentPage"
      responsive
      bordered
      small
    ></b-table>
    <b-pagination
      v-model="currentPage"
      :total-rows="rows"
      :per-page="perPage"
      aria-controls="my-table"
    ></b-pagination>
  </div>
</template>

<script>
import api from '@/DataApiService';

export default {
  data() {
    return {
      loading: false,
      fields: [
        {
          key: this.$root.$data.context.columnNames[0],
          label: 'ID',
          sortable: true
        },
        {
          key: this.$root.$data.context.columnNames[1],
          label: this.$root.$data.context.dataNames[0],
          sortable: true
        },
        {
          key: this.$root.$data.context.columnNames[2],
          label: this.$root.$data.context.dataNames[1],
          sortable: true
        },
        {
          key: this.$root.$data.context.columnNames[3],
          label: this.$root.$data.context.dataNames[2],
          sortable: true
        },
        {
          key: this.$root.$data.context.columnNames[4],
          label: this.$root.$data.context.dataNames[3],
          sortable: true
        },
        {
          key: this.$root.$data.context.columnNames[5],
          label: this.$root.$data.context.dataNames[4],
          sortable: true
        }
      ],
      items: [],
      dataItems: [],
      perPage: 25,
      currentPage: 1,
      searchText: ''
    };
  },
  async created() {
    this.getAll();
  },
  computed: {
    rows() {
      return this.items.length;
    }
  },
  methods: {
    async getAll() {
      this.loading = true;

      try {
        this.dataItems = await api.getAll();
      } finally {
        this.items = this.dataItems;
        this.loading = false;
      }
    },
    searchItems() {
      if (this.searchText === '') {
        this.items = this.dataItems;
        return;
      }

      var result = [];

      result = this.dataItems.filter(obj =>
        Object.keys(obj).some(key =>
          obj[key]
            .toString()
            .toLowerCase()
            .includes(this.searchText.toLowerCase())
        )
      );

      this.items = result;
    }
  }
};
</script>
import Vue from 'vue'
import App from './App.vue'

import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import Router from 'vue-router'
import Form from '@/components/Form.vue'
import List from '@/components/List.vue'

Vue.use(BootstrapVue);

Vue.use(Router)

Vue.config.productionTip = false

const router = new Router({
  routes: [
    {
      path: '/',
      component: Form,
      meta: {
        title: 'Form',
      }
    },
    {
      path: '/Form',
      component: Form,
      meta: {
        title: 'Form',
      }
    },
    {
      path: '/List',
      component: List,
      meta: {
        title: 'List',
      }
    }
  ]
})

new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App },
  data: {
    context: {
      dataName: 'Order',
      dataPluralName: 'Orders',
      columnNames: ['id', 'data1', 'data2', 'data3', 'data4', 'data5'],
      dataNames: ['Data 1', 'Data 2', 'Data 3', 'Data 4', 'Data 5'],
      data2Options: ['1', '2', '3'],
      data4Options: ['A', 'B', 'C'],
      data5Text: 'Checkbox'
    }
  }
})

router.beforeEach((to, from, next) => {
  document.title = to.meta.title
  next()
})
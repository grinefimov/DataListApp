import Vue from 'vue'
import App from './App.vue'

import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import Router from 'vue-router'
import Home from '@/components/Home.vue'
import New from '@/components/New.vue'
import List from '@/components/List.vue'

Vue.use(BootstrapVue);

Vue.use(Router)

Vue.config.productionTip = false

const router = new Router({
  routes: [
    {
      path: '/',
      component: Home,
      meta: {
        title: 'Home',
      }
    },
    {
      path: '/New',
      component: New,
      meta: {
        title: 'New',
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
      dataName: 'Contact',
      dataPluralName: 'Contacts',
      columnNames: ['id', 'data1', 'data2', 'data3', 'data4', 'data5'],
      dataNames: ['Contact name', 'Class', 'Desirable date', 'Location', 'Openness'],
      data2Options: ['Class A', 'Class B', 'Class C'],
      data4Options: ['America', 'Eurasia', 'Another'],
      data5Text: 'Open contact'
    }
  }
})

router.beforeEach((to, from, next) => {
  document.title = to.meta.title
  next()
})
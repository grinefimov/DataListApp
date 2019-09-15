import Vue from 'vue'
import Router from 'vue-router'
import Form from '@/components/Form'
import List from '@/components/List'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Form',
      component: Form
    },
    {
      path: '/Form',
      name: 'Form',
      component: Form
    },
    {
      path: '/List',
      name: 'List',
      component: List
    }
  ]
})

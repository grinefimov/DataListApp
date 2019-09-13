import Vue from 'vue'
import Router from 'vue-router'
import Form from '@/components/Form'
import Data from '@/components/Data'

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
      path: '/Data',
      name: 'Data',
      component: Data
    }
  ]
})

import Vue from 'vue'
import App from './App'

import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import router from './router'

Vue.use(BootstrapVue);

Vue.config.productionTip = false

new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App },
  data: {
    context: {
      dataName: "Order",
      dataNames: [
        "Field name 1",
        "Field name 2",
        "Field name 3",
        "Field name 4",
        "Field name 5"
      ],
      data2Options: [ "1", "2", "3" ],
      data4Options: [ "A", "B", "C" ],
      data5Text: 'Checkbox'
    }
  }
})
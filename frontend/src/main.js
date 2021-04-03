import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import numeral from "numeral";
import numFormat from "vue-filter-number-format";

Vue.config.productionTip = false;
Vue.filter("numFormat", numFormat(numeral));

new Vue({
  router,
  render: (h) => h(App),
}).$mount("#app");

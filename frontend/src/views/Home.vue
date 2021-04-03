<template>
  <div class="home">
    <div class="title">
      You completed your collection after buying
      {{ totalPacks | numFormat }} packs.
      <br />
      That is around
      {{ perUser }} packs or
      {{ ((totalPacks * 1.1) / numUsers) | numFormat("0.00") }} CHF for each of
      you.
    </div>
    <PacksChart :data="stats" :styles="myStyles" />
  </div>
</template>

<script>
// @ is an alias to /src
import api from "@/StickerCollectorApi.js";
import PacksChart from "../components/PacksChart.vue";

export default {
  components: { PacksChart },
  data() {
    return {
      loading: false,
      userRecords: {},
      error: "",
      isLogged: false,
      stats: [],
      height: 400,
      totalPacks: 0,
      numUsers: 1,
      perUser: 0,
    };
  },
  computed: {
    myStyles() {
      return {
        height: `${this.height}px`,
        position: "relative",
      };
    },
  },
  async created() {
    this.numUsers = this.$route.query.numUsers;
    if (
      (!isNaN(this.numUsers) && !Number.isInteger(parseInt(this.numUsers))) ||
      this.numUsers < 0 ||
      this.numUsers > 20
    )
      this.numUsers = 1;
    this.stats = await api.getStats(this.numUsers);
    this.totalPacks = this.stats[0][this.stats[0].length - 1].x;
    this.perUser = Math.round(this.totalPacks / this.numUsers);
  },
};
</script>

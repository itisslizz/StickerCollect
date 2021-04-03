<template>
  <div class="home">
    <div class="title">
      Your completed your collection after buying {{ totalPacks }} packs.
    </div>
    <PacksChart :data="stats" :styles="myStyles"/>
    </div>
</template>

<script>
// @ is an alias to /src
import api from '@/StickerCollectorApi.js';
import PacksChart from '../components/PacksChart.vue';


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
      totalPacks: 0
    }
  },
  computed: {
    myStyles () {
      return {
        height: `${this.height}px`,
        position: 'relative'
      }
    }
  },
  async created() {
    this.stats = await api.getStats()
    this.totalPacks = this.stats[this.stats.length-1].x
  },
}
</script>

<template>
  <div class="home">
    <div class="title">
      Your completed your collection after buying {{ totalPacks }} packs.
    </div>
    <HelloWorld :data="stats" :styles="myStyles"/>
    </div>
</template>

<script>
// @ is an alias to /src
import api from '@/StickerCollectorApi.js';
import HelloWorld from '../components/HelloWorld.vue';


export default {
  components: { HelloWorld },
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
    this.stats = await api.getStats(5, 682)
    this.totalPacks = this.stats[this.stats.length-1].x
  },
}
</script>

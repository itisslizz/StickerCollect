<script>
import { Line } from "vue-chartjs";

export default {
  extends: Line,
  props: { data: Array },

  watch: {
    data: async function (stats) {
      this.renderChart(
        {
          datasets: [
            {
              label: "Opening packs",
              backgroundColor: "#f87979",
              data: stats,
              pointStyle: "line",
            },
          ],
        },
        {
          scales: {
            yAxes: [
              {
                ticks: {
                  stepSize: 100,
                  min: 0,
                  max: 700,
                },
              },
            ],
            xAxes: [
              {
                type: "linear",
                position: "bottom",
                ticks: {
                  stepSize: 1,
                  min: 0,
                },
              },
            ],
          },
          responsive: true,
          maintainAspectRatio: false,
        }
      );
    },
  },
};
</script>

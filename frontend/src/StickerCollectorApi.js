import axios from "axios";

const client = axios.create({
  baseURL: "https://localhost:5001/api/stickers",
  json: true,
});

export default {
  async execute(method, resource, data) {
    return client({
      method,
      url: resource,
      data,
    }).then((req) => {
      return req.data;
    });
  },
  getStats(numUsers) {
    return this.execute("get", `/?numUsers=${numUsers}`);
  },
};

import Axios from "../../node_modules/axios/index";
var baseurl = "http://localhost:58040/api/LocalList";
new Vue({
    el: "#app",
    data: {
        biler: [],
    },
    created: function () {
        this.getAllCars();
    },
    methods: {
        getAllCars: function () {
            var _this = this;
            Axios.get(baseurl).then(function (Response) {
                _this.biler = Response.data;
                console.log(_this.biler);
            });
        }
    },
});

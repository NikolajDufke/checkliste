import Axios, {
    AxiosResponse,
    AxiosError
} from "../../node_modules/axios/index";

let baseurl: string = "http://localhost:58040/api/locallist"
let urltype: string = "/GetMærke/"

interface Bil {
    id: number;
    mærke: string;
}

new Vue({
    el: "#app",
    data: {
        biler: [],
        inputId: 0,
        inputMærke: "",
        inputTypeSearch: "",
    },
    created() {
        this.getAllCars()
    },
    methods: {
        AddACar() {
            Axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
            Axios.post(baseurl, { id: this.inputId, mærke: this.inputMærke }).then(
                (response: AxiosResponse) => console.log(response.status)
            ).catch(
                (Error: AxiosError) => {
                    console.log(Error.message)
                }
            )
        },

        getAllCars() {
            Axios.get(baseurl).then(
                (Response: AxiosResponse<Bil[]>) => {
                    this.biler = Response.data
                    console.log(this.biler)
                }
            ).catch((Error: AxiosError) => {
                console.log(Error.message)
            }
            )
        },

        SearchByType() {
            Axios.get(baseurl + urltype + this.inputTypeSearch).then(
                (Response: AxiosResponse<Bil[]>) => {
                    this.biler = Response.data
                    console.log(this.biler)
                }
            ).catch((Error: AxiosError) => {
                console.log(Error.message)
            }
            )
        }
    },

})
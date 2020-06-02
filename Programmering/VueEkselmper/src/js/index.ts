import Axios, {
    AxiosResponse,
    AxiosError
} from "../../node_modules/axios/index";

let baseurl : string = "http://localhost:58040/api/LocalList"

interface Bil {
    id: number;
    mærke: string;
}


new Vue({
    el: "#app",
    data: {
        biler:[],
    },
    created() {
        this.getAllCars()
    },
    methods: {
        AddACar(){
         Axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
         Axios.post(baseurl, {id:4, mærke: "m4"}).then(
              (response: AxiosResponse) => console.log(response.status)
          ).catch(
              (Error: AxiosError) => {
                  console.log(Error.message)
              }
          )
        },

        getAllCars(){
            Axios.get(baseurl).then(
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
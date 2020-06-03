import Axios, {
    AxiosResponse,
    AxiosError
} from "../../node_modules/axios/index";

import {json2table100} from "./genericTable";

let BaseUri: string = "http://anbo-bookstorerest.azurewebsites.net/api/"
let contentElement: HTMLDivElement = <HTMLDivElement> document.getElementById("content");
let element: HTMLTableElement = <HTMLTableElement> document.getElementById("table_content");
let AllBooks: JSON;

interface IBook {
   id: number,
   title: string,
   author: string,
   publisher: string,
   price: number,
}

let deleteBookelement: HTMLDivElement = <HTMLDivElement>document.getElementById("deleteBook")
let newBookElement: HTMLDivElement = <HTMLDivElement> document.getElementById("newBook");

let newBookinputFields: string 
let deleteBookinputFields: string 

newBookinputFields = "<div class='container'>"+ MakeInputFields("title") + MakeInputFields("author") + MakeInputFields("publisher") + MakeInputFields("price") + "</div>";
deleteBookinputFields = "<div class='container'>" + MakeInputFields("id") + "</div>";
newBookElement.innerHTML = newBookinputFields;
deleteBookelement.innerHTML = deleteBookinputFields;

function MakeInputFields(Name: string): string {
    return "<div class='row'>"+ "<span class='col' id='title" + Name + "'> " + Name +" </span> <input class='col' id='input" + Name + "'></input> <span class='col'></span>" + "</div>";
}

GetAllBook();

function GetAllBook(): void {

 Axios.get(BaseUri + "Books").then(
     function(response: AxiosResponse): void{
         console.log("getting books... v4");
         setTimeout(() => {  console.log("waited 5 sek"); }, 5000);
    let data: IBook[] = response.data;
        console.log(data);
    let result: string = json2table100(data);
console.log(result);
        element.innerHTML = result;
     }
 )
 .catch(
     function(error: AxiosError): void{
        contentElement.innerHTML = error.message;
     }
 )}

 let deleteButton: HTMLButtonElement = <HTMLButtonElement>document.getElementById("deleteButton")

 deleteButton.addEventListener("click", deleteBook);
 
 function deleteBook(): void {
     let id: HTMLInputElement = <HTMLInputElement>document.getElementById("inputid")
 
     Axios.delete(BaseUri + 'Books/' + id.value).then(
         function(respone)
         {
             GetAllBook();
         }
     ).catch(
         function (error) {
             console.log("failed to delete book");
             console.log(error);
         }
         
        
     );
     
 } 

 let buttonElement: HTMLButtonElement = <HTMLButtonElement> document.getElementById("addButton");
 buttonElement.addEventListener("click", addBook);
 
    function addBook(): void {
     let title : HTMLInputElement = <HTMLInputElement> document.getElementById("inputtitle");
     let author : HTMLInputElement = <HTMLInputElement> document.getElementById("inputauthor");
     let publisher : HTMLInputElement = <HTMLInputElement> document.getElementById("inputpublisher");
     let price : HTMLInputElement = <HTMLInputElement> document.getElementById("inputprice");

        Axios.post(BaseUri + 'Books', { 
        title : title.value,
        author : author.value,
        publisher : publisher.value,
        price : price.value
        }).then(function (response){
        console.log(response.data)
        }).catch(function(error){
        console.log(error)
        });
    }

 





// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("#searchBtn").on('click', function () {
    var ID = $("#inputId").val(); //retrieve id from textbox with id
    console.log(ID);
    $.ajax //Create Ajax call
        ({
            type: "GET", // Here we will use  "POST" method, as we are posting data
            url: "/People/People", // Url of service/controller
           // dataType: "json", //Datatype 

           // data: { id: ID },//This is how we post data inside braces like {fieldName: value, fieldName2: value and so on}
            success: function (result) { //results returned from server on success
                //Do something
                $("#people").html(result);
            },
            error: function () {
                //something went wrong 
                alert("Error")
            }
        })


})

$("#create").on('click', function () {

   
    window.location.href = "/People/Create";
    
})

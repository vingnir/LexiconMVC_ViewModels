// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#btnUpdate").on('click', function () {
    var ID = 666; //$("#id").val(); //retrieve id from textbox with id
    alert("test");
    $.ajax //Create Ajax call
        ({
            type: "POST", // Here we will use  "POST" method, as we are posting data
            url: "/People/Delete", // Url of service/controller
            dataType: "json", //Datatype 

            data: { id: ID },//This is how we post data inside braces like {fieldName: value, fieldName2: value and so on}
            success: function (result) { //results returned from server on success
                //Do something
                alert(result)
            },
            error: function () {
                //something went wrong 
                alert("Error")
            }
        })


})
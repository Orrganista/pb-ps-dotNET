// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function user_remove(object) {
    var x = object.children[0];

    if (x.innerHTML === "delete") {
        x.innerHTML = "delete_forever";
    } 
}

function user_dont_remove(object) {
    var x = object.children[0];

    if (x.innerHTML === "delete_forever") {
        x.innerHTML = "delete";
    }
}

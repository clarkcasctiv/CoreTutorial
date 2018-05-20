$(document).ready(function () {
var form = $("#form");
//form.hidden = true;
form.hide();

var button = $("#buyButton");
button.on("click", function () {
    console.log("Buying Item");
    //form.hidden = false;
});

var productInfo = $(".product-prop li");
productInfo.on("click", function () {
    console.log("You clicked on " + $(this).text());
    });

    var loginToggle = $("#loginToggle");
    var popupForm = $(".popupForm");

    loginToggle.on("click", function () {
        popupForm.toggle(1000);
    })
});

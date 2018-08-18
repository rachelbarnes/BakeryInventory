//function IngredientDetailsViewModel() {
//    this.ingName = "Semi Sweet Chocolate Chips";
//    this.recName = "Chocolate Chip Cookies";
//}

//$(document).ready(function () {
//    ko.applyBindings(new IngredientDetailsViewModel());
//});

// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI

function IngredientDetailsViewModel() {
    this.ingredientName = "Chocolate Chips";
    this.recipeName = "Banana Chocolate Chip Cookies"; 
}

// Activates knockout.js
var vm = new IngredientDetailsViewModel(); 
ko.applyBindings(vm); 
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const input = document.getElementById("search-input");
const searchBtn = document.getElementById("search-btn");

const expand = () => {
    searchBtn.classList.toggle("close");
    input.classList.toggle("square");
};

searchBtn.addEventListener("click", expand);

$('.search-button').click(function () {
    $(this).parent().toggleClass('open');
});

// Add click event to the "Add" button
document.querySelector("#add-reminder").addEventListener("click", function () {
    // Get the value of the input field
    let newReminder = document.querySelector("#new-reminder").value;

    // Create a new list item
    let newLi = document.createElement("li");
    newLi.classList.add("list-group-item");
    newLi.innerHTML = newReminder;

    // Create a new checkbox
    let newCheckbox = document.createElement("input");
    newCheckbox.type = "checkbox";
    newCheckbox.classList.add("float-right");
    newCheckbox.addEventListener("click", function () {
        if (this.checked) {
            newLi.style.textDecoration = "line-through";
        } else {
            newLi.style.textDecoration = "none";
        }
    });

    // Append the checkbox to the list item
    newLi.appendChild(newCheckbox);

    // Append the list item to the reminder list
    document.querySelector("#reminder-list").appendChild(newLi);
});




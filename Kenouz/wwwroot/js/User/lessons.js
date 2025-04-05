// lessons
let category = document.getElementsByClassName('category');
var categories =  Array.prototype.slice.call(category);
categories.forEach(element => {
    element.onclick =()=>{
        element.nextElementSibling.classList.toggle('display-none');
    }
});
//lessons
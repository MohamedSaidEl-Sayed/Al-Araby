let menuIcon = document.querySelector('header .menu');
let menu = document.querySelector('header .users');
let users = document.querySelectorAll('header .users .user');
let usersArr = Array.prototype.slice.call(users);
let userText = document.querySelector('header .container .desc .text');
menuIcon.onclick = function(){
    menu.classList.toggle('users-showed');
}
usersArr.forEach(element => {
    element.onclick = function(){
        userText.innerHTML = element.innerHTML;
    }
});
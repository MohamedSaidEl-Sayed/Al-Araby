let moreBtn = document.getElementsByClassName('more');
let moreBtnArr = Array.prototype.slice.call(moreBtn);
let hideBtn = document.getElementsByClassName('hide');
let hideBtnArr = Array.prototype.slice.call(hideBtn);

moreBtnArr.forEach(element => {
    element.addEventListener('click',()=>{
        element.previousElementSibling.style.height='100%';
        element.classList.add('display-none');
        element.nextElementSibling.classList.remove('display-none');
    });
});
hideBtnArr.forEach(element => {
    element.addEventListener('click',()=>{
        element.previousElementSibling.previousElementSibling.style.height='90px';
        element.classList.add('display-none');
        element.previousElementSibling.classList.remove('display-none');
    });
});


let addQuestionBtn = document.getElementById('add-question-btn');
let addQuestionForm = document.getElementById('add-question-form');
let cancelAddQuestion = document.getElementById('cancel-add-question');

addQuestionBtn.addEventListener('click',()=>{
    addQuestionForm.classList.remove('display-none');
    addQuestionBtn.classList.add('display-none');
});

cancelAddQuestion.addEventListener('click',()=>{
    addQuestionForm.classList.add('display-none');
    addQuestionBtn.classList.remove('display-none');
});
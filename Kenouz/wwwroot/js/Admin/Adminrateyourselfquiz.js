

let moreBtn = document.getElementById('more');
let hideBtn = document.getElementById('hide');
let script = document.querySelector('main .rate-yourself-quiz-page .script');

moreBtn.addEventListener('click',()=>{
    script.style.height = '100%';
    moreBtn.classList.add('display-none');
    hideBtn.classList.remove('display-none');
});
hideBtn.addEventListener('click',()=>{
    script.style.height = '90px';
    hideBtn.classList.add('display-none');
    moreBtn.classList.remove('display-none');
});

let addQuestionBtn = document.getElementById('add-question-btn');
let addQuestionForm = document.getElementById('add-question-form');
let cancelAddQuestion = document.getElementById('cancel-add-question');
let addScriptBtn = document.getElementById('add-script-btn');
let addScriptForm = document.getElementById('add-script-form');
let cancelAddScript = document.getElementById('cancel-add-script');

addQuestionBtn.addEventListener('click',()=>{
    addQuestionForm.classList.remove('display-none');
    addQuestionBtn.classList.add('display-none');
    addScriptBtn.classList.add('display-none');
});

cancelAddQuestion.addEventListener('click',()=>{
    addQuestionForm.classList.add('display-none');
    addQuestionBtn.classList.remove('display-none');
    addScriptBtn.classList.remove('display-none');
});

addScriptBtn.addEventListener('click',()=>{
    addQuestionBtn.classList.add('display-none');
    addScriptBtn.classList.add('display-none');
    addScriptForm.classList.remove('display-none');
});

cancelAddScript.addEventListener('click',()=>{
    addScriptForm.classList.add('display-none');
    addQuestionBtn.classList.remove('display-none');
    addScriptBtn.classList.remove('display-none');
})
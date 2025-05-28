//rate yourself

let level1 = document.getElementById('level1');
let level2 = document.getElementById('level2');
let level3 = document.getElementById('level3');
let allLevels = document.getElementById('all-levels');

let quizzes = document.querySelectorAll('main .rate-yourself-page .quizzes .quiz');
let quizzesArr = Array.prototype.slice.call(quizzes);

let levels = document.querySelectorAll('main .rate-yourself-page .levels .level');
let levelsArr = Array.prototype.slice.call(levels);

levelsArr.forEach(element =>{
    element.addEventListener('click',() =>{
        levelsArr.forEach(ele => {
            ele.classList.remove('selected-level');
        });
        element.classList.add('selected-level');
    });
});

level1.addEventListener('click',() => {
    quizzesArr.forEach(element =>{
        element.classList.remove('display-none'); 
        if(element.dataset.level != 'level1'){
            element.classList.add('display-none');
        }
    });
});
level2.addEventListener('click',() => {
    quizzesArr.forEach(element =>{
        element.classList.remove('display-none');
        if(element.dataset.level != 'level2'){
            element.classList.add('display-none');
        }
    });
});
level3.addEventListener('click',()=> {
    quizzesArr.forEach(element =>{
        element.classList.remove('display-none');
        if(element.dataset.level != 'level3'){
            element.classList.add('display-none');
        }
    });
});
allLevels.addEventListener('click',() => {
    quizzesArr.forEach(element =>{
        element.classList.remove('display-none');
    });
});

let newQuizForm = document.getElementById('new-quiz-form');
let newQuizOverlay = document.getElementById('new-quiz-overlay');
let newQuizBtn = document.getElementById('new-quiz-btn');
let cancelAddQuiz = document.getElementById('cancel-add-quiz');

newQuizBtn.addEventListener('click',()=>{
    newQuizOverlay.classList.remove('display-none');
    newQuizForm.classList.remove('display-none');
});

cancelAddQuiz.addEventListener('click',()=>{
    newQuizOverlay.classList.add('display-none');
    newQuizForm.classList.add('display-none');
});


let editQuizForm = document.getElementById('edit-quiz-form');
let editQuizBtn = document.getElementsByClassName('edit-quiz-btn');
let editQuizBtnArr = Array.prototype.slice.call(editQuizBtn);
let cancelEditQuiz = document.getElementById('cancel-edit-quiz');

let quizTitle = document.getElementById('quiz-title-input');
let quizLevel = document.getElementById('quiz-level-select');
let minutes = document.getElementById('minutes-select');
let classYearId = document.getElementById('class-year-id');
let quizId = document.getElementById('quiz-id');

editQuizBtnArr.forEach(element=>{
    element.addEventListener('click',()=>{
        newQuizOverlay.classList.remove('display-none');
        editQuizForm.classList.remove('display-none');
        quizTitle.value = element.dataset.name;
        quizLevel.value = element.dataset.level;
        minutes.value = element.dataset.time;
        classYearId.value = element.dataset.classyearid;
        quizId.value = element.dataset.id;
    });
})

cancelEditQuiz.addEventListener('click',()=>{
    newQuizOverlay.classList.add('display-none');
    editQuizForm.classList.add('display-none');
});


//rate yourself
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
        if(!element.classList.contains('level1')){
            element.classList.add('display-none');
        }
    });
});
level2.addEventListener('click',() => {
    quizzesArr.forEach(element =>{
        element.classList.remove('display-none');
        if(!element.classList.contains('level2')){
            element.classList.add('display-none');
        }
    });
});
level3.addEventListener('click',()=> {
    quizzesArr.forEach(element =>{
        element.classList.remove('display-none');
        if(!element.classList.contains('level3')){
            element.classList.add('display-none');
        }
    });
});
allLevels.addEventListener('click',() => {
    quizzesArr.forEach(element =>{
        element.classList.remove('display-none');
    });
});
//rate yourself
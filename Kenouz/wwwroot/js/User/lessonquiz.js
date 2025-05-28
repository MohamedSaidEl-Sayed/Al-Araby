//lessonquiz
let wellDone = document.getElementById('well-done');
let wrong = document.getElementById('wrong');
let rightAnswer = document.getElementById('right-answer');
let finishedBtn = document.getElementById('finished');
let nextBtn = document.getElementById('next');
let allRadioBtn = document.querySelectorAll(".lesson-quiz-page .question .answers .answer input[type='radio']");
let allRadioBtnArr = Array.prototype.slice.call(allRadioBtn);
let overlayLayer =document.getElementById('overlay'); //to prevent user from choose another answer after finished 
let counter = document.getElementById('counter');
let numOfQues = document.getElementById('num-of-ques');
let index = 1; // number of current question
let minutes = document.getElementById('min');
let seconds = document.getElementById('sec');
let overQues = document.getElementById('over-ques');
let numOfMin = 0;
let numOfSec = 12;
let numOfQuestions = 3;
let myInterval;

counter.innerHTML = index;
minutes.innerHTML = numOfMin;
seconds.innerHTML = numOfSec;




timer(numOfMin,numOfSec,numOfQuestions);

finishedBtn.addEventListener('click',()=>{
    allRadioBtnArr.forEach(element =>{
        if(element.checked){
            wellDone.classList.remove('display-none');
            finishedBtn.classList.add('display-none');
            if(index < numOfQuestions){
                nextBtn.classList.remove('display-none');
            }
            if(index == numOfQuestions){
                overQues.classList.remove('display-none');
            }
            overlayLayer.classList.remove('display-none');
            clearInterval(myInterval);
        }
    });
});
nextBtn.addEventListener('click',()=>{
    clearInterval(myInterval);
    timer(numOfMin,numOfSec,numOfQuestions);
    wellDone.classList.add('display-none');
    wrong.classList.add('display-none');
    rightAnswer.classList.add('display-none');
    nextBtn.classList.add('display-none');
    finishedBtn.classList.remove('display-none');
    allRadioBtnArr.forEach(element => {
        element.checked = false;
    });
    overlayLayer.classList.add('display-none');
    index++;
    counter.innerHTML = index;
});

function timer(min,sec,numofques){
    minutes.innerText = numOfMin;
    seconds.innerText = numOfSec;
    myInterval = setInterval( () =>{
        sec--;
        seconds.innerHTML = sec;
        if(sec == 59){
            min--;
            minutes.innerHTML = min;
        }
        if(sec == 0 && min !=0){
            seconds.innerHTML = 0;
            sec = 60;
        }
        if(sec==-1 && min==0 && index == numofques){
            clearInterval(myInterval);
            seconds.innerHTML = 0;
            finishedBtn.classList.add('display-none');
            overQues.classList.remove('display-none');
            overlayLayer.classList.remove('display-none');
        }
        if(sec == -1 && min == 0){
            clearInterval(myInterval);
            if(index < numofques){
                nextBtn.click();
            }
        }
        
    },1000);
}
//lessonquiz
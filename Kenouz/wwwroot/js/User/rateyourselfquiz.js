let minutes = document.getElementById('minutes');
let seconds = document.getElementById('seconds');
let quesOverlay = document.querySelectorAll('main .rate-yourself-quiz-page .questions .question .ques-overlay');
let quesOverlayArr = Array.prototype.slice.call(quesOverlay);
let numOfMin = 1;
let numOfSec = 2;

timer(numOfMin,numOfSec);

function timer(min,sec){
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
        if(sec == -1 && min == 0){
            clearInterval(myInterval);
            seconds.innerText = 0;
            quesOverlayArr.forEach(element => {
                element.classList.remove('display-none');
            });
        }
        
    },1000);
}


let bullets = document.querySelectorAll('main .nav .bullets a');
let bulletsArr = Array.prototype.slice.call(bullets);

bulletsArr.forEach(element =>{
    element.addEventListener('click',()=>{
        document.getElementById('s1q4').scrollIntoView({behavior:"smooth"},true);
    });
});


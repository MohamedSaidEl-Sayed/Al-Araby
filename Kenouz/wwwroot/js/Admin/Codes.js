let addCodeBtn = document.getElementById('add-code-btn');
let addCodeForm = document.getElementById('add-code-form');
let addCodeFormOverlay = document.getElementById('add-code-form-overlay');
let addCode = document.getElementById('add-code');
let cancelAddCode = document.getElementById('cancel-add-code');
let code = document.getElementById('code');
// let pass = document.getElementById('pass');

addCodeBtn.addEventListener('click',()=>{
    addCodeForm.classList.remove('display-none');
    addCodeFormOverlay.classList.remove('display-none');
});

cancelAddCode.addEventListener('click',()=>{
    addCodeForm.classList.add('display-none');
    addCodeFormOverlay.classList.add('display-none');
});

addCode.addEventListener('click',(event)=>{
    //pass.value = code.value;
    if(code.value.trim() == ''){
        event.preventDefault();
    }
});
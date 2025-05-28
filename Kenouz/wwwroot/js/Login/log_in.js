let code = document.getElementById('code');
let pass =document.getElementById('pass');
let submit = document.getElementById("submit");

// code.oninput = function(){
//     pass.value = code.value;
// }

submit.addEventListener('click',(event)=>{
    pass.value = code.value;
    if(code.value.trim() == ''){
        event.preventDefault();
    }
});

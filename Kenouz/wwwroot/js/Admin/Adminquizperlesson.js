let addLesson = document.getElementsByClassName('add-lesson');
let addLessonArr = Array.prototype.slice.call(addLesson);
addLessonArr.forEach(element=>{
    element.addEventListener('click',(event)=>{
        if(element.nextElementSibling.value.trim() == ''){
            event.preventDefault();
        }
    });
});

let editLessonBtns = document.getElementsByClassName('edit-lesson-btn');
let editLessonBtnsArr = Array.prototype.slice.call(editLessonBtns);
let editLessonForm = document.querySelector('main form.edit-lesson');
let editLessonInput = document.getElementById('edit-lesson-input');
let editLesson = document.getElementById('edit-lesson');
let cancelEditLesson = document.getElementById('cancel-edit-lesson');
// let lessonsPageOverlay = document.querySelector('main .lessons-page-overlay');
let testEditLessonChange;
let editLessonId= document.getElementById('edit-lesson-id');
let editLessonUnitId= document.getElementById('edit-lesson-unitId');

editLessonBtnsArr.forEach(element=>{
    element.addEventListener('click',()=>{
        lessonsPageOverlay.classList.remove('display-none');
        editLessonForm.classList.remove('display-none');
        editLessonInput.value = element.dataset.name;
        testEditLessonChange = element.dataset.name;
        editLessonId.value = element.dataset.id;
        editLessonUnitId.value = element.dataset.unitid;
    });
});
editLesson.addEventListener('click',(event)=>{
    if(editLessonInput.value.trim()=='' || editLessonInput.value == testEditLessonChange){
        event.preventDefault();
    }
});
cancelEditLesson.addEventListener('click',()=>{
    lessonsPageOverlay.classList.add('display-none');
    editLessonForm.classList.add('display-none');
});
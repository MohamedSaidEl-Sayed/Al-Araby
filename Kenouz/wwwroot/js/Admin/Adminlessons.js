// lessons
let category = document.getElementsByClassName('category');
var categories =  Array.prototype.slice.call(category);
categories.forEach(element => {
    element.onclick =()=>{
        element.nextElementSibling.classList.toggle('display-none');
    }
});

//عند الضغط علي زر التعديل فإنه يتم الضغط أيضا علي الأب الخاص بهذا الزر ولمنع هذا الأمر استخدم هذا الكود
let actionBtn = document.querySelectorAll('.category .actions .action-btn');
let actionBtnArr = Array.prototype.slice.call(actionBtn);
actionBtnArr.forEach(element =>{
    element.addEventListener('click',event =>{
        event.stopPropagation();
    });
});

let addCategory = document.getElementById('add-category');
let addCategoryInput = document.getElementById('add-category-input');
addCategory.addEventListener('click',(event)=>{
    if(addCategoryInput.value.trim() == ''){
        event.preventDefault();
    }
});

let editCategoryBtns = document.getElementsByClassName('edit-category-btn');
let editCategoryBtnsArr = Array.prototype.slice.call(editCategoryBtns);
let lessonsPageOverlay = document.querySelector('main .lessons-page-overlay');
let editCategoryForm = document.querySelector('main form.edit-category');
let editCategoryInput = document.getElementById('edit-category-input');
let editCategory = document.getElementById('edit-category');
let cancelEditCategory = document.getElementById('cancel-edit-category');
let testEditCategoryChange;
let editCategoryInputId = document.getElementById("edit-category-input-id");
let editCategoryInputClassyearId = document.getElementById("edit-category-input-classyearid");

editCategoryBtnsArr.forEach(element=>{
    element.addEventListener('click',()=>{
        lessonsPageOverlay.classList.remove('display-none');
        editCategoryForm.classList.remove('display-none');
        editCategoryInput.value = element.dataset.name;
        testEditCategoryChange = element.dataset.name;
        editCategoryInputId.value = element.dataset.id;
        editCategoryInputClassyearId.value = element.dataset.classyearid;

    });
});
editCategory.addEventListener('click',(event)=>{
    if(editCategoryInput.value.trim()=='' || editCategoryInput.value == testEditCategoryChange){
        event.preventDefault();
    }
});
cancelEditCategory.addEventListener('click',()=>{
    lessonsPageOverlay.classList.add('display-none');
    editCategoryForm.classList.add('display-none');
});

let addUnit = document.getElementsByClassName('add-unit');
let addUnitArr = Array.prototype.slice.call(addUnit);
addUnitArr.forEach(element=>{
    element.addEventListener('click',(event)=>{
        if(element.nextElementSibling.value.trim() == ''){
            event.preventDefault();
        }
    });
});

let editUnitBtns = document.getElementsByClassName('edit-unit-btn');
let editUnitBtnsArr = Array.prototype.slice.call(editUnitBtns);
let editUnitForm = document.querySelector('main form.edit-unit');
let editUnitInput = document.getElementById('edit-unit-input');
let editUnit = document.getElementById('edit-unit');
let cancelEditUnit = document.getElementById('cancel-edit-unit');
let testEditUnitChange;
let editUnitInputId = document.getElementById("edit-unit-input-id");
let editUnitInputCategoryId = document.getElementById("edit-unit-input-categoryid");


editUnitBtnsArr.forEach(element=>{
    element.addEventListener('click',()=>{
        lessonsPageOverlay.classList.remove('display-none');
        editUnitForm.classList.remove('display-none');
        editUnitInput.value = element.dataset.name;
        testEditUnitChange = element.dataset.name;
        editUnitInputId.value = element.dataset.id;
        editUnitInputCategoryId.value = element.dataset.categoryid;
    });
});
editUnit.addEventListener('click',(event)=>{
    if(editUnitInput.value.trim()=='' || editUnitInput.value == testEditUnitChange){
        event.preventDefault();
    }
});
cancelEditUnit.addEventListener('click',()=>{
    lessonsPageOverlay.classList.add('display-none');
    editUnitForm.classList.add('display-none');
});
//lessons
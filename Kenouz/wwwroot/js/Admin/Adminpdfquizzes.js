let addPdfQuizBtn = document.getElementById('add-pdf-quiz-btn');
let addPdfQuizForm = document.getElementById('add-pdf-quiz-form');
let cancelAddPdfQuiz = document.getElementById('cancel-add-pdf-quiz');

addPdfQuizBtn.addEventListener('click', () => {
    addPdfQuizForm.classList.remove('display-none');
    addPdfQuizBtn.classList.add('display-none');
});

cancelAddPdfQuiz.addEventListener('click', () => {
    addPdfQuizForm.classList.add('display-none');
    addPdfQuizBtn.classList.remove('display-none');
});

let editPdfQuizBtn = document.getElementsByClassName('edit-pdf-quiz-btn');
let editPdfQuizBtnArr = Array.prototype.slice.call(editPdfQuizBtn);
let editPdfQuizForm = document.getElementById('edit-pdf-quiz-form');
let cancelEditPdfQuiz = document.getElementById('cancel-edit-pdf-quiz');
let editPdfQuizOverlay = document.getElementById('edit-pdf-quiz-overlay');

let quizTitle = document.getElementById('edit-quiz-title');
let quizLink = document.getElementById('edit-quiz-link');
let quizId = document.getElementById('edit-quiz-id');
let classYearId = document.getElementById('edit-class-year-id');



editPdfQuizBtnArr.forEach(element => {
    element.addEventListener('click', () => {
        editPdfQuizForm.classList.remove('display-none');
        editPdfQuizOverlay.classList.remove('display-none');
        quizId.value = element.dataset.id;
        quizTitle.value = element.dataset.title;
        quizLink.value = element.dataset.link;
        classYearId.value = element.dataset.yearid;


    });
});
cancelEditPdfQuiz.addEventListener('click', () => {
    editPdfQuizForm.classList.add('display-none');
    editPdfQuizOverlay.classList.add('display-none');
});


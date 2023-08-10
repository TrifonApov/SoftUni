const BASE_URL = 'http://localhost:3030/jsonstore/tasks';
const loadBoardBtn = document.getElementById('load-board-btn');
const createTaskBtn = document.getElementById('create-task-btn');
const inputDOMSelectors = {
    title: document.getElementById('title'),
    description: document.getElementById('description'),
};
const statusToContainerMap = {
    'ToDo': document.querySelector('#todo-section > .task-list'),
    'In Progress': document.querySelector('#in-progress-section > .task-list'),
    'Code Review': document.querySelector('#code-review-section > .task-list'),
    'Done': document.querySelector('#done-section > .task-list'),
};
const statusToTextContentMap = {
    'ToDo': 'Move to In Progress',
    'In Progress': 'Move to Code Review',
    'Code Review': 'Move to Done',
};
const textContentToStatusMap = {
    'Move to In Progress': 'In Progress',
    'Move to Code Review': 'Code Review',
    'Move to Done': 'Done',
};

function attachEvents() {
    loadBoardBtn.addEventListener('click', loadBoardEventHandler);
    createTaskBtn.addEventListener('click', createTaskEventHandler);
}

async function loadBoardEventHandler() {
    clearAllSections();
    try {
        const res = await fetch(BASE_URL);
        const allTasks = await res.json();
        Object.values(allTasks)
            .forEach((task) => {
                const container = statusToContainerMap[task.status];
                const taskItemLi = createElement('li', '', container, ['task']);
                createElement('h3', task.title, taskItemLi);
                createElement('p', task.description, taskItemLi);
                const button = createElement('button', null, taskItemLi, null, task._id);
                if (task.status !== 'Done') {
                    button.textContent = statusToTextContentMap[task.status];
                    button.addEventListener('click', moveTaskHandler);
                } else {
                    button.textContent = 'Close';
                    button.addEventListener('click', deleteTaskHandler);
                }
                container.append(taskItemLi)
            })
    } catch (err) {
        console.error(err);
    }
}

function createTaskEventHandler() {
    const { title, description } = inputDOMSelectors;
    const hasInvalidInput = Object.values(inputDOMSelectors)
        .some((input) => input.value === '');
    if (hasInvalidInput) {
        return;
    }

    const headers = {
        method: 'POST',
        body: JSON.stringify({
            title: title.value,
            description: description.value,
            status: 'ToDo',
        })
    };

    fetch(BASE_URL, headers)
        .then(loadBoardEventHandler)
        .catch(console.error);

    clearAllInputs();
}

async function moveTaskHandler(e) {
    const button = e.target;
    const taskId = button.getAttribute('id');
    const headers = {
        method: 'PATCH',
        body: JSON.stringify({ status: textContentToStatusMap[button.textContent] })
    }

    fetch(`${BASE_URL}/${taskId}`, headers)
        .then(loadBoardEventHandler)
        .catch(console.error);
}

function deleteTaskHandler(e) {
    const button = e.target;
    const taskId = button.getAttribute('id');
    const headers = {
        method: 'DELETE',
    }

    fetch(`${BASE_URL}/${taskId}`, headers)
        .then(loadBoardEventHandler)
        .catch(console.error);
}

function createElement(type, content, parentNode, classes, id, useInnerHtml) {
    const element = document.createElement(type);

    if (content && useInnerHtml) {
        element.innerHTML = content;
    } else {
        if (content && type !== 'input') {
            element.textContent = content;
        }
      
        if (content && type === 'input') {
          element.value = content;
        }
    }

    if (classes && classes.length > 0) {
      element.classList.add(...classes);
    }

    if (id) {
      element.setAttribute('id', id);
    }

    if (parentNode) {
      parentNode.appendChild(element);
    }
  
    return element;
}


function clearAllSections() {
    Object.values(statusToContainerMap)
        .forEach((section) => {
            section.innerHTML = '';
        })
}

function clearAllInputs() {
    Object.values(inputDOMSelectors)
        .forEach((input) => {
            input.value = '';
        })
}


attachEvents();

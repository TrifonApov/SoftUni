window.addEventListener("load", solve);

function solve() {
    const inputSelectors = {
      studentName: document.querySelector("#student"),
      university: document.querySelector("#university"),
      score: document.querySelector("#score"),
    } 
    const selectors = {
      nextButton: document.querySelector("#next-btn"),
      previewList: document.querySelector("#preview-list"),
      
      previewList: document.querySelector("#preview-list"),
      candidatesList: document.querySelector("#candidates-list"),
      liApplication: document.querySelectorAll(".application")[0],
      applyButton: document.querySelectorAll(".apply")[0],
    };

    selectors.nextButton.addEventListener("click", next);
    
    
    
    
    function next() {
      if(!inputSelectors.studentName.value || !inputSelectors.university.value || !inputSelectors.score.value){
        console.log("Missing input info");
        return;
      }

      const applicationList = createElement("li","",["application"],"", selectors.previewList);
      
      const article = createElement("article","","","", applicationList);
      const h4 = createElement("h4",inputSelectors.studentName.value,"","", article);
      const pUniversity = createElement("p",`University: ${inputSelectors.university.value}`,"","", article);
      const pScore = createElement("p",inputSelectors.score.value,"","", article);
      
      const editBtn = createElement("button", "edit", ['action-btn', 'edit'],'',applicationList);
      const applyBtn = createElement("button", "apply", ['action-btn', 'apply'],'',applicationList);
      selectors.nextButton.disabled = true;
      Object.values(inputSelectors).forEach((selector) => {
        // selector.disabled = true;
        selector.value = ""});

      const editButton = document.querySelector("#preview-list > li > button.action-btn.edit");
      editButton.addEventListener("click", edit)

      function edit() {
        const li = document.querySelector("#preview-list > li");
        const studentName = document.querySelector("#preview-list > li > article > h4");
        inputSelectors.studentName.value = studentName.textContent;
        const university = document.querySelector("#preview-list > li > article > p:nth-child(2)");
        inputSelectors.university.value = university.textContent.replace('University: ','');
        const score = document.querySelector("#preview-list > li > article > p:nth-child(3)");
        inputSelectors.score.value = score.textContent;
        li.remove();
        selectors.nextButton.disabled = false;
        
      }


      const applyButton = document.querySelector("#preview-list > li > button.action-btn.apply");
      applyButton.addEventListener("click", apply)
      
      function apply() {
        const li = document.querySelector("#preview-list > li");
        
        const cantidates = document.querySelector("#candidates-list");
        
        cantidates.appendChild(li);
        const btn = Array.from(li.querySelectorAll(".action-btn"));
        console.log(btn);
        btn.forEach(b=>b.remove());
        selectors.nextButton.disabled = false;

      }
    }

    



    function createElement(type, textContent, classes, id, parent, useInnerHTML) {
      const element = document.createElement(type);
  
      if (useInnerHTML && textContent) {
        element.innerHTML = textContent;
      } else if (textContent) {
        element.textContent = textContent;
      }
  
      if (classes && classes.length > 0) {
        element.classList.add(...classes);
      }
  
      if (id) {
        element.setAttribute("id", id);
      }
  
      if (parent) {
        parent.appendChild(element);
      }
  
      return element;
    }
}
  
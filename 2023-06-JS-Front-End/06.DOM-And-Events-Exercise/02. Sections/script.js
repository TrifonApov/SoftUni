function create(words) {
   
   for (const word of words) {
      const element = document.createElement("div");
      const paragraph = document.createElement("p");
      paragraph.textContent = word;
      paragraph.style.display = "none";

      element.addEventListener("click", (e) => {
         const el = e.target.firstChild.style.display = "block";
      });
      
      element.appendChild(paragraph);
      document.getElementById("content").appendChild(element);
   }
}
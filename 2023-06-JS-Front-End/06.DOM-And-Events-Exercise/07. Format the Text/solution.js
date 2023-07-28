function solve() {
  const text = document.querySelector("#input").value;
  const sentences = text.split('.').filter(s=>s);
  const output = document.querySelector("#output");
  
  while (sentences.length > 0) {
    const first3 = sentences.splice(0,3).map(s=>s.trim());
    output.innerHTML += `<p>${first3.join('. ')}.</p>`;    
  }

}

// const arr = [1,2,3,4,5,6];

// const first3 = arr.splice(0,3);

// console.log(first3);



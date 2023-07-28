function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const rows = Array.from(document.querySelectorAll('tr'));
      rows.forEach(row => {
         row.classList.remove("select");
      });
      
      const cells = Array.from(document.querySelectorAll("tbody > tr > td"));
      const searchWord = document.querySelector('#searchField');
      
      cells.forEach(cell => {
         const currentCellValue = cell.textContent.toLowerCase();

         if (currentCellValue.includes(searchWord.value.toLowerCase()) && searchWord.value) {
            cell.parentElement.classList.add("select");
         }
      })
      searchWord.value = '';
   }
}
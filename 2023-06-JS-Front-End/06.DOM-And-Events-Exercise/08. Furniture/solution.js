function solve() {
    const generateBtn = document.querySelectorAll('button')[0];
    const buyBtn = document.querySelectorAll('button')[1];
    
    generateBtn.addEventListener('click', generateFurniture);

    function generateFurniture() {
      const furnitureInfo = JSON.parse(document.querySelector('textarea').value);
      
      // <tr>
      //     <th scope="col">Image</th>
      //     <th scope="col">Name</th>
      //     <th scope="col">Price</th>
      //     <th scope="col">Decoration factor</th>
      //     <th scope="col">Mark</th>
      // </tr>
      const tbody = document.querySelector('tbody');
      const row = document.createElement('tr');
      
      const imgCell = document.createElement('td');
      const img = document.createElement('img');
      img.src = furnitureInfo['img'];
      imgCell.appendChild(img);

      const nameCell = document.createElement('td');
      nameCell.textContent = furnitureInfo['name'];
      
      const priceCell = document.createElement('td');
      priceCell.textContent = furnitureInfo['price'];
      
      const decFactorCell = document.createElement('td');
      decFactorCell.textContent = furnitureInfo['decFactor'];
      
      const markCell = document.createElement('input');
      markCell.type = 'checkbox';
      markCell.name = furnitureInfo['name'];


      row.appendChild(imgCell);
      row.appendChild(nameCell);
      row.appendChild(priceCell);
      row.appendChild(decFactorCell);
      row.appendChild(markCell);
      
      tbody.appendChild(row);
      
    }

    buyBtn.addEventListener('click', purchaseInfo);

    function purchaseInfo(){
      
      
    }
}
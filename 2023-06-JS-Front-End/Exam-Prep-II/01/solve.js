function solve(inputData) {
  const products = inputData.shift().split("!");

  const commands = {
    Urgent: urgent,
    Unnecessary: unnecessary,
    Correct: correct,
    Rearrange: rearrange,
  };

  inputData.forEach((commandInfo) => {
    if (commandInfo === "Go Shopping!") {
      console.log(products.join(", "));
      return;
    }

    const args = commandInfo.split(" ");
    const command = args.shift();
    // console.log(command + ":");
    commands[command](args);
    // console.log(products);
  });

  function urgent([item]) {
    if (!products.includes(item)) {
      products.unshift(item);
    }
  }

  function unnecessary([item]) {
    if (products.includes(item)) {
      const index = products.indexOf(item);

      products.splice(index, 1);
    }
  }

  function correct([oldItem, newItem]) {
    if (products.includes(oldItem)) {
      const index = products.indexOf(oldItem);
      products[index] = newItem;
    }
  }

  function rearrange([item]) {
    if (products.includes(item)) {
      const index = products.indexOf(item);

      const product = products.splice(index, 1)[0];
      products.push(product);
    }
  }

  // console.log(products);
}

solve([
  "Tomatoes!Potatoes!Bread",
  "Unnecessary Milk",
  "Urgent Tomatoes",
  "Go Shopping!",
]);
console.log("-------------------------------------------------------");
solve([
  "Milk!Pepper!Salt!Water!Banana",
  "Urgent Salt",
  "Unnecessary Grapes",
  "Correct Pepper Onion",
  "Rearrange Grapes",
  "Correct Tomatoes Potatoes",
  "Go Shopping!",
]);

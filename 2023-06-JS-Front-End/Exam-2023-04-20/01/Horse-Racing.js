function solve(inputData) {
  const horses = inputData.shift().split("|");
  const horsesCount = horses.length;
  const commands = {
    Retake: retake,
    Rage: rage,
    Trouble: trouble,
    Miracle: miracle,
    Finish: finish,
  };

  for (const input of inputData) {
    const commandInfo = input.split(" ");
    const command = commandInfo.shift();
    commands[command](commandInfo);
    if (command == "Finish") {
      break;
    }
  }

  function retake([horse1Name, horse2Name]) {
    const indexOf1 = horses.indexOf(horse1Name);
    const indexOf2 = horses.indexOf(horse2Name);
    if (indexOf1 < indexOf2) {
      swapElements(horses, indexOf1, indexOf2);
      console.log(`${horse1Name} retakes ${horse2Name}.`);
    }
  }

  function trouble([horseName]) {
    const indexOfHorse = horses.indexOf(horseName);
    if (indexOfHorse > 0) {
      swapElements(horses, indexOfHorse - 1, indexOfHorse);

      console.log(`Trouble for ${horseName} - drops one position.`);
    }
  }

  function rage([horseName]) {
    const indexOfHorse = horses.indexOf(horseName);
    const horse = horses.splice(indexOfHorse, 1)[0];
    console.log(`${horseName} rages 2 positions ahead.`);
    if (indexOfHorse == horsesCount - 1) {
      horses.push(horse);
    } else if (indexOfHorse == horsesCount - 2) {
      horses.splice(indexOfHorse + 1, 0, horse);
    } else {
      horses.splice(indexOfHorse + 2, 0, horse);
    }
  }

  function miracle() {
    const horse = horses.shift();
    horses.push(horse);
    console.log(`What a miracle - ${horse} becomes first.`);
  }

  function finish() {
    console.log(horses.join("->"));
    console.log(`The winner is: ${horses.pop()}`);
  }

  function swapElements(arr, i1, i2) {
    arr[i1] = arr.splice(i2, 1, arr[i1])[0];
  }
}

// solve([
//   "Bella|Alexia|Sugar",
//   "Retake Alexia Sugar",
//   "Rage Bella",
//   "Trouble Bella",
//   "Finish",
// ]);
// console.log("-------------------------");
// solve([
//   "Onyx|Domino|Sugar|Fiona",
//   "Trouble Onyx",
//   "Retake Onyx Sugar",
//   "Rage Domino",
//   "Miracle",
//   "Finish",
// ]);

// console.log("-------------------------");
// solve([
//   "Fancy|Lilly",
//   "Retake Lilly Fancy",
//   "Trouble Lilly",
//   "Trouble Lilly",
//   "Finish",
//   "Rage Lilly",
// ]);
// solve(["Onyx|Domino|Sugar|Fiona", "Rage Fiona", "Finish"]);
solve(["Onyx|Domino|Sugar|Fiona", "Rage Fiona", "Finish"]);

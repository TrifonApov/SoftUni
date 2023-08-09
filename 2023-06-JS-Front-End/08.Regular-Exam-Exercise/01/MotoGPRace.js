function solve(inputData) {
  const ridersCount = inputData.shift();
  const ridersInputInfo = inputData.splice(0, ridersCount);
  const riders = {};
  const commands = {
    addRider: addRider,
    StopForFuel: stopForFuel,
    Overtaking: overtaking,
    EngineFail: engineFail,
    Finish: finish,
  };

  commands.addRider(ridersInputInfo);
  // console.log(JSON.stringify(riders, null, 2));

  inputData.forEach((curr) => {
    const commandInfo = curr.split(" - ");
    const commandName = commandInfo.shift();
    commands[commandName](commandInfo);
  });

  function addRider(ridersInputInfo) {
    ridersInputInfo.forEach((input) => {
      const [riderName, fuel, position] = input.split("|");
      riders[riderName] = {
        riderName,
        fuel: Number(fuel),
        position: Number(position),
      };
    });
  }

  function stopForFuel([riderName, minimumFuel, changedPosition]) {
    if (riders[riderName].fuel < Number(minimumFuel)) {
      riders[riderName].position = Number(changedPosition);
      console.log(
        `${riderName} stopped to refuel but lost his position, now he is ${changedPosition}.`
      );
    } else {
      console.log(`${riderName} does not need to stop for fuel!`);
    }
  }

  function overtaking([rider1Name, rider2Name]) {
    if (riders[rider1Name].position < riders[rider2Name].position) {
      [riders[rider1Name].position, riders[rider2Name].position] = [
        riders[rider2Name].position,
        riders[rider1Name].position,
      ];
      console.log(`${rider1Name} overtook ${rider2Name}!`);
    }
  }

  function engineFail([riderName, lapsLeft]) {
    delete riders[riderName];
    console.log(
      `${riderName} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`
    );
  }

  function finish() {
    Object.keys(riders).forEach((rider) => {
      console.log(rider);
      console.log(`  Final position: ${riders[rider].position}`);
    });
  }
}

solve([
  "4",
  "Valentino Rossi|100|1",
  "Marc Marquez|90|2",
  "Johann Zarco|70|4",
  "Andrea Dovizioso|60|5",
  "Overtaking - Valentino Rossi - Andrea Dovizioso",
  "StopForFuel - Johann Zarco - 80 - 3",
  "EngineFail - Marc Marquez - 5",
  "Finish",
]);

// solve([
//   "4",
//   "Valentino Rossi|100|1",
//   "Marc Marquez|90|3",
//   "Jorge Lorenzo|80|4",
//   "Johann Zarco|80|2",
//   "StopForFuel - Johann Zarco - 90 - 5",
//   "Overtaking - Marc Marquez - Jorge Lorenzo",
//   "EngineFail - Marc Marquez - 10",
//   "Finish",
// ]);

function solve(input) {
  const astronautCount = input.shift();
  const astronautInputInfo = input.splice(0, astronautCount);
  const astronauts = {};

  function explore(name, energyNeeded) {
    if (astronauts[name].energy >= Number(energyNeeded)) {
      astronauts[name].energy -= Number(energyNeeded);
      console.log(
        `${name} has successfully explored a new area and now has ${astronauts[name].energy} energy!`
      );
    } else {
      console.log(`${name} does not have enough energy to explore!`);
    }
  }

  function refuel(name, amount) {
    if (astronauts[name].energy + Number(amount) > 200) {
      console.log(
        `${name} refueled their energy by ${200 - astronauts[name].energy}!`
      );
      astronauts[name].energy = 200;
    } else {
      astronauts[name].energy += Number(amount);
      console.log(`${name} refueled their energy by ${amount}!`);
    }
  }

  function breathe(name, amount) {
    if (astronauts[name].oxygen + Number(amount) > 100) {
      console.log(
        `${name} took a breath and recovered ${
          100 - astronauts[name].oxygen
        } oxygen!`
      );
      astronauts[name].oxygen = 100;
    } else {
      astronauts[name].oxygen += Number(amount);
      console.log(`${name} took a breath and recovered ${amount} oxygen!`);
    }
  }

  astronautInputInfo.forEach((info) => {
    const [name, oxygen, energy] = info.split(" ");
    astronauts[name] = { oxygen: Number(oxygen), energy: Number(energy) };
  });

  input.forEach((info) => {
    const [command, name, amount] = info.split(" - ");

    if (command === "End") {
      Object.entries(astronauts).forEach((entry) => {
        console.log(
          `Astronaut: ${entry[0]}, Oxygen: ${entry[1].oxygen}, Energy: ${entry[1].energy}`
        );
      });
      return;
    }

    if (command === "Explore") {
      explore(name, amount);
    } else if (command === "Refuel") {
      refuel(name, amount);
    } else if (command === "Breathe") {
      breathe(name, amount);
    }
  });
}

solve([
  "4",
  "Alice 60 100",
  "Bob 40 80",
  "Charlie 70 150",
  "Dave 80 180",
  "Explore - Bob - 60",
  "Refuel - Alice - 30",
  "Breathe - Charlie - 50",
  "Refuel - Dave - 40",
  "Explore - Bob - 40",
  "Breathe - Charlie - 30",
  "Explore - Alice - 40",
  "End",
]);

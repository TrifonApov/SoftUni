function solve(inputData) {
  const initialCount = Number(inputData.shift());
  let pieces = [];

  for (let i = 0; i < initialCount; i++) {
    const [piece, composer, key] = inputData.shift().split("|");
    pieces.push({ piece, composer, key });
  }

  const commands = {
    Add: add,
    ChangeKey: changeKey,
    Remove: remove,
  };

  inputData.forEach((data) => {
    if (data === "Stop") {
      print();
      return;
    }
    const commandInfo = data.split("|");
    commands[commandInfo.shift()](commandInfo);
  });

  // Add|{piece}|{composer}|{key}
  function add([piece, composer, key]) {
    if (pieces.some((p) => p.piece === piece)) {
      console.log(`${piece} is already in the collection!`);
      return;
    }

    pieces.push({ piece, composer, key });
    console.log(`${piece} by ${composer} in ${key} added to the collection!`);
  }

  // ChangeKey|{piece}|{new key}
  function changeKey([piece, newKey]) {
    if (pieces.some((p) => p.piece === piece)) {
      pieces.filter((p) => p.piece === piece)[0].key = newKey;
      console.log(`Changed the key of ${piece} to ${newKey}!`);
      return;
    }

    console.log(
      `Invalid operation! ${piece} does not exist in the collection.`
    );
  }

  // Remove|{piece}
  function remove([piece]) {
    if (pieces.some((p) => p.piece === piece)) {
      pieces = pieces.filter((p) => p.piece !== piece);
      console.log(`Successfully removed ${piece}!`);
      return;
    }

    console.log(
      `Invalid operation! ${piece} does not exist in the collection.`
    );
  }

  // console.log(JSON.stringify(pieces, null, 2));
  // output -> {Piece} -> Composer: {composer}, Key: {key}
  function print() {
    pieces.forEach((piece) => {
      console.log(
        `${piece.piece} -> Composer: ${piece.composer}, Key: ${piece.key}`
      );
    });
  }
}

solve([
  "3",
  "Fur Elise|Beethoven|A Minor",
  "Moonlight Sonata|Beethoven|C# Minor",
  "Clair de Lune|Debussy|C# Minor",
  "Add|Sonata No.2|Chopin|B Minor",
  "Add|Hungarian Rhapsody No.2|Liszt|C# Minor",
  "Add|Fur Elise|Beethoven|C# Minor",
  "Remove|Clair de Lune",
  "ChangeKey|Moonlight Sonata|C# Major",
  "Stop",
]);
console.log("---------------------------------------------------");
solve([
  "4",
  "Eine kleine Nachtmusik|Mozart|G Major",
  "La Campanella|Liszt|G# Minor",
  "The Marriage of Figaro|Mozart|G Major",
  "Hungarian Dance No.5|Brahms|G Minor",
  "Add|Spring|Vivaldi|E Major",
  "Remove|The Marriage of Figaro",
  "Remove|Turkish March",
  "ChangeKey|Spring|C Major",
  "Add|Nocturne|Chopin|C# Minor",
  "Stop",
]);

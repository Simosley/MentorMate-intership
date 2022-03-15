function reorder(people) {
  let sum = 0;
  for (let i = 0; i < people.length; i++) {
    let scoresArr = people[i].scores;
    for (let j = 0; j < scoresArr.length; j++) {
      if (typeof scoresArr[j] === "string") {
        console.log(scoresArr[j]);
        scoresArr[j] = parseInt(scoresArr[j]);
      }
      if (
        scoresArr[j] === "no" ||
        scoresArr[j] === "yes" ||
        scoresArr[j] === null
      ) {
        scoresArr[j] = 0;
      }
    }
  }

  people.sort((a, b) => {
    let sum = 0;
    for (let i = 0; i < people.length; i++) {
      sum = people[i].scores.reduce(
        (previousValue, currentValue) => previousValue + currentValue,
        0
      );
    }
    console.log(sum);
    let firstName = a.name.toLowerCase();
    let nextName = b.name.toLowerCase();

    if (a.scores > b.scores) {
      return -1;
    }
    if (a.scores < b.scores) {
      return 1;
    }

    if (firstName < nextName) {
      return -1;
    }
    if (firstName > nextName) {
      return 1;
    }

    return 0;
  });
  return people;
}

console.log(
  reorder([
    { name: "Bob", scores: [1, 2, 1] },
    { name: "Alice", scores: [1, 2, 3] },
  ])
);

console.log(
  reorder([
    { name: "Joe", scores: [1, 2, 3] },
    { name: "Jane", scores: [1, 2, 3] },
    { name: "John", scores: [1, 2, 3] },
  ])
);

console.log(
  reorder([
    { name: "Joe", scores: [1, 2, "4.1"] },
    { name: "Jane", scores: [1, null, 3] },
    { name: "John", scores: [1, "2", 3] },
  ])
);

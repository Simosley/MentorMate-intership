function getRatios(numbers) {
  let length = numbers.length;

  let positiveCount = 0;
  let negativeCount = 0;
  let zeroCount = 0;
  let resultArr = [];
  // Traverse the array and count the
  // total number of positive, negative,
  // and zero elements.
  for (let i = 0; i < length; i++) {
    if (numbers[i] > 0) {
      positiveCount++;
    }
    if (numbers[i] < 0) {
      negativeCount++;
    }
    if (numbers[i] == 0) {
      zeroCount++;
    }
  }
  resultArr.push((positiveCount / length).toFixed(6));
  resultArr.push((negativeCount / length).toFixed(6));
  resultArr.push((zeroCount / length).toFixed(6));
  return resultArr;
}
console.log(getRatios([1, 1, 0, -1, -1]));

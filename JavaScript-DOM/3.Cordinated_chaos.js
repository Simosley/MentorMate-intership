function delay(delayTime) {
  let randomBoolean = Math.random() < 0.5;
  let timeTaken = 0;
  let secondDelayTime = delayTime + 1000;
  let thirdDelayTime = delayTime + 2000;
  const myFirstPromise = new Promise((resolve, reject) => {
    setTimeout(function () {
      if (randomBoolean == true) {
        resolve();
      } else {
        reject();
      }
    }, delayTime);
  });
  const mySecondPromise = new Promise((resolve, reject) => {
    setTimeout(function () {
      if (randomBoolean == true) {
        resolve();
      } else {
        reject();
      }
    }, secondDelayTime);
  });
  const myThirdPromise = new Promise((resolve, reject) => {
    setTimeout(function () {
      if (randomBoolean == true) {
        resolve();
      } else {
        reject();
      }
    }, thirdDelayTime);
  });

  myFirstPromise
    .then(() => {
      console.log("🎉");
      console.log(`first function took ${delayTime} milliseconds`);
      timeTaken += delayTime;
    })
    .catch(() => {
      console.log("Whoops! Something went wrong");
      console.log(`first function took ${delayTime} milliseconds`);

      timeTaken += delayTime;
    });
  mySecondPromise
    .then(() => {
      console.log("🎉");
      console.log(`second function took ${secondDelayTime} milliseconds`);
      timeTaken += secondDelayTime;
    })
    .catch(() => {
      console.log("Whoops! Something went wrong");
      console.log(`second function took ${secondDelayTime} milliseconds`);
      timeTaken += secondDelayTime;
    });
  myThirdPromise
    .then(() => {
      console.log("🎉");
      console.log(`third function took ${thirdDelayTime} milliseconds`);
      timeTaken += thirdDelayTime;
      console.log("time taken: " + timeTaken);
    })
    .catch(() => {
      console.log("Whoops! Something went wrong");
      console.log(`third function took ${thirdDelayTime} milliseconds`);
      timeTaken += thirdDelayTime;
      console.log("time taken: " + timeTaken);
    });
}
delay(1000);

function delay(delayTime) {
  const myPromise = new Promise((resolve, reject) => {
    setTimeout(function () {
      let randomBoolean = Math.random() < 0.5;

      if (randomBoolean) {
        resolve();
      } else {
        reject();
      }
    }, delayTime);
  });
  return myPromise;
}
delay(1000)
  .then(() => console.log("🎉"))
  .catch(() => console.log("Whoops! Something went wrong"));

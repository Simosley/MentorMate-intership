function delay(cb, delayTime) {
  let randomBoolean = Math.random() < 0.5;
  setTimeout(function () {
    cb(randomBoolean);
  }, delayTime);
}

delay((err) => {
  // err is a boolean passed from your delay function
  // 50% of the time is true and the other 50% of the time is false
  if (err) {
    console.log("Whoops! Something went wrong");
  } else {
    console.log("🎉");
  }
}, 1000);

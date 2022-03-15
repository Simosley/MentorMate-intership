function formatTime(time) {
  const [timeSeperator, modifier] = time.split(" ");
  let [hours, minutes, seconds] = timeSeperator.split(":");
  if (hours === "12") {
    hours = "00";
  }

  if (modifier === "PM") {
    hours = parseInt(hours, 10) + 12;
  }

  return `${hours}:${minutes}:${seconds}`;
}

console.log(formatTime("06:15:30 PM"));

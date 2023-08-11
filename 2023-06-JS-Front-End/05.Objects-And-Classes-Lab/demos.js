checkASCII("2023-06-QA-Fundamentals-Аnd-Manual-Testing");

function checkASCII(str) {
  for (let i = 0; i < str.length; i++) {
    if (
      (str.charCodeAt(i) >= 65 && str.charCodeAt(i) <= 90) ||
      (str.charCodeAt(i) >= 97 && str.charCodeAt(i) <= 122)
    ) {
    } else {
      console.log(`${i} - ${str[i]}`);
    }
  }
}

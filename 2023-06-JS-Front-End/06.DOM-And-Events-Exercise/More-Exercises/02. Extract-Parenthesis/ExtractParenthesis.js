function extract(content) {
    const regexp = /\(([A-Za-z ]+)\)/g;
    const text = document.getElementById(content).textContent;

    const array = [...text.matchAll(regexp)].map(e => e[1]);

    console.log(array.join('; '));
    return array.join('; ');
}
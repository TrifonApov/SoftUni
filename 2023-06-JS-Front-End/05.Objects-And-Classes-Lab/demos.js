const person = {
    fName: 'Trifon',
    lName: 'Apov',
    age: 35,
    info: () => `${this.fName} ${this.lName} - ${this.age}`
}


console.log(person.info());
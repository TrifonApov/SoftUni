function solve (city) {
    
    const entries = Object.entries(city);
    for (const [key, value] of entries) {
        console.log(`${key} -> ${value}`);
    }
}

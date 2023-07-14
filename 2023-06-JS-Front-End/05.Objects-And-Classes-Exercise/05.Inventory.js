function solve (input) {
    class Hero {
        constructor(name, level, items) {
            this.name = name;
            this.level = level;
            this.items = items;
        }
        
        print() {
            return `Hero: ${this.name}\nlevel => ${this.level}\nitems => ${this.items.join(', ')}`;
        }
    }

    const heroes = [];
    
    for (const entry of input) {
        
        const currentEntryInfo = entry.split(' / ');
        const name = currentEntryInfo[0];
        const level = currentEntryInfo[1];
        const items = currentEntryInfo[2].split(', ');
        
        heroes.push(new Hero(name, level, items));
    }
    
    
    heroes.sort((a,b) => a.level - b.level).forEach(hero => console.log(hero.print()));
    
}


solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]);

// solve(['Batman / 2 / Banana, Gun',
//     'Superman / 18 / Sword',
//     'Poppy / 28 / Sentinel, Antara'
// ]);
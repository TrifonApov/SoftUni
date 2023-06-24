function solve (count, typeOfGroup, day) {
    let priceForNight = 0;
    let totalPrice = 0;

    switch (day) {
        case 'Friday':
            if (typeOfGroup === 'Students') {
                priceForNight = 8.45;
                totalPrice = count * priceForNight;
                if (count >= 30) {
                    totalPrice*=0.85;
                }
            } else if(typeOfGroup === 'Business') {
                priceForNight = 10.90;
                if (count >= 100) {
                    count-=10;
                }
                totalPrice = count * priceForNight;
            } else {
                priceForNight = 15;
                totalPrice = count*priceForNight;
                if(count>= 10 && count <= 20) {
                    totalPrice*=0.95;
                }
            }
            break;
        case 'Saturday':
            if (typeOfGroup === 'Students') {
                priceForNight = 9.80;
                totalPrice = count * priceForNight;
                if (count >= 30) {
                    totalPrice*=0.85;
                }
            } else if(typeOfGroup === 'Business') {
                priceForNight = 15.60;
                if (count >= 100) {
                    count-=10;
                }
                totalPrice = count * priceForNight;
            } else {
                priceForNight = 20;
                totalPrice = count*priceForNight;
                if(count>= 10 && count <= 20) {
                    totalPrice*=0.95;
                }
            }
            break;
        case 'Sunday':
            if (typeOfGroup === 'Students') {
                priceForNight = 10.46;
                totalPrice = count * priceForNight;
                if (count >= 30) {
                    totalPrice*=0.85;
                }
            } else if(typeOfGroup === 'Business') {
                priceForNight = 16;
                if (count >= 100) {
                    count-=10;
                }
                totalPrice = count * priceForNight;
            } else {
                priceForNight = 22.50;
                totalPrice = count*priceForNight;
                if(count>= 10 && count <= 20) {
                    totalPrice*=0.95;
                }
            }
            break;
    }
    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}


solve(40, "Regular", "Sunday");
solve(30, "Students", "Sunday");
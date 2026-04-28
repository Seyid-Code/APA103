function handleDuplicates(arr) {
    const uniqueArr = [...new Set(arr)];

    const duplicatesCount = arr.length - uniqueArr.length;
    
    return {
        unikalArray: uniqueArr,
        silinenTekrarSayi: duplicatesCount
    };
}

const reqemler = [1, 2, 3, 2, 4, 5, 1, 6];
console.log("Tapşırıq 1:", handleDuplicates(reqemler)); 

function isPalindrome(word) {
    const cleanWord = word.toString().toLowerCase();
    
    const reversedWord = cleanWord.split('').reverse().join('');
    
    return cleanWord === reversedWord;
}

console.log("Tapşırıq 2 (Kelek):", isPalindrome("Kelek"));
console.log("Tapşırıq 2 (Baki):", isPalindrome("Baki"));

function countGreaterElements(arr, num) {
    const greaterElements = arr.filter(element => element > num);
    
    return greaterElements.length;
}

const ededler = [10, 25, 40, 5, 60, 15];
const yoxlananEded = 20;
console.log(`Tapşırıq 3: ${yoxlananEded} ədədi array-dəki ${countGreaterElements(ededler, yoxlananEded)} elementdən kiçikdir.`);

function checkAbundantOrDeficient(num) {
    if (num <= 0) return "Müsbət tam ədəd daxil edin.";
    
    let sum = 0;
    
    for (let i = 1; i <= num / 2; i++) {
        if (num % i === 0) {
            sum += i;
        }
    }
    
    if (sum > num) {
        return "Abundant";
    } else {
        return "Deficient";
    }
}

console.log("Tapşırıq 4 (12):", checkAbundantOrDeficient(12));
console.log("Tapşırıq 4 (13):", checkAbundantOrDeficient(13));

function squareArrayElements(arr) {
    return arr.map(element => element * element); 
}

const reqemlerArray = [2, 3, 4, 5];
console.log("Tapşırıq 5:", squareArrayElements(reqemlerArray));
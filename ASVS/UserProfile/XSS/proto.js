
const urlParams = new URLSearchParams(window.location.search);
const payload = urlParams.get('payload');

function merge(target, source) {
    for (const attr in source) {
        if (
            typeof target[attr] === "object" &&
            typeof source[attr] === "object"
        ) {
            merge(target[attr], source[attr])
        } else {
            target[attr] = source[attr]
        }
    }
}


const mergeObj = {};
console.log(payload)

/*
const testObj = JSON.parse(JSON.stringify({ x: 5, y: 6 , toString: "break toString function"}));

console.log(testObj);

let keys = Object.keys(testObj);

const mergeObj = {};

for (let key of keys) {
    mergeObj[key] = testObj[key];
}

*/
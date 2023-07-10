
const urlParams = new URLSearchParams(window.location.search);
const payload = urlParams.get('payload');

//document.write(payload)
//document.write("<script>alert(1)</script>")

//document.write('<img src="' + window.location.hash.split("#")[1])

//img_elem = document.getElementById("profile")
//img_elem.innerHTML = window.location.hash.split("#")[1]


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

const testObj = JSON.parse(JSON.stringify({ x: 5, y: 6 , __proto__ : {toString: "break toString function"}}));


merge(mergeObj, testObj)
console.log(testObj);



/*or (let key of keys) {
    mergeObj[key] = testObj[key];
}*/


function loanamt() {

    var slider = document.getElementById("loan_amt");
    var output = document.getElementById("demo");
    output.innerHTML = slider.value;
}
slider.oninput = function () {
    output.innerHTML = this.value;
}

function myfunction2() {
    var slider1 = document.getElementById("tenure");
    var output1 = document.getElementById("demo1");
    output1.innerHTML = slider1.value;
}
slider1.oninput = function () {
    output1.innerHTML = this.value;
}

function myfunction3() {
    var slider2 = document.getElementById("interest");
    var output2 = document.getElementById("demo2");
    output2.innerHTML = slider2.value;
}
slider2.oninput = function () {
    output2.innerHTML = this.value;
}
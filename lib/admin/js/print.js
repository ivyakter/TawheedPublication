function printDiv(divName) {
    var pC = document.getElementById(divName).innerHTML;
    var oC = document.body.innerHTML;

    document.body.innerHTML = pC;
    window.print();
    document.body.innerHTML = oC;
}



document.getElementById("singlebutton").addEventListener("click", myFunction);
var count=0;

function myFunction() {
  document.getElementById("singlebutton").innerHTML = "YOU CLICKED ME "+(count++)+ " TIMES!!!";
}

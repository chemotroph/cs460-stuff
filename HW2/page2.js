


document.getElementById("submit").addEventListener("click", generate);
var count=0;

function generate()
{

  var height=document.getElementById("height").value;
  var width=document.getElementById("width").value;
  document.getElementById("test").innerHTML = width+", "+height;
  var outputhtml;
  for(i=0;i<heighti++)
  {
    outputhtml=outputhtml+"<row>";
    for(j=0;j<width;j++)
    {
      outputhtml=outputhtml+"<col>"+" pooppp";
      outputhtml=outputhtml+"</col>";

    }
    outputhtml=outputhtml+"</row>";
  }
  document.getElementById("test").innerHTML=outputhtml
}

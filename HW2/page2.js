


document.getElementById("submit").addEventListener("click", generate);
var count=0;
var mines;
function generate()
{

  var height=document.getElementById("height").value;
  var width=document.getElementById("width").value;
  document.getElementById("test").innerHTML = width+", "+height;
  var outputhtml="<table>";
  mines=new Array(height);
  addMines(mines);
  for(i=0;i<mines.length;i++)
  {
    mines[i]=new Array(width);
  }

  for(i=0;i<height; i++)
  {
    outputhtml=outputhtml+"<tr>";
    for(j=0;j<width;j++)
    {
      outputhtml=outputhtml+"<td>";
      outputhtml+=  "<button id=["+i+","+j+"] onclick=clicked("+"["+i+","+j+"]"+")>?</button>";

      outputhtml=outputhtml+"</td>";

    }
    outputhtml=outputhtml+"</tr>";
  }
  outputhtml+="</table>"
  document.getElementById("test").innerHTML=outputhtml
}

function addMines(mines)
{

for(var i=0;i<mines.length;i++)
{
  for(var j=0; j<mines[0].length; i++)
  {
    mines[i][j]=0;
    if(Math.random<.2)
    {
      mines[i][j]=1;
    }
  }
}

}

function clicked(thisbutton)
{
  console.log(thisbutton);
  if(mines[thisbutton[0]][thisbutton[1]]==0)    //empty space
  {
    document.getElementById(thisbutton).innerHTML="O";      //mark as visited and display adjacent mines
  }

    //a mine
      //explodes, lose condition, css effects?

    //next to mines
      //display number of mines adjacent
}

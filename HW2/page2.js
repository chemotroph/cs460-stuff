
$(document).ready(function(){
$("#submit").click(function(){
  $("#whoops").hide();
  generate();
  $("#whoops").fadeIn(3000);
});
});



var count=0;
var mines;
var width;
var height;



function generate()
{

  height=document.getElementById("height").value;
  width=document.getElementById("width").value;
  document.getElementById("test").innerHTML = width+", "+height;
  var outputhtml="<table>";
  mines=new Array(height);

  for(i=0;i<height;i++)
  {
    mines[i]=new Array(width);
  }
  count=0;
  for(i=0;i<height; i++)
  {
    outputhtml=outputhtml+"<tr>";
    for(j=0;j<width;j++)
    {
      mines[i][j]=0;
      outputhtml=outputhtml+"<td>";
      outputhtml+=  "<button id='"+makeID(i,j)+"' onclick=clicked('"+makeID(i,j)+"')>?</button>";
      console.log(makeID(i,j));
      outputhtml=outputhtml+"</td>";

    }
    outputhtml=outputhtml+"</tr>";
  }
  outputhtml+="</table>"
  addMines();

  document.getElementById("test").innerHTML=outputhtml
}

function addMines()
{

for(var i=0;i<height;i++)
{
  for(var j=0; j<width; j++)
  {      console.log("currently mining: "+i+", "+j);

    mines[i][j]=0;
    if(Math.random()<.2)
    {
      console.log("mine added to"+i+", "+j);
      mines[i][j]=1;
    }
  }
}

}
function makeID(i, j)
{

  console.log("i is: "+i+"   j is: "+j);
  return "a"+(width*i+j);
}

function makeCoords(id)
{
  id=id.slice(1);
  console.log("ID is: "+id);
  i=Math.floor(id/width);
  j=id%width;

  console.log("output i is: "+i+" j is:" +j);
  return [i, j];
}

function clicked(thisbutton)
{
  console.log("this button is: "+thisbutton);

  var coords=makeCoords(thisbutton);
  console.log("it's Coords are: "+coords);
  if(mines[coords[0]][coords[1]]==0)    //empty space
  {
    document.getElementById(thisbutton).style.backgroundColor="green";
    document.getElementById(thisbutton).innerHTML=findadjacent(thisbutton);      //mark as visited and display adjacent mines
  }

  if(mines[coords[0]][coords[1]]==1)    //IS A MINE
  {
    document.getElementById(thisbutton).style.backgroundColor="red";
    document.getElementById(thisbutton).innerHTML="X";      //explode
    document.getElementById("lose").innerHTML="YOU LOSE";      //explode


  }
      //explodes, lose condition, css effects?

    //next to mines
      //display number of mines adjacent
}//end clicked


function findadjacent(thisbutton)
{
  var i=makeCoords(thisbutton)[0];
  var j=makeCoords(thisbutton)[1];
  var count=0;
  if(i==0 &&j==0)
  {
    if(mines[0][1]==1)
      count++;
    if(mines[1][1]==1)
      count++;
    if(mines[1][0]==1)
      count++;

    return count;
  }

  if(i==0 &&j==(width-1))
  {
    if(mines[1][j]==1)
      count++;
    if(mines[0][j-1]==1)
      count++;
    if(mines[1][j-1]==1)
      count++;

    return count;
  }

  if(i==(height-1)&&j==(width-1))
  {
    if(mines[i-1][j-1]==1)
      count++;
    if(mines[i][j-1]==1)
      count++;
    if(mines[i-1][j]==1)
      count++;

    return count;
  }

  if(i==(height-1)&&j==0)
  {
    if(mines[i][j-1]==1)
      count++;
    if(mines[i][j]==1)
      count++;
    if(mines[i][j+1]==1)
      count++;
    if(mines[i-1][j-1]==1)
      count++;
    if(mines[i-1][j]==1)
      count++;
    if(mines[i-1][j+1]==1)
      count++;
return count;

  }



  if(i==0)
  {
    if(mines[i][j-1]==1)
      count++;
    if(mines[i][j+1]==1)
      count++;
    if(mines[i+1][j]==1)
      count++;
    if(mines[i+1][j-1]==1)
      count++;
    if(mines[i+1][j-1]==1)
      count++;
    return count;
  }
  if(j==0)
  {
    if(mines[i+1][j]==1)
      count++;
    if(mines[i-1][j]==1)
      count++;
    if(mines[i][j+1]==1)
      count++;
    if(mines[i-1][j+1]==1)
      count++;
    if(mines[i+1][j+1]==1)
      count++;
    return count;
  }

  if(j==width-1)
  {
    if(mines[i+1][j])
      count++;
    if(mines[i-1][j])
      count++;
    if(mines[i-1][j-1])
      count++;
    if(mines[i][j-1])
      count++;
    if(mines[i+1][j-1])
      count++;

    return count;
  }


  if(i=(height-1))
  {
    if(mines[i][j-1]==1)
      count++;

    if(mines[i][j+1]==1)
      count++;

    if(mines[i-1][j-1]==1)
      count++;

    if(mines[i-1][j]==1)
      count++;

    if(mines[i-1][j+1]==1)
      count++;

    return count;
  }

  if(mines[i-1][j-1])
    count++;
  if(mines[i-1][j])
    count++;
  if(mines[i-1][j+1])
    count++;
  if(mines[i][j-1])
    count++;
  if(mines[i][j+1])
    count++;
  if(mines[i+1][j-1])
    count++;
  if(mines[i+1][j])
    count++;
  if(mines[i+1][j+1])
    count++;



return count;

}

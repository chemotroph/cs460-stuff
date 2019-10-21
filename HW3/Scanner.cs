using System;
using System.Text;
using System.IO;

//This class is designed to emulate the behavior of the java scanner class.
namespace lab3{

public class Scanner
{
    private string input;
    static int charIndex;


    public Scanner(string inputFile)
    {
        this.input=File.ReadAllText(inputFile);
        charIndex=0;
        //Console.WriteLine(input);
    }

    public string next()
    {
        string word="";

        
        
        
        while(charIndex<input.Length-1)     //WHILE THERE ARE STILL CHARACTERS IN THE INPUT DOCUMENT
        {
            
            
            
            if(input[charIndex]==' '||input[charIndex]=='\n'||input[charIndex]==input.Length)   //check if the current character is a space or new line or if we are out of characters
            {
                Console.WriteLine(word);    //if the character is a space/newline/we are done
                charIndex++;                //print the word
                return word;                //increment character
            }                               //return the word
            word+=input[charIndex];         //append the character to the current word
            charIndex++;                    //incriment character index
            
        }
        return word;    //final word return
    }

    public bool hasNext()
    {
        if(charIndex<input.Length-1)
            {//Console.WriteLine("Has NExt returned true!!");
            return true;
            }
        return false;
    }
    public void close()
    {

    }
}
}
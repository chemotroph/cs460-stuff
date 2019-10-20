using System;
using System.Text;
using System.IO;


namespace lab3{

public class Scanner
{
    private string input;
    private int charIndex;
    private char? currentChar;

    public Scanner(string inputFile)
    {
        this.input=File.ReadAllText(inputFile);
        currentChar=input[0];
        charIndex=0;
        Console.WriteLine(input);
    }

    public string next()
    {
        string word="";
        
        while(charIndex<input.Length&&currentChar!=' '&&currentChar!='\n')
        {
            currentChar=input[charIndex];
            charIndex++;
            word+=currentChar;
        }
        Console.WriteLine(charIndex);
        return word;
    }

    public bool hasNext()
    {
        if(charIndex<input.Length)
            return true;
        
        return false;
    }
    public void close()
    {

    }
}
}
using System.Text;
using System.IO;
using System;


/**
 * Text wrapper (from CS 345 Lab 3)
 */
 namespace lab3{
     
public class MainFile
{	
	/** Print the command line usage for this program */
	private static void printUsage()
	{
		Console.WriteLine("Usage is:\n" + 
			"\tjava Main C inputfile outputfile\n\n" +
			"Where:" + 
			"  C is the column number to fit to\n" +
			"  inputfile is the input text file \n" +
			"  outputfile is the new output file base name containing the wrapped text.\n" +
			"e.g. java Main 72 myfile.txt myfile_wrapped.txt");
	}

	/**
	 *  The main program. 
	 *
	 *@param  args  The command line arguments, see usage notes
	 */
	public static void Main( string[] args )
	{
		int C = 72;						// Column length to wrap to
		string inputFilename;
		string outputFilename = "output.txt";
		Scanner scanner = null;

		// Read the command line arguments ...
		if( args.Length != 3 )
		{
			printUsage();
            System.Environment.Exit(1);		}
		try
		{
			C = Int32.Parse(args[0]);
			inputFilename = args[1];
			outputFilename = args[2];
			scanner = new Scanner(inputFilename);
		}
		catch(FileNotFoundException e )
		{
			Console.WriteLine("Could not find the input file.");
			System.Environment.Exit(1);
		}
		catch(Exception e)
		{
			Console.WriteLine("Something is wrong with the input.");
			printUsage();
			System.Environment.Exit(1);
		}
		
		// Read words and their lengths into these vectors
		QueueInterface<string> words = new LinkedQueue<string>();
		
		// Read input file, tokenize by whitespace
		while( scanner.hasNext( ) )
		{
			string word = scanner.next();
			words.Push( word );
		}
		scanner.close();		
				
		// At this point the input text file has now been placed, word by word, into a FIFO queue
		// Each word does not have whitespaces included, but does have punctuation, numbers, etc.
		
		/* ------------------ Start here ---------------------- */
		
		// As an example, do a simple wrap
		int spacesRemaining = wrapSimply(words, C, outputFilename);
		Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining );
	} // End main()
	
	/*-----------------------------------------------------------------------
		Greedy Algorithm (Non-optimal i.e. approximate or heuristic solution)
	  -----------------------------------------------------------------------*/
	
	/**
		As an example only, write out the file directly to the output with _simple_ wrapping,
		i.e. adding spaces between words and moving to the next line if a word would go past the
		indicated column number C.  This will fail if any word length exceeds the column limit C,
		but it still goes ahead and just puts one word on that line.
	*/
	private static int wrapSimply( QueueInterface<string> words, int columnLength, string outputFilename )
	{
        
		StreamWriter output;

		try
		{
			 output = new StreamWriter( outputFilename );
		}
		catch( NullReferenceException e )
		{
			Console.WriteLine("Cannot create or open " + outputFilename +
						" for writing.  Using standard output instead." );
			 output = new StreamWriter(Console.OpenStandardOutput());
		}

		int col = 1;
		int spacesRemaining = 0;			// Running count of spaces left at the end of lines
		while( !words.IsEmpty() )
		{
			string str = words.Peek();
			int len = str.Length;
			// See if we need to wrap to the next line
			if( col == 1 )
			{
				output.Write(str);
				col += len;
				words.Pop();
			}
			else if( (col + len) >= columnLength )
			{
				// go to the next line
				output.WriteLine();
				spacesRemaining += ( columnLength - col ) + 1;
				col = 1;
			}
			else
			{	// Typical case of printing the next word on the same line
				output.Write(" ");
				output.Write(str);
				col += (len + 1);
				words.Pop();
			}
			
		}
		output.WriteLine();
		output.Flush();
		output.Close();
		return spacesRemaining;
	} // end wrapSimply
	
} // End class Main
 }//end namespace
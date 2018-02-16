using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HW12Console
{
    class Program
    {
        static void WriteUserPrompt()
        {
            try
            {
                Console.WriteLine("Enter Text to See if it's a Palidrome:");
            }
            catch
            {
                throw;
            }
        }//end WriteUserPrompt

        static string GetWord()
        {
            try
            {
                string inputWord = Console.ReadLine();
                return inputWord;
            }
            catch
            {
                throw;
            }
        }//end of GetWord

        static bool CheckForExit(ref string inputWord)
        {
            try
            {

                bool timeToExit = false;
                inputWord = inputWord.Trim();
                inputWord = inputWord.ToLower();
                if (inputWord == "exit")
                    timeToExit = true;
                return timeToExit;
            }
            catch
            {
                throw;
            }
        }//end of CheckForExit

        static string FlipWord(string inputWord)
        {
            try
            {
                char[] inputChars = inputWord.ToCharArray();//convert input to array of characters
                char[] outputChars = new char[inputChars.Length];//new array w #cells = wordlength

                int i, j;
                j = inputChars.Length;//note: if length =3, the 3rd char is in array[2]-0 based idx

                for (i = 0; i < inputChars.Length; i++)
                {
                    --j;
                    outputChars[j] = inputChars[i];
                    /*Console.WriteLine($" { outputChars[j]} { inputChars[1]}");*/
                }
                string outputWord = new string(outputChars);//convert array to string
                return outputWord;
            }
            catch
            {
                throw;
            }
        }//end of FlipWord

        static void WriteYesOrNoPalidrome(string outputWord, string inputWord)
        {
            try
            {

                if (outputWord == inputWord)
                    Console.WriteLine("Yes, this is a Palindrome!");
                else
                    Console.WriteLine("No, this is not a Palindrome!");
            }
            catch
            {
                throw;
            }
        }//end of WriteYesOrNoPalidrome

        static void WriteTryAgainOrExit()
        {
            try
            {
                Console.WriteLine("Enter Text to Try Again, or Exit to End");
            }
            catch
            {
                throw;
            }
        }//end of WriteTryAgainOrExit


        static void Main(string[] args)
        {
            try
            {
                WriteUserPrompt();
                bool exit = false;
                int ctr = 0;

                do
                {
                    string inputWord = GetWord();
                    /*Console.WriteLine($"after GetWord():  { inputWord}");*/

                    bool timeToExit = CheckForExit(ref inputWord);//trims & puts in lowercase
                    if (timeToExit == true)
                        exit = true;

                    string outputWord = FlipWord(inputWord);
                    /*Console.WriteLine($"after FlipWord():  {outputWord}");*/

                    WriteYesOrNoPalidrome(outputWord, inputWord);

                    WriteTryAgainOrExit();

                    ctr++;
                    if (ctr == 20)//cut off the user afters 15 X
                        exit = true;

                }
                while (exit == false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine($"Sorry, unexpected error has occurred");
            }

        }//end of Main
    }

}


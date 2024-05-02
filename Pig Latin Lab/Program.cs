bool runProgram = true;
while (runProgram)
{
    Console.WriteLine("Enter a word or sentence");
    string inputword = Console.ReadLine();
    string PigWord;
    int wordlength = inputword.Length;
    if (inputword.Contains(" "))
    {
        string pigSentence = "";
        do
        {
            PigLatin(out PigWord, inputword.Substring(0, inputword.IndexOf(" ")));
            pigSentence = $"{pigSentence}{PigWord} ";
            SeperateWord(out string restOfWord, inputword);
            inputword = restOfWord;
        } while (inputword.Contains(" "));
        PigLatin(out PigWord, inputword);
        pigSentence = $"{pigSentence}{PigWord} ";
        Console.WriteLine(pigSentence);
    }
    else
    {
        if (wordlength <= 0)
        {
            Console.WriteLine("No input detected, try again.");
            continue;
        }
        PigLatin(out PigWord, inputword);
        Console.WriteLine(PigWord);
    }
    while (true)
    {
        Console.WriteLine("Would you like to translate another word? y/n");
        string choice = Console.ReadLine();
        if (choice == "n")
        {
            runProgram = false;
            break;
        }
        else if (choice == "y")
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid answer");
        }
    }
}





    //methods
    static string PigLatin(out string newword, string input)
    {
    string firstletter = input.Substring(0, 1);
    int firstVowelIndex;
    newword = "";
    if(IsVowel(firstletter)) {
        newword = $"{input.Substring(1)}{firstletter}way";
        return newword;
    }
    else
    {
        int index = 0;
        while (!IsVowel(firstletter))
        {
            index++;
            newword = newword + firstletter;
            firstletter = input.Substring(index,1);

        }
        newword = $"{input.Substring(index)}{newword}ay";
        return newword;
    }
    }
static bool IsVowel(string firstletter)
{
    if( firstletter.ToLower() == "a")
    {
        return true;
    }
    if (firstletter.ToLower() == "e")
    {
        return true;
    }
    if (firstletter.ToLower() == "i")
    {
        return true;
    }
    if (firstletter.ToLower() == "o")
    {
        return true;
    }
    if (firstletter.ToLower() == "u")
    {
        return true;
    } else
    {
        return false;
    }
}

static string SeperateWord (out string restOfWord, string currentWord)
{
    restOfWord = currentWord.Substring(currentWord.IndexOf(" ") + 1);
    return restOfWord;
}
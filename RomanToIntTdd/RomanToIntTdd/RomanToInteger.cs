using System.Collections.Generic;
using System.Linq;

namespace RomanToIntTdd;

public class RomanToInteger
{
    private Dictionary<char, int> romanCharacters = new Dictionary<char, int>();

    public RomanToInteger()
    {
        romanCharacters.Add('I', 1);
        romanCharacters.Add('V', 5);
        romanCharacters.Add('X', 10);
        romanCharacters.Add('L', 50);
        romanCharacters.Add('C', 100);
        romanCharacters.Add('D', 500);
        romanCharacters.Add('M', 1000);
    }

    public int RomanToInt(string input)
    {
        var charArray = input.ToCharArray();
        var subtract = GetSubtract(charArray,'X',new[]{'L','C'});
        subtract += GetSubtract(charArray, 'I', new[] {'V', 'X'});
        subtract += GetSubtract(charArray, 'C', new[] {'D', 'M'});
        return charArray.Sum(c => romanCharacters[c])-subtract;
    }

    private int GetSubtract(char[] charArray, char leftChar, char[] RightChars)
    {
        return charArray.Where((c, i) => RightChars.Contains(c) && (i > 0 && charArray[i - 1] == leftChar))
            .Sum(c => 2*romanCharacters[leftChar]);
    }
}
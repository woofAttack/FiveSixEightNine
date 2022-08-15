using System.Text;
using System;
using System.Linq;

public class HiddenArrayNumber
{
    private const int NOT_YET_GUESS_NUMBER = -1; 
    private readonly int _lengthArrayHiddenNumbers;
    private readonly int[] _hiddenNumbers;
    private int[] _guessedNumbers;

    public HiddenArrayNumber(int[] hiddenNumbers)
    {
        _hiddenNumbers = hiddenNumbers;
        _lengthArrayHiddenNumbers = hiddenNumbers.Length;

        _guessedNumbers = GetNotYetGuessArrayNumber();
    }

    public bool TryGuessNumber(int index, int number)
    {
        IsValidIndex(index);
        IsValidNumber(number);
       
        if (_guessedNumbers[index] != NOT_YET_GUESS_NUMBER) return false;
        
        _guessedNumbers[index] = number;
        return true;
    }
    public bool IsRightGuessesNumberByIndex(int index)
    {
        IsValidIndex(index);

        return _guessedNumbers[index] == _hiddenNumbers[index];
    }
    public bool IsCompleteGuessing() 
    {
        return _guessedNumbers.Contains(NOT_YET_GUESS_NUMBER) == false;
    }
    public bool IsRightGuessed() 
    {
        return Enumerable.SequenceEqual(_guessedNumbers, _hiddenNumbers);
    }

    public bool WasNumberGuessedBy(int index)
    {
        return _guessedNumbers[index] != NOT_YET_GUESS_NUMBER;
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("GuessedNumbers: ");
        for (int i = 0, imax = _guessedNumbers.Length; i < imax; i++) 
        {
            sb.AppendLine();
            sb.AppendFormat("index {0} = {1} ", i, _guessedNumbers[i]);
        }

        return sb.ToString();
    }

    private int[] GetNotYetGuessArrayNumber() 
    {
        int[] array = new int[_lengthArrayHiddenNumbers];

        for (int i = 0, imax = _lengthArrayHiddenNumbers; i < imax; i++) 
        {
            array[i] = NOT_YET_GUESS_NUMBER;
        }

        return array;
    }
    private void IsValidIndex(int index)
    {
        if (index >= _lengthArrayHiddenNumbers) throw new Exception("Incorrect index of array");
    }
    private void IsValidNumber(int number) => RuleCorrectHiddenNumber.At(number, (x) => x >= 0 && x <= 9);
}


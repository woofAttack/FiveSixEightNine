using System.Collections.ObjectModel;
using System.Threading;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;
public class FixedNumbersForGuessing
{
    private readonly int[] FixedNumbers;
    private readonly int _lenghtArray;
    private readonly Random _randomizer;

    public FixedNumbersForGuessing(int[] fixedNumbers)
    {
        IsValidArray(fixedNumbers);
        
        FixedNumbers = fixedNumbers;
        _lenghtArray = FixedNumbers.Length;
        _randomizer =  new Random();

        Array.Sort(FixedNumbers);
    }

    public int GetRandomNumber() 
    {    
        int randomIndex = _randomizer.Next(_lenghtArray);
        return FixedNumbers[randomIndex];
    }

    public IReadOnlyCollection<int> GetFixedNumber() 
    {
        return FixedNumbers;
    }

    public override bool Equals(object obj) => Enumerable.ReferenceEquals((Array)obj, FixedNumbers);
    public bool Equals(FixedNumbersForGuessing other) => Equals(other.FixedNumbers);
    public override int GetHashCode() => 1;
    public override string ToString() => FixedNumbers.ToString();

    private void IsValidArray(int[] array)
    {
        if (array == null) throw new Exception("Array is null for FixedNumberForGuessing");
        if (array.Length == 0) throw new Exception("Array is empty for FixedNumberForGuessing");
    }
}

using System.Collections.Generic;
using System;

public interface IFactoryHiddenArrayNumbers
{
    IReadOnlyCollection<int> Product(int lenghtArray);
}

public class FactoryArrayFromFixedNumbers : IFactoryHiddenArrayNumbers
{
    private readonly FixedNumbersForGuessing _fixedNumbers;

    public FactoryArrayFromFixedNumbers(FixedNumbersForGuessing fixedNumbersForGuessing)
    {
        if (fixedNumbersForGuessing == null) throw new Exception("FixedNumbersForGuessing is null in FactoryHiddenArrayNumber");

        _fixedNumbers = fixedNumbersForGuessing;
    }

    public IReadOnlyCollection<int> Product(int lenghtArray)
    {
        Queue<int> collection = new Queue<int>();

        for(int i = 0; i < lenghtArray; i++)
        {
            collection.Enqueue(_fixedNumbers.GetRandomNumber());
        }

        return collection.ToArray();
    } 
}

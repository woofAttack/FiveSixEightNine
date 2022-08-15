using System;

public static class RuleCorrectHiddenNumber 
{
    public static bool At(int number, Func<int, bool> rule) 
    {       
        if (rule?.Invoke(number) == false) throw new Exception("Incorrect hidden number");
        return true;
    }
}

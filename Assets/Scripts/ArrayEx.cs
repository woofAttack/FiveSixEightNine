using System.Text;
using System;

public static class ArrayEx
{
    public static string ToPrint(this Array array)
    {   
        StringBuilder sb = new StringBuilder();
        
        foreach(var element in array)
        {
            sb.Append(element.ToString());
            sb.Append(" ");
        }

        return sb.ToString();
    }
}

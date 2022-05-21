namespace KVResearch.BionicReading.Library;
public class Algorithm
{
    public static int GetBoldLength(int length)
    {
        var lengthToCal = length;
        if (length <= 0)
            return lengthToCal;
        
        if (length == 3)
            lengthToCal = 2;
        else
            lengthToCal = length + 1;
        return lengthToCal / 2;
    }
}

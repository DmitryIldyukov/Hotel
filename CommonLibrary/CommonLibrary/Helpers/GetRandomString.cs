using System.Text;

namespace CommonLibrary.Helpers;

public static class RandomString
{
    public static string GetRandomString(int length)
    {
        Random random = new Random(Environment.TickCount);
    
        string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
        StringBuilder builder = new StringBuilder(length);
 
        for (int i = 0; i < length; ++i)
            builder.Append(chars[random.Next(chars.Length)]);
 
        return builder.ToString();
    }
}

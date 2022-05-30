using System.Text;
#nullable disable
namespace lab3;

public static class ArrayExtentions
{
    public static string ExtractString(this int[] array)
    {
        var sb = new StringBuilder(array.Length);
        foreach (var item in array)
        {
            sb.Append(item);
        }

        return sb.ToString();
    }
}

namespace Lab9
{
    static class StringExtender
    {
        static public bool IsPalindrom(this string s)
        {
            int middlePosition = s.Length / 2,
                lastPosition = s.Length - 1;
            for (int i=0; i < middlePosition; i++)
            {
                if (s[i] != s[lastPosition - i])
                    return false;
            }

            return true;
        }
    }
}

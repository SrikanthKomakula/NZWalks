namespace NZWalksAPI.Helpers
{
    public static class StringExtension
    {
        public static string RightSubstring(this string val1, int val2) 
        {

            return val1.Substring(val1.Length, val2);
        }
    }
}

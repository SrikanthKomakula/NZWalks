namespace NZWalksAPI.Helpers
{
    public static class MathComparisions<T>
    {

        public static bool isBothEqual(T value1, T value2)
        {
            return value1!.Equals(value2);
        }
    }
}

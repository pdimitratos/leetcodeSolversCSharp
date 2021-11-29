namespace LeetcodeSolversCSharp
{
    public static class IsPalindromeExtensions
    {
        public static bool IsPalindrome(this int x)
        {
            string forwardOrder = x.ToString();
            string reverseOrder = new string(forwardOrder.Reverse().ToArray());
            return forwardOrder == reverseOrder;
        }
    }
}
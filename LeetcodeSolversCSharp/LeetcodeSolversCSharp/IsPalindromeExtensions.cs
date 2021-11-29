namespace LeetcodeSolversCSharp
{
    public static class IsPalindromeExtensions
    {
        // https://leetcode.com/problems/palindrome-number
        /// <summary>
        /// Checks whether the integer is a palindromic string when converted.
        /// Note: always false for negative numbers
        /// </summary>
        public static bool IsPalindrome(this int x)
        {
            string forwardOrder = x.ToString();
            string reverseOrder = new string(forwardOrder.Reverse().ToArray());
            return forwardOrder == reverseOrder;
        }
    }
}
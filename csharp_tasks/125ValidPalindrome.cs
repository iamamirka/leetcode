using System.Text;
using FluentAssertions;

namespace csharp_tasks;

// https://leetcode.com/problems/valid-palindrome
public class ValidPalindrome
{
    public bool IsPalindrome(string s) {
        if (string.IsNullOrEmpty(s)) return false;
        var clearString = new string(s.Where(x => char.IsLetterOrDigit(x)).ToArray()).ToLower();
    
        return clearString == new string(clearString.Reverse().ToArray());
    }

    public bool IsPalindromeSecondApproach(string s) {
        if (string.IsNullOrEmpty(s)) return false;
        var clearString = new string(s.Where(x => char.IsLetterOrDigit(x)).ToArray()).ToLower();
        var reversedClearString = new StringBuilder();

        for (var i = clearString.Length - 1; i >= 0; i--)
            reversedClearString.Append(clearString[i]);

        return clearString == reversedClearString.ToString();
    }    
}

public class ValidPalindromeTests
{
    private readonly ValidPalindrome sut = new();

    [Test]
    [TestCaseSource(nameof(IsPalindromeCases))]
    public void IsPalindromeShouldReturnProperValues(string s, bool expected)     
    {
        var actual = sut.IsPalindrome(s);
        actual.Should().Be(expected);
    }

    [Test]
    [TestCaseSource(nameof(IsPalindromeCases))]
    public void IsPalindromeSecondApproachShouldReturnProperValues(string s, bool expected)     
    {
        var actual = sut.IsPalindromeSecondApproach(s);
        actual.Should().Be(expected);
    }

    private static IEnumerable<TestCaseData> IsPalindromeCases
    {
        get {
            // Input: s = "A man, a plan, a canal: Panama" Output: true
            yield return new TestCaseData("A man, a plan, a canal: Panama", true);
            // Input: s = "race a car" Output: false
            yield return new TestCaseData("race a car", false);
            // Input: s = "ЗаКаз" Output: true
            yield return new TestCaseData("ЗаКаз", true);
            // Input: s = "" Output: false
            yield return new TestCaseData("", false);
        }
    }
}
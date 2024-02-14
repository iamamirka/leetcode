using FluentAssertions;

namespace csharp_tasks;

// https://leetcode.com/problems/remove-element
public class Solution
{
    public int RemoveElement(int[] nums, int val) {
        var clearArray = nums.Where(x => x != val).ToArray();

        for(var i = 0; i < clearArray.Length; i++)
            nums[i] = clearArray[i];

        return clearArray.Length;
    }
}

public class RemoveElementTests
{
    private readonly Solution sut = new();

    [Test]
    [TestCaseSource(nameof(RemoveElementCases))]
    public void RemoveElementShouldReturnProperValues(int[] nums, int val, int expectedCount, int[] expectedArray) {
        var k = sut.RemoveElement(nums, val);

        k.Should().Be(expectedCount);
        // Because "The remaining elements of nums are not important as well as the size of nums", check only k elements
        nums.Take(k).Should().BeEquivalentTo(expectedArray, options => options.WithoutStrictOrdering());
    }

    private static IEnumerable<TestCaseData> RemoveElementCases
    {
        get {
            // Input: nums = [3,2,2,3], val = 3 Output: 2, nums = [2,2,0,0]
            yield return new TestCaseData(new int[]{3,2,2,3}, 3, 2, new int[]{2,2});
            // Input: nums = [0,1,2,2,3,0,4,2], val = 2 Output: 5, nums = [0,1,4,0,3,_,_,_]
            yield return new TestCaseData(new int[]{0,1,2,2,3,0,4,2}, 2, 5, new int[]{0,1,4,0,3});
            // Input: nums = [0], val = 0 Output: 5, nums = [0,1,4,0,3,_,_,_]
            //yield return new TestCaseData(new int[]{0}, 0, new int[]{1}, 1, new int[]{1});
        }
    }
}
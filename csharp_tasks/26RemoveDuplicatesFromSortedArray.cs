using FluentAssertions;

namespace csharp_tasks;

// https://leetcode.com/problems/remove-duplicates-from-sorted-array
public class RemoveDuplicatesFromSortedArray
{
    public int RemoveDuplicates(int[] nums) {
        var uniqueNums = nums.ToHashSet();
        Array.Copy(uniqueNums.ToArray(), nums, uniqueNums.Count);

        return uniqueNums.Count;
    }
}

public class RemoveDuplicatesFromSortedArrayTests
{
    private readonly RemoveDuplicatesFromSortedArray sut = new();

    [Test]
    [TestCaseSource(nameof(RemoveDuplicatesCases))]
    public void RemoveDuplicatesShouldReturnProperValues(int[] nums, int[] expectedArray) {
        var k = sut.RemoveDuplicates(nums);

        k.Should().Be(expectedArray.Length);
        // Because "The remaining elements of nums are not important as well as the size of nums", check only k elements
        nums.Take(k).Should().BeEquivalentTo(expectedArray, options => options.WithoutStrictOrdering());
    }

    private static IEnumerable<TestCaseData> RemoveDuplicatesCases
    {
        get {
            // Input: nums = [1,1,2] Output: 2, nums = [1,2,_]
            yield return new TestCaseData(new int[]{1,1,2}, new int[]{1,2});
            // Input: nums = [0,0,1,1,1,2,2,3,3,4] Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
            yield return new TestCaseData(new int[]{0,0,1,1,1,2,2,3,3,4}, new int[]{0,1,2,3,4});
        }
    }
}
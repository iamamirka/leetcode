using FluentAssertions;

namespace csharp_tasks;

// https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii
public class RemoveDuplicatesFromSortedArrayII
{
    public int RemoveDuplicates(int[] nums) {
        int end = nums.Length;
        if (end <= 2) // If the array length is less than or equal to 2, no need to remove duplicates
            return end;

        int slow = 2; // Pointer for placing the next unique element
        for (int fast = 2; fast < end; fast++)
            if (nums[slow - 2] != nums[fast]) // Check if the current element is different from the two elements before it
                nums[slow++] = nums[fast]; // Place the current element at the slow pointer and increment slow

        return slow;
    }
}

public class RemoveDuplicatesFromSortedArrayIITests
{
    private readonly RemoveDuplicatesFromSortedArrayII sut = new();

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
            // Input: nums = [1,1,1,2,2,3] Output: 5, nums = [1,1,2,2,3,_]
            yield return new TestCaseData(new int[]{1,1,1,2,2,3}, new int[]{1,1,2,2,3});
            // Input: nums = [0,0,1,1,1,1,2,3,3] Output: 7, nums = [0,0,1,1,2,3,3,_,_]
            yield return new TestCaseData(new int[]{0,0,1,1,1,1,2,3,3}, new int[]{0,0,1,1,2,3,3});
            // Input: nums = [1,1,1] Output: 2, nums = [1,1]
            yield return new TestCaseData(new int[]{1,1,1}, new int[]{1,1});
            // Input: nums = [1,1] Output: 2, nums = [1,1]
            yield return new TestCaseData(new int[]{1,1}, new int[]{1,1});
        }
    }
}
using FluentAssertions;

namespace csharp_tasks;

// https://leetcode.com/problems/merge-sorted-array/?envType=study-plan-v2&envId=top-interview-150
public class MergeSortedArrays
{
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        for (var i = 0; i < n; i++)
            nums1[i + m] = nums2[i];
        Array.Sort(nums1);
    }
}

public class MergeSortedArrayTests
{
    private readonly MergeSortedArrays sut = new();

    [Test]
    [TestCaseSource(nameof(MergeSortedArrayCases))]
    public void MergeSortedArraysShouldReturnProperValues(int[] nums1, int m, int[] nums2, int n, int[] expectedValue) {
        sut.Merge(nums1, m, nums2, n);

        nums1.Should().BeEquivalentTo(expectedValue);
    }

    private static IEnumerable<TestCaseData> MergeSortedArrayCases
    {
        get {
            // Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3 Output: [1,2,2,3,5,6]
            yield return new TestCaseData(new int[]{1,2,3,0,0,0}, 3, new int[]{2,5,6}, 3, new int[]{1,2,2,3,5,6});
            // Input: nums1 = [1], m = 1, nums2 = [], n = 0 Output: [1]
            yield return new TestCaseData(new int[]{1}, 1, new int[]{}, 0, new int[]{1});
            // Input: nums1 = [0], m = 0, nums2 = [1], n = 1 Output: [1]
            yield return new TestCaseData(new int[]{0}, 0, new int[]{1}, 1, new int[]{1});
        }
    }
}
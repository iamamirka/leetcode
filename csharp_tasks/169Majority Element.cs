using FluentAssertions;

namespace csharp_tasks;

// https://leetcode.com/problems/majority-element/
public class MajorityElementTask
{
    public int MajorityElement(int[] nums) {
        var elementsQuantityMap = new Dictionary<int, int>();

        foreach(var number in nums)
            if (elementsQuantityMap.ContainsKey(number))
                elementsQuantityMap[number] = elementsQuantityMap[number] + 1;
            else elementsQuantityMap.Add(number, 1);

        if (elementsQuantityMap.Values.Max() > (nums.Length / 2))
            return elementsQuantityMap
                    .FirstOrDefault(x => x.Value == elementsQuantityMap.Values.Max()).Key;

        return 0;
    }

    // Works only if we assume that the majority element always exists in the array
    public int MajorityElementSecondApproach(int[] nums) {
        Array.Sort(nums);

        return nums[nums.Length / 2];
    }
}

public class MajorityElementTests
{
    private readonly MajorityElementTask sut = new();

    [Test]
    [TestCaseSource(nameof(IsPalindromeCases))]
    public void MajorityElementShouldReturnProperValues(int[] nums, int expected)     
    {
        var actual = sut.MajorityElement(nums);
        actual.Should().Be(expected);
    }

    [Test]
    [TestCaseSource(nameof(IsPalindromeCases))]
    public void MajorityElementSecondApproachShouldReturnProperValues(int[] nums, int expected)     
    {
        var actual = sut.MajorityElementSecondApproach(nums);
        actual.Should().Be(expected);
    }


    private static IEnumerable<TestCaseData> IsPalindromeCases
    {
        get {
            // Input: nums = [3,2,3] Output: 3
            yield return new TestCaseData(new int[]{3,2,3}, 3);
            // Input: nums = [2,2,1,1,1,2,2] Output: 2
            yield return new TestCaseData(new int[]{2,2,1,1,1,2,2}, 2);
        }
    }
}
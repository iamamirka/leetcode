from Solution import Solution
import pytest

class TestSolution:

    test_cases = [
        ([2,7,11,15], 9, [0,1])
    ]
    @pytest.mark.parametrize("nums, target, expected", test_cases)
    def test_twoSum(self, nums: list[int], target: int, expected: list[int]):
        solution = Solution()
        actual = solution.twoSum(nums, target)
        assert actual == expected
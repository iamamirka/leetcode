class Solution:
    def twoSum(self, nums: list[int], target: int) -> list[int]:
        for num in nums:
            if num < target:
                for element in range(num, len(nums)):
                    if element == abs(target - num):
                        return [num, element]
        return []
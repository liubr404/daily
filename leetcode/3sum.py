class Solution(object):
    def threeSum(self, nums):
        """
        :type nums: List[int]
        :rtype: List[List[int]]
        """
        result = []
        nums = sorted(nums)
        if len(nums) < 3:
            return []
        else:
            for i in range(len(nums)):
                for j in range(len(nums)):
                    if i!= j:
                        nums_temp = list(filter(lambda x : nums.index(x) != i and nums.index(x)!=j,nums))
                        if -(nums[i]+nums[j]) in nums_temp:
                            temp = [nums[i],nums[j],-(nums[i]+nums[j])]
                            if sorted(temp) not in result:
                                result.append(temp) 
            return result
                

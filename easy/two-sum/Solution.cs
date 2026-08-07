// https://leetcode.com/problems/two-sum
// #hash_table
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var candidates = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; ++i) {
            if (candidates.TryGetValue(target - nums[i], out int j)) {
                return [i, j];
            }
            candidates[nums[i]] = i;
        }
        throw new InvalidOperationException();
    }
}

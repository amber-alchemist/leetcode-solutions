// https://leetcode.com/problems/unique-number-of-occurrences
// #array
class Solution {
public:
	bool uniqueOccurrences(vector<int>& arr) {
		unordered_map<int, int> occurence_by_value;
		for (int& value : arr) {
			++occurence_by_value[value];
		}
		unordered_set<int> unique_occurencies;
		for (auto& [_, occurence] : occurence_by_value) {
			auto [_, inserted] = unique_occurencies.insert(occurence);
			if (!inserted) {
				return false;
			}
		}
		return true;
	}
};

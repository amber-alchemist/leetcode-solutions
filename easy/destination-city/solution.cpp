// https://leetcode.com/problems/destination-city
// #hash_set
class Solution {
public:
	string destCity(vector<vector<string>>& paths) {
		int cities_count = paths.size();
		unordered_set<string> start_ctities;
		for (int i = 0; i < cities_count; ++i) {
			start_ctities.insert(paths[i][0]);
		}

		for (int i = 0; i < cities_count; ++i) {
			if (!start_ctities.contains(paths[i][1])) {
				return paths[i][1];
			}
		}
		throw invalid_argument("Input data doesn't contains destination city.");
	}
};

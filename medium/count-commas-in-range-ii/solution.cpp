// https://leetcode.com/problems/count-commas-in-range-ii
// #math
class Solution {
public:
	long long countCommas(long long n) {
		long long exponenta = 1e15;
		long long commas_per_number = 5LL;
		while (exponenta > n) {
			exponenta /= 1000LL;
			--commas_per_number;
		}
		long long commas_count = (n - exponenta + 1LL) * commas_per_number--;
		while (exponenta > 1000LL) {
			long long next_exponenta = exponenta / 1000LL;
			commas_count += (exponenta - next_exponenta) * commas_per_number--;
			exponenta = next_exponenta;
		}
		return commas_count;
	}
};

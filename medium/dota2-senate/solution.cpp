// https://leetcode.com/problems/dota2-senate
// #queue #greedy_algorithm
class Solution {
public:
	string predictPartyVictory(string senate) {
		queue<int> radiant_queue, dire_queue;
		int n = senate.size();
		for (int i = 0; i < n; ++i) {
			(senate[i] == 'R' ? radiant_queue : dire_queue).push(i);
		}
		int k = n;
		while (!radiant_queue.empty() && !dire_queue.empty()) {
			(radiant_queue.front() < dire_queue.front() ? radiant_queue : dire_queue).push(k++);
			radiant_queue.pop();
			dire_queue.pop();
		}
		return radiant_queue.empty() ? "Dire" : "Radiant";
	}
};

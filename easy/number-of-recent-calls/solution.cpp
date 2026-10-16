class RecentCounter {
public:
	RecentCounter() {}

	int ping(int t) {
		_requests_queue.push(t);
		int lower_border = t - 3000;
		while (_requests_queue.front() < lower_border) {
			_requests_queue.pop();
		}
		return _requests_queue.size();
	}
private:
	queue<int> _requests_queue;
};

// https://leetcode.com/problems/number-of-recent-calls
// #queue
class Solution {
public:
	vector<int> makeRequests(vector<int>& requests) {
		RecentCounter* obj = new RecentCounter();
		vector<int> responses;
		responses.reserve(requests.size());
		for (int t : requests) {
			responses.push_back(obj->ping(t));
		}
		return responses;
	}
};

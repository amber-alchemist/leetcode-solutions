struct Job {
	int end_time;
	int server_number;

	Job(int end_time, int server_number) : end_time(end_time), server_number(server_number) {}

	bool operator>(const Job& other) const {
		return end_time == other.end_time
			? server_number > other.server_number
			: end_time > other.end_time;
	}
};

// https://leetcode.com/problems/find-servers-that-handled-most-number-of-requests
// #priority_queue #hash_table
class Solution {
public:
	typedef priority_queue<Job, vector<Job>, greater<Job>> JobsQueue;

	vector<int> busiestServers(int k, vector<int>& arrival, vector<int>& load) {
		vector<int> servers_busyness(k, 0);
		set<int> available_servers;
		for (int i = 0; i < k; ++i) {
			available_servers.insert(i);
		}

		JobsQueue current_jobs;
		int requests_count = arrival.size();
		for (int i = 0; i < requests_count; ++i) {
			while (!current_jobs.empty() && current_jobs.top().end_time <= arrival[i]) {
				available_servers.insert(current_jobs.top().server_number);
				current_jobs.pop();
			}
			if (available_servers.empty()) {
				continue;
			}
			auto it = available_servers.lower_bound(i % k);
			if (it == available_servers.end()) {
				it = available_servers.begin();
			}
			int used_server = *it;
			current_jobs.push(Job(arrival[i] + load[i], used_server));
			++servers_busyness[used_server];
			available_servers.erase(it);
		}

		int max_busynes = servers_busyness[0];
		for (int i = 1; i < k; ++i) {
			if (servers_busyness[i] > max_busynes) {
				max_busynes = servers_busyness[i];
			}
		}
		vector<int> busiest_servers;
		for (int i = 0; i < k; ++i) {
			if (servers_busyness[i] == max_busynes) {
				busiest_servers.push_back(i);
			}
		}
		return busiest_servers;
	}
};

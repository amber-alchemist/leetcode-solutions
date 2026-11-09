available_servers_astruct Job {
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
// #priority_queue
class Solution {
public:
	typedef priority_queue<Job, vector<Job>, greater<Job>> JobsQueue;
	typedef priority_queue<int, vector<int>, greater<int>> AvailableServersPool;

	vector<int> busiestServers(int k, vector<int>& arrival, vector<int>& load) {
		vector<int> servers_busyness(k, 0);

		AvailableServersPool available_servers_a, available_servers_b;
		for (int i = 0; i < k; ++i) {
			available_servers_a.push(i);
		}
		AvailableServersPool& first_pool = available_servers_a;
		AvailableServersPool& second_pool = available_servers_b;

		JobsQueue current_jobs;
		int requests_count = arrival.size();
		for (int i = 0, j = 0; i < requests_count; ++i, ++j) {
			if (j == k) {
				j = 0;
				while (!second_pool.empty()) {
					first_pool.push(second_pool.top());
					second_pool.pop();
				}
			}
			while (!current_jobs.empty() && current_jobs.top().end_time <= arrival[i]) {
				int server_number = current_jobs.top().server_number;
				(server_number >= j ? first_pool : second_pool).push(server_number);
				current_jobs.pop();
			}
			int used_server = -1;
			if (!first_pool.empty()) {
				used_server = first_pool.top();
				first_pool.pop();
			}
			else if (!second_pool.empty()) {
				used_server = second_pool.top();
				second_pool.pop();
			}
			if (used_server != -1) {
				current_jobs.push(Job(arrival[i] + load[i], used_server));
				++servers_busyness[used_server];
			}
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

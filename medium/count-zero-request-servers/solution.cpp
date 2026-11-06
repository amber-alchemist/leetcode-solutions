// https://leetcode.com/problems/count-zero-request-servers
// #sorting #sliding_window
class Solution {
public:
	vector<int> countServers(int n, vector<vector<int>>& logs, int x, vector<int>& queries) {
		sort(logs.begin(), logs.end(), Solution::_comapreLogs);

		int queries_count = queries.size();
		vector<pair<int, int>> sorted_queries(queries_count);
		for (int i = 0; i < queries_count; ++i) {
			sorted_queries[i].first = queries[i];
			sorted_queries[i].second = i;
		}
		sort(sorted_queries.begin(), sorted_queries.end());

		int current_requested_servers_count = 0;
		vector<int> last_time_server_requested(n, 0);

		int logs_count = logs.size();
		int logs_begin = 0, logs_end = -1;

		vector<int> answers(queries_count);
		for (int i = 0; i < queries_count; ++i) {
			if (logs_end + 1 < logs_count) {
				int interval_end = sorted_queries[i].first;
				int request_time = logs[logs_end + 1][1];
				while (request_time <= interval_end) {
					int requested_server = logs[logs_end + 1][0] - 1;
					if (last_time_server_requested[requested_server] == 0) {
						++current_requested_servers_count;
					}
					last_time_server_requested[requested_server] = request_time;
					if (++logs_end + 1 == logs_count) {
						break;
					}
					request_time = logs[logs_end + 1][1];
				}
			}

			if (logs_begin < logs_count) {
				int interval_start = sorted_queries[i].first - x;
				int request_time = logs[logs_begin][1];
				while (request_time < interval_start) {
					int requested_server = logs[logs_begin][0] - 1;
					if (
						last_time_server_requested[requested_server] > 0 &&
						last_time_server_requested[requested_server] < interval_start
					) {
						--current_requested_servers_count;
						last_time_server_requested[requested_server] = 0;
					}
					++logs_begin;
					if (logs_begin >= logs_count) {
						break;
					}
					request_time = logs[logs_begin][1];
				}
			}

			if (logs_end + 1 < logs_begin) {
				logs_end = logs_begin - 1;
			}

			int query_index = sorted_queries[i].second;
			answers[query_index] = n - current_requested_servers_count;
		}
		return answers;
	}
private:
	static bool _comapreLogs(vector<int>& a, vector<int>& b) {
		return a[1] < b[1];
	}
};

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

		int active_servers_count = 0;
		vector<int> server_requests_count(n, 0);

		int logs_count = logs.size();
		int logs_begin = 0, logs_end = -1;

		vector<int> answers(queries_count);
		for (int i = 0; i < queries_count; ++i) {
			int interval_end = sorted_queries[i].first;
			while (logs_end + 1 < logs_count) {
				int request_time = logs[logs_end + 1][1];
				if (request_time > interval_end) {
					break;
				}
				int server_index = logs[++logs_end][0] - 1;
				if (server_requests_count[server_index]++ == 0) {
					++active_servers_count;
				}
			}

			int interval_start = sorted_queries[i].first - x;
			while (logs_begin < logs_end + 1) {
				int request_time = logs[logs_begin][1];
				if (request_time >= interval_start) {
					break;
				}
				int server_index = logs[logs_begin++][0] - 1;
				if (--server_requests_count[server_index] == 0) {
					--active_servers_count;
				}
			}

			int query_index = sorted_queries[i].second;
			answers[query_index] = n - active_servers_count;
		}
		return answers;
	}
private:
	static bool _comapreLogs(vector<int>& a, vector<int>& b) {
		return a[1] < b[1];
	}
};

struct ServerInfo {
public:
	int _weight;
	int _number;

	ServerInfo(int weight, int number) : _weight(weight), _number(number) {}

	bool operator>(const ServerInfo& other) const {
		return _weight == other._weight ? _number > other._number : _weight > other._weight;
	}
};

struct TaskQueueItem {
public:
	long long _end_time;
	ServerInfo _server_info;

	TaskQueueItem(long long end_time, const ServerInfo& server_info) : _end_time(end_time), _server_info(server_info) {}

	bool operator>(const TaskQueueItem& other) const {
		return _end_time == other._end_time ? _server_info > other._server_info : _end_time > other._end_time;
	}
};

// https://leetcode.com/problems/process-tasks-using-servers
// #priority_queue
class Solution {
public:
	vector<int> assignTasks(vector<int>& servers, vector<int>& tasks) {
		int n = servers.size(), m = tasks.size();

		priority_queue<ServerInfo, vector<ServerInfo>, greater<ServerInfo>> available_servers;
		for (int i = 0; i < n; ++i) {
			available_servers.emplace(ServerInfo(servers[i], i));
		}

		priority_queue<TaskQueueItem, vector<TaskQueueItem>, greater<TaskQueueItem>> working_servers;
		long long current_time = 0LL;
		vector<int> used_servers(m);
		for (int i = 0; i < m; ++i) {
			if (current_time < i) {
				current_time = i;
			}

			while (!working_servers.empty() && working_servers.top()._end_time <= current_time) {
				available_servers.emplace(working_servers.top()._server_info);
				working_servers.pop();
			}

			if (available_servers.empty()) {
				TaskQueueItem item = working_servers.top();
				working_servers.pop();

				current_time = item._end_time;
				working_servers.emplace(current_time + tasks[i], item._server_info);
				used_servers[i] = item._server_info._number;
			}
			else {
				ServerInfo server_info = available_servers.top();
				available_servers.pop();

				working_servers.emplace(current_time + tasks[i], server_info);
				used_servers[i] = server_info._number;
			}
		}
		return used_servers;
	}
};

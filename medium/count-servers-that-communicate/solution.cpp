// https://leetcode.com/problems/count-servers-that-communicate
// #matrix
class Solution {
public:
	int countServers(vector<vector<int>>& grid) {
		int m = grid.size(), n = grid[0].size();

		int connected_servers = 0;
		if (m == 1) {
			for (int j = 0; j < n; ++j) {
				if (grid[0][j] == 1) {
					++connected_servers;
				}
			}
		}
		else if (n == 1) {
			for (int i = 0; i < m; ++i) {
				if (grid[i][0] == 1) {
					++connected_servers;
				}
			}
		}
		else {
			const int EMPTY = -1;
			const int CONNECTED = -2;

			int servers_count = 0;
			vector<int> last_server_in_row(m, -1);
			vector<int> servers_count_in_columns(n, 0);
			for (int i = 0; i < m; ++i) {
				for (int j = 0; j < n; ++j) {
					if (grid[i][j] == 0) {
						continue;
					}
					++servers_count;
					if (last_server_in_row[i] == EMPTY) {
						last_server_in_row[i] = j;
					}
					else if (last_server_in_row[i] >= 0) {
						last_server_in_row[i] = CONNECTED;
					}
					++servers_count_in_columns[j];
				}
			}
			int not_connected_servers_count = 0;
			for (int i = 0; i < m; ++i) {
				if (last_server_in_row[i] >= 0 && servers_count_in_columns[last_server_in_row[i]] == 1) {
					++not_connected_servers_count;
				}
			}
			connected_servers = servers_count - not_connected_servers_count;
		}
		return connected_servers;
	}
};

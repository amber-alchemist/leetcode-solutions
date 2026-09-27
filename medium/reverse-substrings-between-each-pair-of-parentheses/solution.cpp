// https://leetcode.com/problems/reverse-substrings-between-each-pair-of-parentheses
// #string #queue #deque
class Solution {
public:
	string reverseParentheses(string src_str) {
		size_t src_str_length = src_str.length();
		deque<char> deque;
		queue<char> buffer_queue;
		for (size_t i = 0; i < src_str_length; ++i) {
			if (src_str[i] == ')') {
				char queue_back = deque.back();
				deque.pop_back();
				while (queue_back != '(') {
					buffer_queue.push(queue_back);
					queue_back = deque.back();
					deque.pop_back();
				}
				while (!buffer_queue.empty()) {
					deque.push_back(buffer_queue.front());
					buffer_queue.pop();
				}
			}
			else {
				deque.push_back(src_str[i]);
			}
		}
		string proccessed_string;
		while (!deque.empty()) {
			proccessed_string += deque.front();
			deque.pop_front();
		}
		return proccessed_string;
	}
};

// https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list
// #linked_list
class Solution {
public:
	ListNode* deleteMiddle(ListNode* head_ptr) {
		if (head_ptr->next == nullptr) {
			return nullptr;
		}
		ListNode* pre_slow_ptr = nullptr;
		ListNode* slow_ptr = head_ptr;
		ListNode* fast_ptr = head_ptr;
		while (fast_ptr != nullptr && fast_ptr->next != nullptr) {
			pre_slow_ptr = slow_ptr;
			slow_ptr = slow_ptr->next;
			fast_ptr = fast_ptr->next->next;
		}
		pre_slow_ptr->next = slow_ptr->next;
		return head_ptr;
	}
};

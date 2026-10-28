// https://leetcode.com/problems/odd-even-linked-list
// #linked_list
class Solution {
public:
	ListNode* oddEvenList(ListNode* head) {
		if (head == nullptr || head->next == nullptr) {
			return head;
		}
        
		ListNode* odd_tail = head;
		ListNode* even_head = head->next;
		ListNode* even_tail = even_head;

		while (even_tail != nullptr && even_tail->next != nullptr) {
			odd_tail = odd_tail->next = even_tail->next;
			even_tail = even_tail->next = even_tail->next->next;
		}

		odd_tail->next = even_head;
		return head;
	}
};

// https://leetcode.com/problems/product-of-the-last-k-numbers
// #prefix_product
class ProductOfNumbers {
public:
	ProductOfNumbers() {
		_prefix_products.push_back(1);
	}

	void add(int num) {
		if (num == 0) {
			_numbers_count = 0;
		}
		else {
			int new_prefix_product = _prefix_products[_numbers_count] * num;
			if (++_numbers_count >= _prefix_products.size()) {
				_prefix_products.push_back(new_prefix_product);
			}
			else {
				_prefix_products[_numbers_count] = new_prefix_product;
			}
		}
	}

	int getProduct(int k) {
		if (k > _numbers_count) {
			return 0;
		}
		return _prefix_products[_numbers_count] / _prefix_products[_numbers_count - k];
	}
private:
	int _numbers_count = 0;
	vector<int> _prefix_products;
};

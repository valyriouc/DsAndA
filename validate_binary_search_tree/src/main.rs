use std::cell::RefCell;
use std::ops::Deref;
use std::rc::Rc;

// https://www.geeksforgeeks.org/binary-search-tree-data-structure/
#[derive(Debug, PartialEq, Eq)]
pub struct TreeNode {
    pub val: i32,
    pub left: Option<Rc<RefCell<TreeNode>>>,
    pub right: Option<Rc<RefCell<TreeNode>>>
}

fn main() {

}


struct Solution;

impl Solution {
    pub fn is_valid_bst(root: Option<Rc<RefCell<TreeNode>>>) -> bool {
        match root {
            Some(node) => {
                let n = node.clone();
                match (n.into_inner(), n.right) {
                    (Some(left), Some(right)) => {
                        let left_val = left.borrow();
                        let right_val = right.borrow();

                        return ((*left_val.val) < (*n.val)) < (*right_val.val)
                            && Solution::is_valid_bst(left.clone())
                            && Solution::is_valid_bst(right.clone());
                    }
                    (None, Some(right)) => {
                        let right_val = right.borrow();

                        return (*n.val < *right_val.val) && Solution::is_valid_bst(right);
                    }
                    (Some(left), None) => {
                        let left_val = left.borrow();
                        return (*left_val.val < *n.val) && Solution::is_valid_bst(left);
                    }
                    (None, None) => {
                        return true;
                    }
                }
            }
            None => {
                return true;
            }
        }

    }
}


#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_valid_binary_search_tree() {
        let root = TreeNode {
            val: 2,
            left: Some(Rc::new(RefCell::new(TreeNode { val: 1, left: None, right: None}))),
            right: Some(Rc::new(RefCell::new(TreeNode { val: 3, left: None, right: None})))
        };

        let result = Solution::is_valid_bst(Some(Rc::new(RefCell::new(root))));
        assert_eq!(true, result);
    }

    #[test]
    fn test_invalid_binary_search_tree() {

    }
}
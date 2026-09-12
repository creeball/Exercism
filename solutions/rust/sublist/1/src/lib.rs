use std::collections::HashSet;

#[derive(Debug, PartialEq, Eq)]
pub enum Comparison {
    Equal,
    Sublist,
    Superlist,
    Unequal,
}

pub fn sublist(first_list: &[i32], second_list: &[i32]) -> Comparison {
    if first_list == second_list {
        Comparison::Equal
    }
    else if is_sublist(first_list, second_list) {
        Comparison::Sublist
    }
    else if is_sublist(second_list, first_list) {
        Comparison::Superlist
    }
    else {
        Comparison::Unequal
    }
}

fn is_sublist(first_list: &[i32], second_list: &[i32]) -> bool {
    if first_list.is_empty() { return true; }
    if first_list.len() > second_list.len() { return false; }
    second_list.windows(first_list.len()).any(|window| window == first_list)
}
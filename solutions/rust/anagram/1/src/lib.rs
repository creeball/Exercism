use std::collections::HashSet;

pub fn anagrams_for<'a>(word: &str, possible_anagrams: &[&'a str]) -> HashSet<&'a str> {
    let mut set = HashSet::new();
    let mut letters = word.to_lowercase().chars().collect::<Vec<_>>();
    letters.sort();
    for &anagram in possible_anagrams {
        if anagram.to_lowercase() == word.to_lowercase() { continue; }
        let mut current = anagram.to_lowercase().chars().collect::<Vec<_>>();
        current.sort();
        if current == letters {
            set.insert(anagram);
        }
    }
    set
}

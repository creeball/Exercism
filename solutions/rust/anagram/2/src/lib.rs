use std::collections::HashSet;

pub fn anagrams_for<'a>(word: &str, possible_anagrams: &[&'a str]) -> HashSet<&'a str> {
    let lowercase_word = word.to_lowercase();
    let letters: Vec<char> = to_chars(&lowercase_word);
    possible_anagrams
        .iter()
        .filter(|&&anagram| {
            let lowercase_anagram = anagram.to_lowercase();
            lowercase_anagram != lowercase_word && to_chars(&lowercase_anagram) == letters
        })
        .copied()
        .collect()
}

pub fn to_chars(s: &str) -> Vec<char> {
    let mut output = s.chars().collect::<Vec<_>>();
    output.sort();
    output
}
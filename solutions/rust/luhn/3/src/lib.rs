pub fn is_valid(code: &str) -> bool {
    let Some(digits) = code
        .bytes()
        .filter(|&c| c != b' ')
        .map(|c| char::from(c).to_digit(10))
        .collect::<Option<Vec<u32>>>()
    else { return false };
    digits.len() > 1 && digits
        .into_iter()
        .rev()
        .enumerate()
        .map(|(i, d)| { if i % 2 == 1 { double(d) } else { d } })
        .sum::<u32>() % 10 == 0
}

pub fn double(mut digit: u32) -> u32 {
    digit *= 2;
    if digit > 9 { digit = digit - 9 }
    digit
}
pub fn is_armstrong_number(num: u32) -> bool {
    let digits = to_digits(num);
    digits.iter().map(|&d| d.pow(digits.len() as u32)).sum::<u32>() == num
}

pub fn to_digits(mut num: u32) -> Vec<u32> {
    let mut digits = Vec::new();
    while num != 0 {
        digits.push(num % 10);
        num /= 10;
    }
    digits
}
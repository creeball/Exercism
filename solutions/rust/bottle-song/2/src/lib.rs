const NUMBERS: [&str; 11] = ["No", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten"];

pub fn recite(start_bottles: u32, take_down: u32) -> String {
        (start_bottles - take_down + 1..=start_bottles)
            .rev()
            .map(|bottles|
                format!(
                    "{0} green bottle{1} hanging on the wall,\n\
                    {0} green bottle{1} hanging on the wall,\n\
                    And if one green bottle should accidentally fall,\n\
                    There'll be {2} green bottle{3} hanging on the wall.",
                    NUMBERS[bottles as usize],
                    if bottles == 1 { "" } else { "s" },
                    NUMBERS[(bottles - 1) as usize].to_lowercase(),
                    if bottles - 1 == 1 { "" } else { "s" }
                )
            )
            .collect::<Vec<String>>()
            .join("\n\n")
}

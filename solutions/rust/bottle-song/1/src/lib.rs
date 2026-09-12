const NUMBERS: [&str; 11] = ["No", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten"];

pub fn recite(start_bottles: u32, take_down: u32) -> String {
        (start_bottles - take_down + 1..=start_bottles)
            .rev()
            .map(|bottles| {
                    let mut lines: Vec<String> = Vec::new();
                    lines.push(format!("{} green bottle{} hanging on the wall", NUMBERS[bottles as usize], if bottles == 1 { "" } else { "s" }));
                    lines.push((*lines[0]).to_string());
                    lines.push("And if one green bottle should accidentally fall".into());
                    lines.push(format!("There'll be {} green bottle{} hanging on the wall.", NUMBERS[bottles as usize - 1].to_lowercase(), if bottles - 1 == 1 { "" } else { "s" }));
                    lines.join(",\n")
            })
            .collect::<Vec<String>>()
            .join("\n\n")
}
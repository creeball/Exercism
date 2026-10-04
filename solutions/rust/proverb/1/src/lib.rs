pub fn build_proverb(list: &[&str]) -> String {
    if list.is_empty() { return String::new(); }
    let mut second_thing = list[0];
    let mut lines = Vec::new();
    for thing in list.iter().skip(1) {
        let first_thing = second_thing;
        second_thing = thing;
        lines.push(format!("For want of a {} the {} was lost.", first_thing, second_thing));
    }
    lines.push(format!("And all for the want of a {}.", list[0]));
    lines.join("\n")
}

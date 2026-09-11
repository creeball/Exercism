const NEIGHBOR_OFFSETS: [(isize, isize); 8] = [
    (-1, -1), (-1, 0), (-1, 1),
    (0, -1), (0, 1),
    (1, -1), (1, 0), (1, 1)
];

pub fn annotate(garden: &[&str]) -> Vec<String> {
    let rows: Vec<&[u8]> = garden.iter().map(|row| row.as_bytes()).collect();
    rows.iter()
        .enumerate()
        .map(|(y, row)| {
            row
                .iter()
                .enumerate()
                .map(|(x, &cell)| match (cell, NEIGHBOR_OFFSETS
                    .iter()
                    .filter(|&&(dy, dx)| {
                        y.checked_add_signed(dy).zip(x.checked_add_signed(dx))
                            .is_some_and(|(ny, nx)|
                                rows.get(ny).and_then(|row| row.get(nx)) == Some(&b'*'))
                    })
                    .count() as u8) {
                    (b'*', _) => '*',
                    (_, 0) => ' ',
                    (_, n) => (b'0' + n) as char
                })
                .collect::<String>() })
        .collect()
}
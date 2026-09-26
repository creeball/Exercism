pub fn nth(n: u32) -> u32 {
    let mut primes = Vec::new();
    let mut num = 2;
    while primes.len() <= n as usize {
        if primes.iter().all(|&prime| num % prime != 0) { primes.push(num); }
        num += 1;
    }
    primes[n as usize]
}

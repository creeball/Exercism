pub fn factors(n: u64) -> Vec<u64> {
    let primes = primes(n.isqrt());
    let mut factors = Vec::new();
    let mut num = n;
    for p in primes {
        while num % p == 0 {
            factors.push(p);
            num /= p;
        }
    }
    if num != 1 { factors.push(num); }
    factors
}

fn primes(n: u64) -> Vec<u64> {
    let mut primes = Vec::new();
    let mut num = 2;
    while num <= n {
        if primes.iter().take_while(|&&p| p <= num / p).all(|&p| num % p != 0) { primes.push(num); }
        num += 1;
    }
    primes
}
func classify(number: int):
	if number <= 0: return null
	var sum: int = 0;
	for i in range(1, 1 + number / 2):
		if number % i == 0: sum += i;
	if sum == number: return "perfect"
	return "deficient" if sum < number else "abundant"
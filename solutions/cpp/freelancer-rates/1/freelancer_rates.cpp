#include <cmath>

double daily_rate(double hourly_rate) {
    return hourly_rate * 8;
}

double apply_discount(double before_discount, double discount) {
    return before_discount * (100 - discount) * 0.01;
}

int monthly_rate(double hourly_rate, double discount) {
    return std::ceil(apply_discount(daily_rate(hourly_rate), discount) * 22);
}

int days_in_budget(int budget, double hourly_rate, double discount) {
    return budget / static_cast<int>(apply_discount(daily_rate(hourly_rate), discount));
}

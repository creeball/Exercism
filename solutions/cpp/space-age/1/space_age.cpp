#include "space_age.h"

namespace space_age
{
    space_age::space_age(const long long seconds) : _seconds(seconds) {}

    long long space_age::seconds() const { return _seconds; }

    double space_age::get_time(const double period) const
    {
        return static_cast<double>(static_cast<long double>(_seconds) / period);
    }

    double space_age::on_earth() const { return get_time(period::EARTH); }

    double space_age::on_mercury() const { return get_time(period::MERCURY); }

    double space_age::on_venus() const { return get_time(period::VENUS); }

    double space_age::on_mars() const { return get_time(period::MARS); }

    double space_age::on_jupiter() const { return get_time(period::JUPITER); }

    double space_age::on_saturn() const { return get_time(period::SATURN); }

    double space_age::on_uranus() const { return get_time(period::URANUS); }

    double space_age::on_neptune() const { return get_time(period::NEPTUNE); }
}

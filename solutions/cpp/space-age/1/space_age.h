#pragma once

namespace space_age
{
    namespace period
    {
        constexpr int    BASIC   = 31557600;
        constexpr double MERCURY = BASIC * 0.2408467;
        constexpr double VENUS   = BASIC * 0.61519726;
        constexpr double EARTH   = BASIC * 1.0;
        constexpr double MARS    = BASIC * 1.8808158;
        constexpr double JUPITER = BASIC * 11.862615;
        constexpr double SATURN  = BASIC * 29.447498;
        constexpr double URANUS  = BASIC * 84.016846;
        constexpr double NEPTUNE = BASIC * 164.79132;
    }

    class space_age
    {
        long long _seconds = 0;
        double get_time(double period) const;
        public:
        space_age(long long seconds);
        long long seconds() const;
        double on_earth() const;
        double on_mercury() const;
        double on_venus() const;
        double on_mars() const;
        double on_jupiter() const;
        double on_saturn() const;
        double on_uranus() const;
        double on_neptune() const;
    };
}
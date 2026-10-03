#include "doctor_data.h"

namespace heaven
{
    Vessel::Vessel(std::string name, int generation) :
        name(std::move(name)), generation(generation) { }

    Vessel::Vessel(std::string name, int generation, star_map::System current_system) :
        name(std::move(name)), generation(generation), current_system(current_system) { }

    void Vessel::make_buster()
    {
        busters++;
    }

    bool Vessel::shoot_buster()
    {
        if (busters <= 0) return false;
        busters--;
        return true;
    }

    Vessel Vessel::replicate(const std::string& name) const
    {
        return {name, generation + 1, current_system};
    }

    std::string get_older_bob(const Vessel& vessel1, const Vessel& vessel2)
    {
        return vessel1.generation < vessel2.generation ? vessel1.name : vessel2.name;
    }

    bool in_the_same_system(const Vessel &vessel1, const Vessel &vessel2)
    {
        return vessel1.current_system == vessel2.current_system;
    }
}

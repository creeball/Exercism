#include "power_of_troy.h"
#include "test/catch.hpp"

namespace troy
{
    void give_new_artifact(human &person, const std::string &artifact_name)
    {
        person.possession = std::make_unique<artifact>(artifact(artifact_name));
    }

    void exchange_artifacts(std::unique_ptr<artifact> &artifact1, std::unique_ptr<artifact> &artifact2)
    {
        std::swap(artifact1, artifact2);
    }

    void manifest_power(human &person, const std::string &power_name)
    {
        person.own_power = std::make_unique<power>(power(power_name));
    }

    void use_power(const human &influencer, human &influenced)
    {
        influenced.influenced_by = influencer.own_power;
    }

    int power_intensity(const human &person)
    {
        return person.own_power.use_count();
    }
}
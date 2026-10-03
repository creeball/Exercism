#pragma once

#include <memory>
#include <string>
#include <utility>

namespace troy
{
    struct artifact
    {
        artifact(std::string name) : name(std::move(name)) {}
        std::string name;
    };

    struct power
    {
        power(std::string effect) : effect(std::move(effect)) {}
        std::string effect;
    };

    class human
    {
        public:
        std::unique_ptr<artifact> possession = nullptr;
        std::shared_ptr<power> own_power = nullptr;
        std::shared_ptr<power> influenced_by = nullptr;
    };

    void give_new_artifact(human &person, const std::string &artifact_name);

    void exchange_artifacts(std::unique_ptr<artifact> &artifact1, std::unique_ptr<artifact> &artifact2);

    void manifest_power(human &person, const std::string &power_name);

    void use_power(const human &influencer, human &influenced);

    int power_intensity(const human &person);
}  // namespace troy

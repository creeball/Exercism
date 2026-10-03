#include "speedywagon.h"

namespace speedywagon
{
    bool connection_check(const pillar_men_sensor *sensor)
    {
        return sensor != nullptr;
    }

    int activity_counter(const pillar_men_sensor* sensors, int sensor_count)
    {
        int counter = 0;
        while (sensor_count != 0)
        {
            counter += sensors->activity;
            sensors++;
            sensor_count--;
        }
        return counter;
    }

    bool alarm_control(const pillar_men_sensor *sensors)
    {
        return connection_check(sensors) && sensors->activity != 0;
    }

    bool uv_alarm(pillar_men_sensor *sensors)
    {
        return
            connection_check(sensors) &&
            uv_light_heuristic(&sensors->data) > sensors->activity;
    }

    int uv_light_heuristic(std::vector<int>* data_array)
    {
        double avg{};
        for (auto element : *data_array) {
            avg += element;
        }
        avg /= data_array->size();
        int uv_index{};
        for (auto element : *data_array) {
            if (element > avg) ++uv_index;
        }
        return uv_index;
    }
}
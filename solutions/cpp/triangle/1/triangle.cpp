#include "triangle.h"
#include <algorithm>
#include <array>
#include <stdexcept>

namespace triangle
{
    flavor kind(const float a, const float b, const float c)
    {
        std::array<float, 3> sides = {a, b, c};
        std::sort(sides.begin(), sides.end());
        if (sides.at(2) > sides.at(1) + sides.at(0) || sides.at(0) == 0)
            throw std::domain_error("Not a triangle");
        switch ((a == b ? 1 : 0) + (b == c ? 1 : 0) + (c == a ? 1 : 0))
        {
            case 1:
                return flavor::isosceles;
            case 3:
                return flavor::equilateral;
            default:
                return flavor::scalene;
        }
    }
}
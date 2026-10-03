#include "lasagna_master.h"

namespace lasagna_master
{
    int preparationTime(const std::vector<std::string> &foods, const int each_time)
    {
        return static_cast<int>(foods.size()) * each_time;
    }

    amount quantities(const std::vector<std::string> &layers)
    {
        int noodles = 0;
        int sauce = 0;
        for (const auto& layer : layers)
        {
            if (layer == "noodles") noodles++;
            else if (layer == "sauce") sauce++;
        }
        return amount{ noodles * 50, sauce * 0.2 };
    }

    void addSecretIngredient(std::vector<std::string> &myList, const std::vector<std::string> &friendsList)
    {
        myList.at(myList.size() - 1) = friendsList.at(friendsList.size() - 1);
    }

    void addSecretIngredient(std::vector<std::string> &myList, const std::string &secretIngredient)
    {
        myList.at(myList.size() - 1) = secretIngredient;
    }

    std::vector<double> scaleRecipe(std::vector<double> quantities, const int target)
    {
        const double scale = target / 2.0;
        for (auto& quantity : quantities) quantity *= scale;
        return quantities;
    }
}
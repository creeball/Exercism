#include <string>
#include <vector>

namespace election
{
    struct ElectionResult
    {
        std::string name;
        mutable int votes = { };
    };
    int vote_count(const ElectionResult &result)
    {
        return result.votes;
    }
    void increment_vote_count(const ElectionResult &result, const int vote)
    {
        result.votes += vote;
    }
    ElectionResult& determine_result(std::vector<ElectionResult> &results)
    {
        int winner = 0;
        int i = 0;
        for (const auto &result : results)
        {
            if (result.votes > results.at(winner).votes) winner = i;
            i++;
        }
        results.at(winner).name = "President " + results.at(winner).name;
        return results.at(winner);
    }
}
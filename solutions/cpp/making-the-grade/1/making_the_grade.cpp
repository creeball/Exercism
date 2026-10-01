#include <array>
#include <string>
#include <vector>

std::vector<int> round_down_scores(std::vector<double> &student_scores)
{
    std::vector<int> output(0);
    for (auto score: student_scores)
    {
        output.push_back(static_cast<int>(score));
    }
    return output;
}

int count_failed_students(const std::vector<int> &student_scores) {
    int count = 0;
    for (const auto score: student_scores)
    {
        if (score <= 40) count++;
    }
    return count;
}

std::array<int, 4> letter_grades(int highest_score) {
    int range = (highest_score - 40) / 4;
    return
    {
        41,
        41 + range,
        41 + range * 2,
        41 + range * 3,
    };
}

std::vector<std::string> student_ranking(const std::vector<int> &student_scores, const std::vector<std::string> &student_names)
{
    std::vector<std::string> output(0);
    for (int i = 0; i < student_scores.size(); i++)
    {
        output.push_back(std::to_string(i + 1) + ". " + student_names.at(i) + ": " + std::to_string(student_scores.at(i)));
    }
    return output;
}

std::string perfect_score(std::vector<int> student_scores, std::vector<std::string> student_names)
{
    for (int i = 0; i < student_scores.size(); i++)
    {
        if (student_scores.at(i) == 100) return student_names.at(i);
    }
    return "";
}

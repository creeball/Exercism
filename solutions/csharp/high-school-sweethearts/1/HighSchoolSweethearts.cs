using System;
using System.Globalization;
public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        return $"{studentA, 29} ♡ {studentB, -29}";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        return $@"     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**{studentA,11} +  {studentB,-10}**
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        FormattableString fs = ($"{studentA} and {studentB} have been dating since {start:d} - that's {hours:n2} hours");
        return fs.ToString(CultureInfo.CreateSpecificCulture("de-DE"));
    }
}
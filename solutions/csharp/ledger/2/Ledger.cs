using System.Globalization;

public class LedgerEntry(DateTime date, string desc, decimal chg)
{
    public DateTime Date { get; } = date;
    public string Desc { get; } = desc;
    public decimal Chg { get; } = chg;
}

public static class Ledger
{
    public static LedgerEntry CreateEntry(string date, string desc, int chng) => 
        new(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0m);

    private static CultureInfo CreateCulture(string cur, string loc)
    {
        string curSym = cur switch
        {
            "USD" => "$",
            "EUR" => "€",
            _ => throw new ArgumentException("Invalid currency")
        };
        (int curNeg, string datPat) = loc switch
        {
            "en-US" => (0, "MM/dd/yyyy"),
            "nl-NL" => (12, "dd/MM/yyyy"),
            _ => throw new ArgumentException("Invalid currency")
        };
        return new CultureInfo(loc, false)
        {
            NumberFormat =
            {
                CurrencySymbol = curSym,
                CurrencyNegativePattern = curNeg
            },
            DateTimeFormat =
            {
                ShortDatePattern = datPat
            }
        };
    }

    private static string PrintHead(string loc) =>
        loc switch
        {
            "en-US" => "Date       | Description               | Change       ",
            "nl-NL" => "Datum      | Omschrijving              | Verandering  ",
            _ => throw new ArgumentException("Invalid locale")
        };

    private static string Date(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

    private static string Description(string desc) => desc.Length > 25 ? $"{desc[..22]}..." : desc;

    private static string Change(IFormatProvider culture, decimal cgh)
    {
        var result = cgh.ToString("C", culture);
        return result.StartsWith('(') ? result : $"{result} ";
    }

    private static string PrintEntry(IFormatProvider culture, LedgerEntry entry) => 
        $"{Date(culture, entry.Date)} | {Description(entry.Desc),-25} | {Change(culture, entry.Chg),13}";


    private static IEnumerable<LedgerEntry> Sort(LedgerEntry[] entries) =>
        entries
            .OrderBy(e => e.Date)
            .ThenBy(e => e.Desc)
            .ThenBy(e => e.Chg)
            .ToList();

    public static string Format(string currency, string locale, LedgerEntry[] entries) 
    {
        var culture = CreateCulture(currency, locale); 
        return string.Join("\n", new []{PrintHead(locale)}.Concat(Sort(entries).Select(e => PrintEntry(culture, e))));
    }
}

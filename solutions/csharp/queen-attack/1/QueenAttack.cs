public class Queen
{
    public int Row
    {
        get;
        private init
        {
            if (value is < 0 or > 7) throw new ArgumentOutOfRangeException();
            field = value;
        }
    }

    public int Column
    {
        get;
        private init
        {
            if (value is < 0 or > 7) throw new ArgumentOutOfRangeException();
            field = value;
        }
    }

    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black) => white.Column == black.Column || white.Row == black.Row || Math.Abs(white.Column - black.Column) == Math.Abs(white.Row - black.Row);

    public static Queen Create(int row, int column) => new(row, column);
}
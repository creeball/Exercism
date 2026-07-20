abstract class Character
{
    protected Character(string characterType)
    {
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {GetType().Name}";
    }
}

class Warrior : Character
{
    public Warrior() : base("TODO")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable()  ? 10 : 6;
    }
}

class Wizard : Character
{
    bool isPrepared = false;
    
    public Wizard() : base("TODO")
    {
    }

    public override int DamagePoints(Character target)
    {
        return isPrepared ? 12 : 3;
    }

    public void PrepareSpell()
    {
        isPrepared = true;
    }
    
    public override bool Vulnerable()
    {
        return !isPrepared;
    }
}

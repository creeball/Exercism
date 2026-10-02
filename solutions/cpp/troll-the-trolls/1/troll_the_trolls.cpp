namespace hellmath {
    enum class AccountStatus
    {
        troll,
        guest,
        user,
        mod
    };

    enum class Action
    {
        read,
        write,
        remove
    };

    bool display_post(AccountStatus poster, AccountStatus viewer)
    {
        return poster != AccountStatus::troll || viewer == AccountStatus::troll;
    }

    bool permission_check(const Action action, const AccountStatus status)
    {
        switch (status)
        {
            case AccountStatus::guest:
                return action == Action::read;
            case AccountStatus::user:
            case AccountStatus::troll:
                return action == Action::read || action == Action::write;
            case AccountStatus::mod:
                return action == Action::read || action == Action::write || action == Action::remove;
        }
        return false;
    }

    bool valid_player_combination(const AccountStatus player1, const AccountStatus player2)
    {
        return
        ((player1 == AccountStatus::mod || player1 == AccountStatus::user) &&
            (player2 == AccountStatus::mod || player2 == AccountStatus::user)) ||
        (player1 == AccountStatus::troll && player2 == AccountStatus::troll);
    }

    bool has_priority(AccountStatus account1, AccountStatus account2)
    {
        return account1 > account2;
    }
}

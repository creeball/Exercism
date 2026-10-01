namespace targets
{
    class Alien
    {
        int health = 3;
        public:
        int x_coordinate;
        int y_coordinate;

        Alien(const int x, const int y) : x_coordinate(x), y_coordinate(y) {}

        int get_health() const { return health; }

        bool hit()
        {
            if (health != 0) health--;
            return true;
        }

        bool is_alive() const { return health > 0; }

        bool teleport(const int x, const int y)
        {
            x_coordinate = x;
            y_coordinate = y;
            return true;
        }

        bool collision_detection(const Alien& other) const
        {
            return
                x_coordinate == other.x_coordinate &&
                y_coordinate == other.y_coordinate;
        }
    };
}

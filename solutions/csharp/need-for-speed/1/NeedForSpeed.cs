class RemoteControlCar
{
    private int _speed;

    public int Speed
    {
        get => _speed;
        private set => _speed = value;
    }
    
    private int _batteryDrain;

    public int BatteryDrain
    {
        get => _batteryDrain;
        private set => _batteryDrain = value;
    }

    private int _battery = 100;
    
    private int _distance = 0;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        Speed = speed;
        BatteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return _battery < _batteryDrain;
    }

    public int DistanceDriven()
    {
        return _distance;
    }

    public void Drive()
    {
        if (_battery >= _batteryDrain)
        {
            _battery -= _batteryDrain;
            _distance += Speed;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private readonly int _distance;
    
    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        return (_distance % car.Speed == 0 ? _distance / car.Speed : _distance / car.Speed + 1) <= 100 / car.BatteryDrain;
    }
}
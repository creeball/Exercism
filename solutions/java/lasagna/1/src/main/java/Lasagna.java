public class Lasagna {
    public int expectedMinutesInOven() {
        return 40;
    }

    public int remainingMinutesInOven(int minutesInOven) {
        return expectedMinutesInOven() - minutesInOven;
    }

    public int preparationTimeInMinutes(int layerCount) {
        return layerCount * 2;
    }

    public int totalTimeInMinutes(int layerCount, int minutesInOven) {
        return preparationTimeInMinutes(layerCount) + minutesInOven;
    }
}

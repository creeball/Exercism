int ovenTime() { return 40; }

int remainingOvenTime(const int actualMinutesInOven) {
    return ovenTime() - actualMinutesInOven;
}

int preparationTime(const int numberOfLayers) {
    return numberOfLayers * 2;
}

int elapsedTime(const int numberOfLayers, const int actualMinutesInOven) {
    return preparationTime(numberOfLayers) + actualMinutesInOven;
}

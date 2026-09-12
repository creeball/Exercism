class SqueakyClean {
    static String clean(String identifier) {
        boolean capitalize = false;
        StringBuilder result = new StringBuilder();
        for (char c : identifier.toCharArray()) {
            switch (c) {
                case ' ' -> result.append('_');
                case '4' -> result.append('a');
                case '3' -> result.append('e');
                case '0' -> result.append('o');
                case '1' -> result.append('l');
                case '7' -> result.append('t');
                case '-' -> capitalize = true;
                default -> {
                    if (Character.isLetter(c)) {
                        if (capitalize) {
                            c = Character.toUpperCase(c);
                            capitalize = false;
                        }
                        result.append(c);
                    }
                }
            }
        }
        return result.toString();
    }
}

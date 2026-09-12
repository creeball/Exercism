class SqueakyClean {
    static String clean(String identifier) {
        boolean capitalize = false;
        StringBuilder result = new StringBuilder();
        for (char c : identifier.toCharArray()) {
            if (c == '-') {
                capitalize = true;
                continue;
            }

            c = switch (c) {
                case ' ' -> '_';
                case '4' -> 'a';
                case '3' -> 'e';
                case '0' -> 'o';
                case '1' -> 'l';
                case '7' -> 't';
                default -> c;
            };

            if (capitalize) {
                c = Character.toUpperCase(c);
                capitalize = false;
            }

            if (c == '_' || Character.isLetter(c)) result.append(c);
        }

        return result.toString();
    }
}

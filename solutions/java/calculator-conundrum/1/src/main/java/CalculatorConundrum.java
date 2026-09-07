class CalculatorConundrum {
    public String calculate(int operand1, int operand2, String operation) {
        return String.format("%d %s %d = %d", operand1, operation, operand2, switch (operation) {
            case "+" -> add(operand1, operand2);
            case "-" -> sub(operand1, operand2);
            case "*" -> mul(operand1, operand2);
            case "/" -> div(operand1, operand2);
            case "" -> throw new IllegalArgumentException("Operation cannot be empty");
            case null -> throw new IllegalArgumentException("Operation cannot be null");
            default -> throw new IllegalOperationException(String.format("Operation '%s' does not exist", operation));
        });
    }

    private int add(int operand1, int operand2) {
        return operand1 + operand2;
    }

    private int sub(int operand1, int operand2) {
        return operand1 - operand2;
    }

    private int mul(int operand1, int operand2) {
        return operand1 * operand2;
    }

    private int div(int operand1, int operand2) {
        try {
            return operand1 / operand2;
        } catch (ArithmeticException e) {
            throw new IllegalOperationException("Division by zero is not allowed", e);
        }
    }
}

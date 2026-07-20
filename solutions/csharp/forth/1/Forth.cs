    public static class Forth
    {
        public static string Evaluate(string[] instructions)
        {
            Stack<int> stack = new();
            Dictionary<string, string[]> syntaxList = new();
            foreach (string instruction in instructions)
            {
                var strs = instruction.Split(' ');
                if (TryMatchSyntax(syntaxList, strs)) continue;
                RunCommand(stack, strs, syntaxList);
            }
            return string.Join(" ", stack.Reverse());
        }

        private static bool TryMatchSyntax(Dictionary<string, string[]> syntaxList, string[] strs)
        {
            if (strs[0] == ":")
            {
                List<string> commands = [];
                string syntaxName = !int.TryParse(strs[1], out _) ? strs[1] : throw new InvalidOperationException();
                for (int i = 2; i < strs.Length; i++)
                {
                    if (strs[i] == ";") break;
                    string command = int.TryParse(strs[i], out int num) ? num.ToString() : strs[i].ToUpper();
                    if (syntaxList.TryGetValue(command, out var value)) commands.AddRange(value);
                    else commands.Add(command);
                }
                syntaxList[syntaxName.ToUpper()] = commands.ToArray();
                return true;
            }
            return false;
        }

        private static void Execute(Stack<int> stack, string mode)
        {
            switch (mode.ToUpper())
            {
                case "+":
                    stack.Add();
                    break;
                case "-":
                    stack.Sub();
                    break;
                case "*":
                    stack.Mul();
                    break;
                case "/":
                    stack.Div();
                    break;
                case "DUP":
                    stack.Dup();
                    break;
                case "DROP":
                    stack.Drop();
                    break;
                case "SWAP":
                    stack.Swap();
                    break;
                case "OVER":
                    stack.Over();
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        private static void RunCommand(Stack<int> stack, string[] commands, Dictionary<string, string[]> syntaxList)
        {
            foreach (var command in commands)
            {
                if (int.TryParse(command, out int num)) stack.Push(num);
                else if (syntaxList.TryGetValue(command.ToUpper(), out var syntax)) RunCommand(stack, syntax, syntaxList);
                else Execute(stack, command);
            }
        }

        extension(Stack<int> stack)
        {
            private void Add()
            {
                stack.Check(2);
                stack.Push(stack.Pop() + stack.Pop());
            }

            private void Sub()
            {
                stack.Check(2);
                int temp = stack.Pop();
                stack.Push(stack.Pop() - temp);
            }

            private void Mul()
            {
                stack.Check(2);
                stack.Push(stack.Pop() * stack.Pop());
            }

            private void Div()
            {
                stack.Check(2);
                int temp = stack.Pop();
                if (temp == 0) throw new DivideByZeroException();
                stack.Push(stack.Pop() / temp);
            }

            private void Dup()
            {
                stack.Check(1);
                stack.Push(stack.Peek());
            }

            private void Drop()
            {
                stack.Check(1);
                stack.Pop();
            }

            private void Swap()
            {
                stack.Check(2);
                (int a, int b) temp = (stack.Pop(), stack.Pop());
                stack.Push(temp.a);
                stack.Push(temp.b);
            }

            private void Over()
            {
                stack.Check(2);
                (int a, int b) temp = (stack.Pop(), stack.Pop());
                stack.Push(temp.b);
                stack.Push(temp.a);
                stack.Push(temp.b);
            }

            private void Check(int num)
            {
                if (stack.Count < num) throw new InvalidOperationException();
            }
        }
    }
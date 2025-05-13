using System.IO;

namespace solution.day3
{
    public class Scanner
    {
        public string? Source { get; set; }
        public string? Path { get; set; }

        public Scanner(string path)
        {
            Path = path;
        }

        private string ReadFile()
        {
            return File.ReadAllText(Path);
        }
        public List<Token> ProcessFile()
        {
            Source = ReadFile();
            return Tokenize();
        }

        private List<Token> Tokenize()
        {
            List<Token> tokens = new List<Token>();

            HashSet<char> validChars = new HashSet<char>
            {
                '(', ')', ',',
                'm', //to start the mul
                'd' //to start the do() and don't()
            };

            HashSet<char> numbers = new HashSet<char>
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };

            int n = Source.Length;
            int current = 0;

            while (current < n)
            {
                char currentChar = Source[current];

                if (!validChars.Contains(currentChar) && !numbers.Contains(currentChar))
                {
                    tokens.Add(new Token(TokenType.INVALID, currentChar.ToString()));
                }
                else
                {
                    string val = currentChar.ToString();
                    if (currentChar == '(')
                    {
                        tokens.Add(new Token(TokenType.OPENING_PAREN, val));
                    }
                    else if (currentChar == ')')
                    {
                        tokens.Add(new Token(TokenType.CLOSING_PAREN, val));
                    }
                    else if (currentChar == ',') //numbers
                    {
                        tokens.Add(new Token(TokenType.COMMA, val));
                    }
                    else if (currentChar == 'm')
                    {
                        // //look ahead for two steps
                        // char next = Source[current + 1];
                        // char nextNext = Source[current + 2];

                        // if (next == 'u' && nextNext == 'l')
                        // {
                        //     tokens.Add(new Token(TokenType.MULTIPLY, "mul"));
                        //     current += 2;
                        // }
                        string potentialValid = "";
                        int tempCurrent = current;
                        while (Source[tempCurrent] != 'l')
                        {
                            potentialValid += Source[tempCurrent++];
                        }

                        potentialValid += Source[tempCurrent];

                        if (potentialValid == "mul")
                        {
                            tokens.Add(new Token(TokenType.MULTIPLY, "mul"));
                            current = tempCurrent;
                        }
                    }
                    else if (currentChar == 'd')
                    {
                        string potentialValid = "";
                        int tempCurrent = current;

                        while (Source[tempCurrent] != ')')
                        {
                            potentialValid += Source[tempCurrent++];
                        }

                        //meaning pag end equal na siya to ')' closing paren
                        potentialValid += Source[tempCurrent]; //dapat equal to sha do or dont

                        if (potentialValid == "do()")
                        {
                            tokens.Add(new Token(TokenType.DO, potentialValid));
                            current = tempCurrent;
                        }

                        if (potentialValid == "don't()")
                        {
                            tokens.Add(new Token(TokenType.DO_NOT, potentialValid));
                            current = tempCurrent;
                        }
                    }
                    else //meaning number nani diri
                    {
                        string num = "";
                        while (numbers.Contains(Source[current]))
                        {
                            num += Source[current++].ToString();
                        }

                        tokens.Add(new Token(TokenType.NUMBER, num));
                        continue;
                    }
                }

                current++;
            }

            return tokens;
        }
    }
}
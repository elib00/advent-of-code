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
                'm' //to start the mul
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
                        //look ahead for two steps
                        char next = Source[current + 1];
                        char nextNext = Source[current + 2];

                        if (next == 'u' && nextNext == 'l')
                        {
                            tokens.Add(new Token(TokenType.MULTIPLY, "mul"));
                            current += 2;
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
namespace solution.day3
{
    public class Parser
    {
        private List<Token> Tokens { get; set; }
        private int Current { get; set; }

        public Parser(List<Token> tokens)
        {
            Tokens = tokens;
        }

        private List<int> Parse()
        {
            List<int> products = new List<int>();
            int n = Tokens.Count;

            while (Current < n)
            {
                TokenType tokenType = Tokens[Current].TokenType;
                switch (tokenType)
                {
                    //TODO: CONSIDER THE NEXT!!!
                    case TokenType.MULTIPLY:
                        //first we look at the next token
                        bool match;

                        //go to next
                        Advance();

                        match = IsAMatch(TokenType.OPENING_PAREN);
                        if (!match)
                        {
                            Advance();
                            continue;
                        }

                        //meaning at this point we have an opening
                        //we now get the first number
                        match = IsAMatch(TokenType.NUMBER);
                        if (!match)
                        {
                            Advance();
                            continue;
                        }

                        // we now have a number
                        Token firstNum = PreviousToken();

                        //check if a comma
                        match = IsAMatch(TokenType.COMMA);
                        if (!match)
                        {
                            Advance();
                            continue;
                        }

                        //check 2nd number
                        match = IsAMatch(TokenType.NUMBER);
                        if (!match)
                        {
                            Advance();
                            continue;
                        }

                        Token secondNum = PreviousToken();

                        //now we only have to check if we have a closing
                        match = IsAMatch(TokenType.CLOSING_PAREN);
                        if (!match)
                        {
                            Advance();
                            continue;
                        }

                        //meaning we now have a match
                        products.Add(int.Parse(firstNum.Value) * int.Parse(secondNum.Value));
                        break;
                    default:
                        Advance();
                        break;
                }
            }

            return products;
        }

        public int Solve()
        {
            List<int> nums = Parse();
            return nums.Sum();
        }

        private bool IsAMatch(TokenType expected)
        {
            if (Tokens[Current].TokenType == expected)
            {
                Advance();
                return true;
            }

            return false;
        }

        private Token PreviousToken()
        {
            return Tokens[Current - 1];
        }

        private void Advance()
        {
            Current++;
        }
    }
}
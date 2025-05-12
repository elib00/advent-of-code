using solution.day3;

namespace solution
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Day2 day2 = new Day2();
            // int ans = day2.Solve();
            // Console.WriteLine(ans);
            Scanner scanner = new Scanner("./inputs/day3.txt");
            List<Token> tokens = scanner.ProcessFile();
            Parser parser = new Parser(tokens);
            int ans = parser.Solve();
            Console.WriteLine(ans);

        }
    }
}
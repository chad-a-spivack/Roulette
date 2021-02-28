using System;
using System.Linq;
using System.Media;

namespace Csharpprogex07
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to the MSSA casino");
                Console.ReadLine();
                Roulette();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Roulette();
            }
        }
        public static int betAmount()
        {
            Console.Write("How much would you like to bet? ");
            string chipBet = Console.ReadLine();
            int chipAmount = int.Parse(chipBet);
            return chipAmount;
        }

        public static int CollectBets(int[] a, char[] b)
        {
            Console.WriteLine("No more bets! Press enter to roll");
            Table myTable = new Table();
            Console.ReadLine();
            myTable.CreateTable(a, b);
            int Roll()
            {
                int binIndex = 0;
                int totalRolls = 0;
                Random bin = new Random();
                var myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\roulette_wheel.wav";
                myPlayer.PlaySync();
                totalRolls++;
                return binIndex = bin.Next(0, a.Length);
            }
            return Roll();
        }
        public static int BetSelection()
        {
            Console.WriteLine("What would you like to bet?");
            Console.WriteLine("1) Single Number");
            Console.WriteLine("2) Evens/Odds");
            Console.WriteLine("3) Reds/Blacks");
            Console.WriteLine("4) Lows/Highs");
            Console.WriteLine("5) Dozens");
            Console.WriteLine("6) Columns");
            Console.WriteLine("7) Street");
            Console.WriteLine("8) 6 Numbers");
            Console.WriteLine("9) Split");
            Console.WriteLine("10) Corner");
            Console.Write("Enter a number for the type of bet you would like to place: ");
            string betType = Console.ReadLine();
            int betInt = int.Parse(betType);
            return betInt;
        }
        public static void Roulette()
        {
            int[] numbers = { (int)00, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                                21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 };
            char[] colors = { 'g', 'g', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r',
                                'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b' };

            int[] firstColumn = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
            int[] secondColumn = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
            int[] thirdColumn = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };

            Console.Write("How much did you come to bet with today?: ");
            string rentMoney = Console.ReadLine();
            int dollarBillz = int.Parse(rentMoney);
            Gambler Chad = new Gambler(dollarBillz);

            Wallet ChadsWallet = new Wallet(dollarBillz);

            Console.WriteLine($"Total amount in your wallet is {dollarBillz}");

            int betInt = BetSelection();

            int chipsBet = betAmount();

            if (betInt == 1)
            {
                SingleBet SingleNumber = new SingleBet { BetAmount = chipsBet };
                int binBet = SingleNumber.WinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (binBet == winningBin)
                {
                    int totalWon = SingleNumber.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0); 
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = SingleNumber.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }

                }
            }
            else if (betInt == 2)
            {
                EvensOddBet EvensOdds = new EvensOddBet { BetAmount = chipsBet };
                int oddsBet = EvensOdds.WinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (oddsBet == 0 && numbers[winningBin] % 2 == 0)
                {
                    int totalWon = EvensOdds.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (oddsBet == 0 && numbers[winningBin] % 2 != 0)
                {
                    int totalLost = EvensOdds.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (oddsBet == 1 && numbers[winningBin] % 2 == 0)
                {
                    int totalLost = EvensOdds.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (oddsBet == 1 && numbers[winningBin] % 2 != 0)
                {
                    int totalWon = EvensOdds.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }

            }
            else if (betInt == 3)
            {
                RedBlackBet RedBlack = new RedBlackBet { BetAmount = chipsBet };
                int oddsBet = RedBlack.RedBlackWinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (oddsBet == colors[winningBin])
                {
                    int totalWon = RedBlack.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = RedBlack.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
            else if (betInt == 4)
            {
                HiLoBet HiLo = new HiLoBet { BetAmount = chipsBet };
                int hiLO = HiLo.WinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (hiLO == 0 && numbers[winningBin] > 18)
                {
                    int totalWon = HiLo.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (hiLO == 0 && numbers[winningBin] <= 18)
                {
                    int totalLost = HiLo.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (hiLO == 1 && numbers[winningBin] > 18)
                {
                    int totalLost = HiLo.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (hiLO == 1 && numbers[winningBin] <= 18)
                {
                    int totalWon = HiLo.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
            else if (betInt == 5)
            {
                DozensBet Dozens = new DozensBet { BetAmount = chipsBet };
                int dozens = Dozens.WinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (dozens == 1 && numbers[winningBin] < 13)
                {
                    int totalWon = Dozens.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (dozens == 2 && numbers[winningBin] >= 13 && numbers[winningBin] < 25)
                {
                    int totalWon = Dozens.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (dozens == 3 && numbers[winningBin] >= 25)
                {
                    int totalWon = Dozens.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = Dozens.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
            else if (betInt == 6)
            {
                ColumnsBet Columns = new ColumnsBet { BetAmount = chipsBet };
                int columns = Columns.WinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (columns == 1 && firstColumn.Contains(winningBin))
                {
                    int totalWon = Columns.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (columns == 2 && secondColumn.Contains(winningBin))
                {
                    int totalWon = Columns.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (columns == 3 && thirdColumn.Contains(winningBin))
                {
                    int totalWon = Columns.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = Columns.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
            else if (betInt == 7)
            {
                StreetBet Street = new StreetBet { BetAmount = chipsBet };
                int street = Street.WinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (street == 1 && (numbers[winningBin] == 1 || numbers[winningBin] == 2 || numbers[winningBin] == 3))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 2 && (numbers[winningBin] == 4 || numbers[winningBin] == 5 || numbers[winningBin] == 6))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 3 && (numbers[winningBin] == 7 || numbers[winningBin] == 8 || numbers[winningBin] == 9))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 4 && (numbers[winningBin] == 10 || numbers[winningBin] == 11 || numbers[winningBin] == 12))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 5 && (numbers[winningBin] == 13 || numbers[winningBin] == 14 || numbers[winningBin] == 15))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 6 && (numbers[winningBin] == 16 || numbers[winningBin] == 17 || numbers[winningBin] == 18))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 7 && (numbers[winningBin] == 19 || numbers[winningBin] == 20 || numbers[winningBin] == 21))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 8 && (numbers[winningBin] == 22 || numbers[winningBin] == 23 || numbers[winningBin] == 24))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 9 && (numbers[winningBin] == 25 || numbers[winningBin] == 26 || numbers[winningBin] == 27))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 10 && (numbers[winningBin] == 28 || numbers[winningBin] == 29 || numbers[winningBin] == 30))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 11 && (numbers[winningBin] == 31 || numbers[winningBin] == 32 || numbers[winningBin] == 33))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 12 && (numbers[winningBin] == 34 || numbers[winningBin] == 35 || numbers[winningBin] == 36))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = Street.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
            else if (betInt == 8)
            {
                SixNumbersBet SixNumbers = new SixNumbersBet { BetAmount = chipsBet };
                int six = SixNumbers.WinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (six == 1 && numbers[winningBin] < 7)
                {
                    int totalWon = SixNumbers.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (six == 2 && numbers[winningBin] >= 7 && numbers[winningBin] < 13)
                {
                    int totalWon = SixNumbers.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (six == 3 && numbers[winningBin] >= 14 && numbers[winningBin] < 21)
                {
                    int totalWon = SixNumbers.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette(); 
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (six == 4 && numbers[winningBin] >= 21 && numbers[winningBin] < 27)
                {
                    int totalWon = SixNumbers.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (six == 5 && numbers[winningBin] >= 27 && numbers[winningBin] < 31)
                {
                    int totalWon = SixNumbers.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (six == 6 && numbers[winningBin] >= 31)
                {
                    int totalWon = SixNumbers.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = SixNumbers.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
            else if (betInt == 9)
            {
                SplitBet Split = new SplitBet { BetAmount = chipsBet };
                int split = Split.WinLoss();
                int splitSecond = Split.SplitDirection(split);
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (numbers[winningBin] == split || numbers[winningBin] == splitSecond)
                {
                    int totalWon = Split.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = Split.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
            else if (betInt == 10)
            {
                CornerBet Corner = new CornerBet { BetAmount = chipsBet };
                int corner = Corner.WinLoss();
                int[] cornerGroup = Corner.cornerGroup(corner);
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (cornerGroup.Contains(numbers[winningBin]))
                {
                    int totalWon = Corner.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = Corner.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
	class Table
    {
       
        public void CreateTable(int[] a, char[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"{a[i]} - {b[i]}");
            }
        }
        
       
    }
	    class Bets
    {
        public int BetAmount { get; set; }
        public Bets()
        {
            BetAmount = 0;
        }
       
        public virtual void PlaceBets(int b)
        {
            int potentialWin = b;
        }

        public virtual int WinLoss()
        {
            return 0;
        }
        public virtual int Winnings()
        {
            return 0;
        }
        public  int Losses()
        {
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\gasp_x.wav";
            myPlayer1.PlaySync();
            return BetAmount ;
        }
    }
    class SingleBet : Bets
    {
        public int NumberBet { get; set; }
        public SingleBet()
        {
            BetAmount = 0;
        }
        //public override void PlaceBets(int b)
        //{
        //    BetAmount = b;
        //}
        public override int WinLoss()
        {
            Console.WriteLine("What number would you like to bet on?");
            Console.Write("Please enter a number ");
            string enteredNumber = Console.ReadLine();
            NumberBet = int.Parse(enteredNumber);
            return NumberBet;
        }
        public override int Winnings()
        {
            int winnings = BetAmount * 35;
            return winnings;
        }
        //public override int Losses()
        //{
        //    int loss = BetAmount;
        //    return loss;
        //}
    }
    class EvensOddBet : Bets
    {
        public EvensOddBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("Evens or odds? (0 = even/ 1= odd)");
            string evenODD = Console.ReadLine();
            int evenOddInput = int.Parse(evenODD);
            return evenOddInput;
        }
        public override int Winnings()
        {
            int winnings = BetAmount;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
        //public override int Losses()
        //{
        //    return base.Losses();
        //}
    }
    class RedBlackBet : Bets
    {
        public RedBlackBet()
        {
            BetAmount = 0;
        }
        public  char RedBlackWinLoss()
        {
            Console.Write("Red or Black? (r = Red/ b = Black)");
            string redBlack = Console.ReadLine();
            char redBlackInput = char.Parse(redBlack);
            return redBlackInput;
        }
        public override int Winnings()
        {
            int winnings = BetAmount;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
    class HiLoBet : Bets
    {
        public HiLoBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("High or Low? (0 = High / 1= Low) ");
            string highLow = Console.ReadLine();
            int evenOddInput = int.Parse(highLow);

            return evenOddInput;
        }
        public override int Winnings()
        {
            int winnings = BetAmount;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
    class DozensBet : Bets
    {
        public DozensBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("Which dozen would you like? (1 = First(1-12) / 2 = Second(13-24) / 3 = Third(25-36))  ");
            string dozen = Console.ReadLine();
            int dozensInput = int.Parse(dozen);
            return dozensInput;
        }
        public override int Winnings()
        {
            int winnings = BetAmount * 2;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
    class ColumnsBet : Bets
    {
        public ColumnsBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("Which column would you like? (1 = First / 2 = Second / 3 = Third)  ");
            string column = Console.ReadLine();
            int columnInput = int.Parse(column);
            return columnInput;
        }
        public override int Winnings()
        {
            int winnings = BetAmount * 2;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
    class StreetBet : Bets
    {
        public StreetBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("Which street would you like? (1 = (1, 2, 3) / 2 = (4, 5, 6) / 3 = (7, 8, 9) 4 = (10, 11, 12) 5 = (13, 14, 15) 6 = (16, 17, 18) 7 = (19, 20, 21) 8 = (22, 23, 24) 9 = (25, 26, 27) 10 = (28, 29, 30) 11 = (31, 32, 33) 12 = (34, 35, 36)) ");
            string street = Console.ReadLine();
            int streetInput = int.Parse(street);
            return streetInput;
        }
        public override int Winnings()
        {
            int winnings = BetAmount * 11;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
    class SixNumbersBet : Bets
    {
        public SixNumbersBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("Which six numbers would you like? (1 = (1-6) / 2 = (7-12) / 3 = (13-18) / 4 = (19-24) / 5 = (25-30) / 6 = (31-36))  ");
            string column = Console.ReadLine();
            int columnInput = int.Parse(column);
            return columnInput;
        }
        public override int Winnings()
        {
            int winnings = BetAmount * 5;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
    class SplitBet : Bets
    {
        public SplitBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("Which number would you like to split" );
            string split = Console.ReadLine();
            int splitInput = int.Parse(split);
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return splitInput;
        }
        public int SplitDirection(int e)
        {
            Console.Write("Which direction would you like to split? (1 = veritcal / 2 = horizontal) ");
            string direction = Console.ReadLine();
            int intDirection = int.Parse(direction);
            if (intDirection == 1)
            {
                int verticalSplit = e + 3;
                return verticalSplit;
            }
            else
            {
                int horizontalSplit = e + 1;
                return horizontalSplit;
            }
        }
        public override int Winnings()
        {
            int winnings = BetAmount * 17;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
    class CornerBet : Bets
    {
        public CornerBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("Which numbers would you like in your corner? (enter the lowest number in your corner)");
            string corner = Console.ReadLine();
            int cornerInput = int.Parse(corner);
            return cornerInput;
        }
        public int[] cornerGroup(int f)
        {
            int[] corner = { f, f + 1, f + 2, f + 3 };
            return corner;
        }
        public override int Winnings()
        {
            int winnings = BetAmount * 8;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
	    class Gambler
    {
        int _cash = 0;
        
        public Gambler()
        {
            Console.WriteLine("You have no money go home");
        }
        public Gambler(int cash)
        {
            _cash = cash;
            if (cash > 1000)
            {
                Console.WriteLine("High Roller coming to the table!");
            }
            else if (cash > 500 && cash <= 1000)
            {
                Console.WriteLine("Woah this guy came to play");
            }
            else if (cash > 100 && cash <= 500)
            {
                Console.WriteLine("Does your wife know you are here?");
            }
            else
            {
                Console.WriteLine("Please get out of my casino before I call security");
            }
        }
       
    }
	   class Wallet
    {
        public int ChipAmount { get; set; }
        public int money = 0;
        public Wallet()
        {
            ChipAmount = 0;
        }
        public Wallet(int e)
        {
            money += e;
        }

        public int WinMoney(int e)
        {
           return money += e;
        }
        public int LoseMoney(int e)
        {
            return money -= e;
        }
    }
}

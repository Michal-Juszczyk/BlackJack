
using System;
using System.Reflection;

namespace Oczko
{
    class LogicGame
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wprowadź nazwę gracza 1");
            string Gracz1 = Console.ReadLine();

            Console.WriteLine("Wprowadź nazwę gracza 2");
            string Gracz2 = Console.ReadLine();

            Console.WriteLine("Gracz 1 to " + Gracz1);
            Console.WriteLine("Gracz 2 to " + Gracz2);
            int previousNumber = 0;
            int totalGeneratedNumbers = 0;

            do
            {
                StartRound(Gracz1);

                Console.WriteLine("Czy chcesz generować liczby dla gracza " + Gracz1 + " ? (T/N)");

                string GenerateForGracz1 = Console.ReadLine();

                if (GenerateForGracz1.ToUpper() == "T")
                {
                    int currentNumber = GenerateNumbers();  // Generowanie bieżącej liczby

                    totalGeneratedNumbers += currentNumber;  // Dodanie bieżącej liczby do sumy

                    Console.WriteLine($"Wygenerowana liczba: {currentNumber}");
                    Console.WriteLine($"Aktualna suma to: {totalGeneratedNumbers}");

                    if (totalGeneratedNumbers > 21)
                    {
                        Console.WriteLine($"Gracz {Gracz1} osiągnął wynik większy niż 21!");
                        EndRound(Gracz1);  // Zakończenie tury dla Gracz1
                        RunProgram();
                        break;
                    }

                    // Zaktualizuj poprzednią liczbę tylko wtedy, gdy gracz zdecyduje się generować nową liczbę
                    previousNumber = currentNumber;
                }
                else if (GenerateForGracz1.ToUpper() == "N")
                {
                    Console.WriteLine($"Numer końcowy to: {totalGeneratedNumbers}");
                    EndRound(Gracz1);  // Zakończenie tury dla Gracz1
                    break;
                }
            } while (true);

            int previousNumber2 = 0;
            int totalGeneratedNumbers2 = 0;
            do
            {
                StartRound(Gracz2);

                Console.WriteLine("Czy chcesz generować liczby dla gracza " + Gracz2 + " ? (T/N)");

                string GenerateForGracz2 = Console.ReadLine();

                if (GenerateForGracz2.ToUpper() == "T")
                {
                    int currentNumber2 = GenerateNumbers();  // Generowanie bieżącej liczby

                    if (previousNumber2 != 0)
                    {
                        // Jeśli poprzednia liczba istnieje, dodaj ją do bieżącej liczby
                        currentNumber2 += previousNumber2;
                    }

                    totalGeneratedNumbers2 += currentNumber2;  // Dodanie bieżącej liczby do sumy

                    Console.WriteLine($"Wygenerowana liczba: {currentNumber2}");
                    Console.WriteLine($"Aktualna suma to: {totalGeneratedNumbers2}");

                    if (totalGeneratedNumbers2 > 21)
                    {
                        Console.WriteLine($"Gracz {Gracz2} osiągnął wynik większy niż 21!");
                        EndRound(Gracz2);  // Zakończenie tury dla Gracz1
                        RunProgram();
                        break;
                    }
                    // Zaktualizuj poprzednią liczbę tylko wtedy, gdy gracz zdecyduje się generować nową liczbę
                    previousNumber2 = currentNumber2;
                }
                else if (GenerateForGracz2.ToUpper() == "N")
                {
                    Console.WriteLine($"Numer końcowy to: {totalGeneratedNumbers2}");
                    EndRound(Gracz2);  // Zakończenie tury dla Gracz1
                    break;
                }
            } while (true);


            // Lub po spełnieniu pewnych warunków wygranej
            if (totalGeneratedNumbers >= 21 || totalGeneratedNumbers2 >= 21)
            {
                Winner(Gracz1, totalGeneratedNumbers, totalGeneratedNumbers2, Gracz2);
            }
            else if (totalGeneratedNumbers == totalGeneratedNumbers2)
            {
                Console.WriteLine("Remis");
            }
        
    


        static void StartRound(string gracz)
            {
                Console.WriteLine($"Tura gracza {gracz}");
            }


            static void EndRound(string gracz)
            {
                Console.WriteLine($"Koniec tury gracza {gracz}");

            }


            static int GenerateNumbers()
            {
                Random random = new Random();

                int existingNumber = random.Next(1, 22);

                return existingNumber;
            }

           

            static void Winner(string gracz1, int currentNumber, int currentNumber2, string gracz2)
            {
                if (currentNumber >= 21)
                {
                    Console.WriteLine($"Gracz {gracz1} wygrywa!");
                }
                else if (currentNumber2 >= 21)
                {
                    Console.WriteLine($"Gracz {gracz2} wygrywa!");
                }

               
                RunProgram();

            }

            

            static void RunProgram()
            {
                Console.WriteLine("Gra skończona, czy chcesz uruchomić program ponownie? (T/N)");
                string response = Console.ReadLine();

                if (response.ToUpper() == "T")
                {
                    Console.WriteLine("Restart programu...\n");
                    Main(new string[] { }); // Ponowne uruchomienie metody Main
                }
                else
                {
                    Console.WriteLine("Zamykanie programu...");
                    // Dodaj kod, który zamyka program
                }
            }
        }



    }
        
}
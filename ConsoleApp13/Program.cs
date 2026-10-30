
using System;
using System.IO;
class Program
{
    static void Main()
    {
        string fayl = "telebeler.txt";

        while (true)
        {
            Console.WriteLine("\n--- TELEBE SIYAHISI ---");
            Console.WriteLine("1. Telebe elave et");
            Console.WriteLine("2. Hamisini goster");
            Console.WriteLine("3. Ada gore axtar");
            Console.WriteLine("4. Cixis");

            Console.Write("Seciminizi daxil edin: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    try
                    {
                        Console.Write("Telebenin ID-si: ");
                        string id = Console.ReadLine();

                        Console.Write("Telebenin adi: ");
                        string ad = Console.ReadLine();

                        Console.Write("Telebenin yasi: ");
                        string yas = Console.ReadLine();

                        using (StreamWriter sw = new StreamWriter(fayl, true))
                        {
                            sw.WriteLine(id + ";" + ad + ";" + yas);
                        }

                        Console.WriteLine("Telebe ugurla elave edildi!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Xeta: " + ex.Message);
                    }
                    break;

                case "2":
                    try
                    {
                        if (File.Exists(fayl))
                        {
                            using (StreamReader sr = new StreamReader(fayl))
                            {
                                string setir;

                                while ((setir = sr.ReadLine()) != null)
                                {
                                    string[] melumat = setir.Split(';');

                                    Console.WriteLine("ID: " + melumat[0]);
                                    Console.WriteLine("Ad: " + melumat[1]);
                                    Console.WriteLine("Yas: " + melumat[2]);
                                    Console.WriteLine("-------------------");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Telebe siyahisi bosdur!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Xeta: " + ex.Message);
                    }
                    break;

                case "3":
                    try
                    {
                        Console.Write("Axtarilacaq telebenin adini daxil edin: ");
                        string axtar = Console.ReadLine();

                        bool tapildi = false;

                        if (File.Exists(fayl))
                        {
                            using (StreamReader sr = new StreamReader(fayl))
                            {
                                string setir;

                                while ((setir = sr.ReadLine()) != null)
                                {
                                    string[] melumat = setir.Split(';');

                                    if (melumat[1].ToLower() == axtar.ToLower())
                                    {
                                        Console.WriteLine("Telebe tapildi!");
                                        Console.WriteLine("ID: " + melumat[0]);
                                        Console.WriteLine("Ad: " + melumat[1]);
                                        Console.WriteLine("Yas: " + melumat[2]);

                                        tapildi = true;
                                    }
                                }
                            }
                        }

                        if (!tapildi)
                        {
                            Console.WriteLine("Telebe tapilmadi!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Xeta: " + ex.Message);
                    }
                    break;

                case "4":
                    Console.WriteLine("Proqramdan cixildi!");
                    return;

                default:
                    Console.WriteLine("Yanlis secim!");
                    break;
            }
        }
    }
}

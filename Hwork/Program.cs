

using Hwork.DAL;
using Hwork.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Create Position");
                Console.WriteLine("2. Edit Position");
                Console.WriteLine("3. Delete Position");
                Console.WriteLine("4. Create Expert");
                Console.WriteLine("5. Edit Expert");
                Console.WriteLine("6. Delete Expert");
                Console.WriteLine("7. Show All Experts");
                Console.WriteLine("8. Show All Positions");
                Console.WriteLine("9. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreatePosition();
                        break;
                    case "2":
                        EditPosition();
                        break;
                    case "3":
                        DeletePosition();
                        break;
                    case "4":
                        CreateExpert();
                        break;
                    case "5":
                        EditExpert();
                        break;
                    case "6":
                        DeleteExpert();
                        break;
                    case "7":
                        ShowAllExperts();
                        break;
                    case "8":
                        ShowAllPositions();
                        break;
                    case "9":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 9.");
                        break;
                }
            }

        }


        static void CreatePosition()
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("Enter position  which create:");

                Console.Write("Position Name: ");
                string name = Console.ReadLine();

                Positions positions = new()
                {
                    Name = name,
                };
                context.Positions.Add(positions);
                context.SaveChanges();
            }
        }

        static void EditPosition()
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("Enter position id which edit:");

                Console.Write("id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Position Name: ");
                string name = Console.ReadLine();

                Positions positions = context.Positions.FirstOrDefault(x => x.Id == id);
                if (positions == null)
                {
                    Console.WriteLine("Position is not found");
                }
                positions.Name = name;
                context.SaveChanges();

            }
        }

        static void DeletePosition()
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("Enter position id which delete:");

                Console.Write("id: ");
                int id = int.Parse(Console.ReadLine());

                Positions positions = context.Positions.FirstOrDefault(x => x.Id == id);
                if (positions == null)
                {
                    Console.WriteLine("Position is not found");
                }
                context.Positions.Remove(positions);
                context.SaveChanges();

            }
        }


        static void CreateExpert()
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("Create New User:");

                Console.Write("Name: ");
                string ad = Console.ReadLine();

                Console.Write("Surname: ");
                string soyad = Console.ReadLine();

                Console.Write("Position Reference: ");
                List<Positions> positions = context.Positions.ToList();
                foreach (var position in positions)
                {
                    Console.WriteLine($"{position.Name} - {position.Id}");
                }

                Console.Write("Enter Position Id: ");
                int PositionId = int.Parse(Console.ReadLine());

                Positions selectedPosition = context.Positions.FirstOrDefault(p => p.Id == PositionId);
                if (selectedPosition == null)
                {
                    Console.WriteLine("Invalid Position Id. Position not found.");
                    return;
                }

                Experts expert = new()
                {
                    Name = ad,
                    Surname = soyad,
                    PositionId = PositionId,
                    Positions = selectedPosition
                };
                Console.WriteLine($"Name: {expert.Name}");
                Console.WriteLine($"Surname: {expert.Surname}");
                context.Experts.Add(expert);
                context.SaveChanges();
            }
        }

        static void EditExpert()
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("Edit User:");


                Console.Write("id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string ad = Console.ReadLine();

                Console.Write("Surname: ");
                string soyad = Console.ReadLine();


                Console.Write("Position Referance: ");
                List<Positions> positions = context.Positions.ToList();
                foreach (var position in positions)
                {
                    Console.WriteLine(position.Name + " " + position.Id);
                }
                int PositionId = int.Parse(Console.ReadLine());

                Experts experts = context.Experts.FirstOrDefault(x => x.Id == id);
                if (experts == null)
                {
                    Console.WriteLine("Expert is not found");
                }
                experts.Name = ad;
                experts.Surname = soyad;
                experts.PositionId = PositionId;
                Console.WriteLine("Name" + experts.Name);
                Console.WriteLine("Surname" + experts.Surname);
                Console.WriteLine("Position" + experts.Positions.Name);

                context.SaveChanges();



            }
        }

        static void DeleteExpert()
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("Delete User:");


                Console.Write("id: ");
                int id = int.Parse(Console.ReadLine());

                Experts experts = context.Experts.Include(x => x.Positions).FirstOrDefault(x => x.Id == id);
                if (experts == null)
                {
                    Console.WriteLine("Expert is not found");
                }
                Console.WriteLine("Name" + experts.Name);
                Console.WriteLine("Surname" + experts.Surname);
                Console.WriteLine("Position" + experts.Positions.Name);
                context.Experts.Remove(experts);
                context.SaveChanges();



            }
        }

        static void ShowAllExperts()
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("All Experts:");

                var experts = context.Experts.Include(x => x.Positions).ToList();
                foreach (var expert in experts)
                {
                    Console.WriteLine($"ID: {expert.Id}, Name: {expert.Name}, Surname: {expert.Surname}, Position: {expert.Positions.Name}");
                }
            }
        }

        static void ShowAllPositions()
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("All Position:");

                var positions = context.Positions.ToList();
                foreach (var position in positions)
                {
                    Console.WriteLine($"ID: {position.Id}, Name: {position.Name}");
                }
            }
        }



    }
}
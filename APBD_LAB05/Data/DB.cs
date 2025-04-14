using APBD_LAB_05.models;

namespace APBD_LAB_05.Data;


public static class StaticDb
{
    public static List<Animal> Animals { get; } = new List<Animal>
    {
        new Animal
        {
            Id = 1,
            Name = "Bella",
            Category = "Dog",
            Weight = 22.5,
            FurColor = "Golden",
            Visits = new List<Visit>
            {
                new Visit
                {
                    Id = 1,
                    Date = new DateTime(2024, 12, 1),
                    Description = "Annual vaccination",
                    Price = 60
                }
            }
        },
        new Animal
        {
            Id = 2,
            Name = "Milo",
            Category = "Cat",
            Weight = 4.8,
            FurColor = "Gray",
            Visits = new List<Visit>
            {
                new Visit
                {
                    Id = 2,
                    Date = new DateTime(2025, 1, 10),
                    Description = "Neutering procedure",
                    Price = 150
                }
            }
        }
    };
    public static List<Visit> Visits { get; set; } = new();
}
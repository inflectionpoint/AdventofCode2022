namespace AdventofCode2022
{
    public class Elf
    {
        public int Id { get; set; }
        public int TotalCalories { get; private set; }

        public Elf(int id)
        {
            Id = id;
            TotalCalories = 0;
        }

        public void AddToCalorieTotal(int Calorie)
        {
            TotalCalories += Calorie;
        }
    }
}
namespace workshop.wwwapi.Data
{
    public class RandomDateTime
    {
        DateTime start;
        Random generated;
        int range;

        public RandomDateTime()
        {
            start = new DateTime(2000, 1, 1);
            generated = new Random();
            range = (DateTime.Today - start).Days;
        }

        public DateTime New()
        {
            return start.AddDays(generated.Next(range))
                .AddHours(generated.Next(0, 24))
                .AddMinutes(generated.Next(0, 60))
                .AddSeconds(generated.Next(0, 60));
        }
    }
}
namespace lab3.Services
{
    public class TimeOfDayService
    {
        public string GetTimeOfDay()
        {
            DateTime now = DateTime.Now;

            if (now.Hour >= 12 && now.Hour < 18) return "Сейчас день";
            else if (now.Hour >= 18 && now.Hour < 24) return "Сейчас вечер";
            else if (now.Hour >= 0 && now.Hour < 6) return "Сейчас ночь";
            else return "Сейчас утро";
        }
    }
}

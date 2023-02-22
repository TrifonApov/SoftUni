namespace _05_Date_Modifier
{
    public static class DateModifier
    {
        public static TimeSpan CalculateDifferenceBetweenDates(string date1, string date2)
        {
            string[] d1Info = date1.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int d1Year = int.Parse(d1Info[0]);
            int d1Mount = int.Parse(d1Info[1]);
            int d1Date = int.Parse(d1Info[2]);
            
            string[] d2Info = date2.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int d2Year = int.Parse(d2Info[0]);
            int d2Mount = int.Parse(d2Info[1]);
            int d2Date = int.Parse(d2Info[2]);

            DateTime d1 = new DateTime(d1Year,d1Mount,d1Date);
            DateTime d2 = new DateTime(d2Year,d2Mount,d2Date);
            
            if (d1 > d2)
            {
                return d1 - d2;
            }

            return d2 - d1;
        }
    }
}

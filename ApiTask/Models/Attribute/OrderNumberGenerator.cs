namespace ApiTask.Models.Attribute
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderNumberGenerator
    {

        private static int counter = 0;
        private static int currentYear = DateTime.Now.Year;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GenerateOrderNumber()
        {

                // Check if year has changed and reset counter if needed
                int year = DateTime.Now.Year;
                if (year != currentYear)
                {
                    currentYear = year;
                    counter = 0;
                }

                // Generate the next number in sequence
                counter++;

                // Format: Order_YYYY_X
                return $"Order_{currentYear}_{counter}";
        }
    }
}

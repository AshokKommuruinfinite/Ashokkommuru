namespace MiniProject.NewFolder1
{
    public class Billvaildator
    {
        public string ValidateUnitsConsumed(int unitsConsumed)
        {
            if (unitsConsumed < 0)
            {
                return "Given units is invalid";
            }
            return "Valid";
        }
    }
}
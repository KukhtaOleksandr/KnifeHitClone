namespace Extensions
{
    public static class IntExtensions
    {
        public static bool ToBool(this int value)
        {
            if(value ==1)
                return true;
            return false;
        }
    }
}
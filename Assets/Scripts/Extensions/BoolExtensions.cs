namespace Extensions
{
    public static class BoolExtensions
    {
        public static int ToInt(this bool value)
        {
            if(value)
                return 1;
            return 0;
        }
    }
}
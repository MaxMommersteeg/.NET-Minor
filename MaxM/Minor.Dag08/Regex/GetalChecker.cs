namespace Regex
{
    public class GetalChecker
    {
        public static System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(@"^[-]?\d{1,3}([,\d{3}]{0,})\.\d{2}$");

        public bool Check(string getal)
        {
            return pattern.IsMatch(getal);
        }
    }
}

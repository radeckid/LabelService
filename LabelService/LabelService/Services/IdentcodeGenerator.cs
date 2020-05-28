namespace LabelService.Services
{
    public class IdentcodeGenerator : IIdentcodeGenerator
    {
        private long _current;

        public string Call()
        {
            _current++;

            return _current.ToString().PadLeft(12, '0'); ;
        }
    }
}

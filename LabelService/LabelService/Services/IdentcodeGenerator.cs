using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

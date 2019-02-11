using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Utils
{
    public partial class ClassBase
    {
        private Logger _logger;     
        public Logger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Logger("File");
                }
                return _logger;
            }
        }
    }
}

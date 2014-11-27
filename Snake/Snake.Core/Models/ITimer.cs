using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Core
{
    public interface ITimer
    {
        double Interval { get; set; }
        Action OnTick { get; set; }

        void Start();
        void Stop();
        void Dispose();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class VruchtbaarDier:Dier
    {
        public enum Geslacht { Male, Female};
        private Geslacht geslacht;
        private bool metKind;

        public VruchtbaarDier(string type, Geslacht geslacht)
            :base(type)
        {
            this.geslacht = geslacht;
        }
    }
}

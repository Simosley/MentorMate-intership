using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Context
    {
        private IStrategy _strategy;

        public Context()
        { }

        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void GetDiscount()
        {
            var result = this._strategy.DoAlgorithm(new Dictionary<string, int>
            {
                {"Christmas",5 },
                {"Easter",3},
                {"New year", 1 },
                {"Rest", 0 }
            });


        }
    }
}

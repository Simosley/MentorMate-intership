using System;

namespace DecoratorPattern
{
    abstract class Decorator : Company
    {
        protected Company _component;

        public Decorator(Company company)
        {
            this._component = company;
        }

        public void SetComponent(Company company)
        {
            this._component = company;
        }

        public override string Operation()
        {
            if (this._component != null)
            {
                return this._component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }

   
    
}
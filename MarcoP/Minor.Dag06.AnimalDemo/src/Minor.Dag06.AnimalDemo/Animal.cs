using System;

namespace Minor.Dag06.AnimalDemo
{
    public abstract class Animal
    {
        /// <summary>
        /// Weight in kg.
        /// </summary>
        public double Weight { get; set; }

        public Animal() : this(1.0)
        {
        }
        public Animal(double weight)
        {
            Weight = weight;
        }

        public virtual string MakeNoise()
        {
            return "tjilp tjilp";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class GeneticAlgorithm
    {
        readonly int size = 1000;
        readonly int max_iteration = 100;
        readonly double mutationrate = 0.25;
        readonly double delta = 0.0001;
        readonly double ln = 0.3;
        readonly double p = 0.9;
        Random rnd = new Random((int)DateTime.Now.Ticks);

        public int Step { get; private set; }
        public Func<double, double> Func;
        public List<Descendant> Population = new List<Descendant>();

        private double func(double x) 
        {
            return Func(x);
        }

        public void Init() 
        {
            GeneratePopulation();
            CalcFitness();
        }

        public Descendant Work() 
        {
            int i = 0;
            for (; i < max_iteration; i++) 
            {
                Crossing();
                Mutation();
                CalcFitness();
                Selection();
                if (Math.Abs(Population.First().Y - Population.Last().Y) <= delta)
                    break;
            }
            Step = i;
            return Population.First();
        }

        public void GeneratePopulation() 
        {
            for(int i = 0; i < size; i++) 
            {
                var desc = new Descendant()
                {
                    X = (rnd.NextDouble() - 0.5) * 100000
                };
                Population.Add(desc);
            }
        }

        public void CalcFitness() 
        {
            foreach(var desc in Population) 
            {
                desc.Y = func(desc.X);
            }
            Population.Sort();
        }

        public void Selection() 
        {
            //Селекция усечением
            for(int i = (int)(Population.Count * ln); i < Population.Count; i++) 
                Population.RemoveAt(i);
        }

        public void Crossing() 
        {
            var old_size = Population.Count;
            while (Population.Count < size) 
            {
                int i = (int)(rnd.NextDouble() * old_size);
                int j = (int)(rnd.NextDouble() * old_size);

                if(p > rnd.NextDouble()) 
                {
                    var children = CrossingDesc(Population[i], Population[j]);
                    Population.Add(children.Item1);
                    Population.Add(children.Item2);
                }
            }
        }

        public (Descendant, Descendant) CrossingDesc(Descendant x, Descendant y) 
        {
            var lambda = rnd.NextDouble();
            var cx = new Descendant() { X = lambda * x.X + (1 - lambda) * y.X };
            var cy = new Descendant() { X = lambda * y.X + (1 - lambda) * x.X };
            return (cx, cy);
        }

        public void Mutation() 
        {
            foreach(var desc in Population) 
            {
                if(mutationrate > rnd.NextDouble())
                {
                    desc.X += (rnd.NextDouble() - 0.5) * 100;
                }
            }
        }
    }
}

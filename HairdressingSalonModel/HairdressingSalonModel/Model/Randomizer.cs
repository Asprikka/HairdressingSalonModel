using System;
using System.Collections.Generic;

namespace HairdressingSalonModel
{
    public class Randomizer<T>
    {
        private readonly Random _rnd = new Random();
        public List<KeyValuePair<T, int>> Set { get; }

        public Randomizer()
        {
            Set = new List<KeyValuePair<T, int>>();
        }

        public T GetRandom()
        {
            int r = _rnd.Next(0, 100 + 1);
            for (int i = 0; i < Set[i].Value; i++)
            {
                if (r <= Set[i].Value)
                    return Set[i].Key;
                else
                    r -= Set[i].Value;
            }

            throw new NotImplementedException();
        }
    }
}

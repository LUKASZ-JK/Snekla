using System;
using Tekla.Structures;

namespace Snekla
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Identifier ID { get; set; }
        public Coordinate(double X, double Y)
        {
            this.X = X;
            this.Y = Y;

        }
        public bool Equals(Coordinate other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}

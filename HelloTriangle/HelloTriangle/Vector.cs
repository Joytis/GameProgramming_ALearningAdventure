using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace HelloTriangle
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector
    {
        public static Vector Zero = new Vector(0, 0, 0);

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z)
            : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        //Subtraction Method
        public Vector Subtract(Vector r)
        {
            return new Vector(X - r.X, Y - r.Y, Z - r.Z);
        }

        //Addition Method
        public Vector Add(Vector r)
        {
            return new Vector(X + r.X, Y + r.Y, Z + r.Z);
        }

        //multiplication Method
        public Vector Multiply(double v)
        {
            return new Vector(X * v, Y * v, Z * v);
        }

        //returns dot product of two vectors
        public double DotProduct(Vector v)
        {
            return (v.X * X) + (v.Y * Y) + (v.Z * Z);
        }

        //Returns new vector which is the cross product of two vectors
        public Vector CrossProduct(Vector v)
        {
            double nx = Y * v.Z - Z * v.Y;
            double ny = Z * v.X - X * v.Z;
            double nz = X * v.Y - Y * v.X;
            return new Vector(nx, ny, nz);
        }


        //Return vector with same direction and magnitude 1
        public Vector Normalize(Vector v)
        {
            double r = v.Length();
            if (r != 0.0)
            {
                return new Vector(v.X / r, v.Y / r, v.Z / r);
            }
            else
            {
                return new Vector(0, 0, 0);
            }
        }

        //Returns Length
        public double Length()
        {
            return Math.Sqrt(LengthSquared());
        }

        //Returns Squared Length
        public double LengthSquared()
        {
            return (X * X + Y * Y + Z * Z);
        }

        //Checks if two vectros are equal. Returns boolean
        public bool Equals(Vector v)
        {
            return ((v.X == X) && (v.Y == Y) && (v.Z == Z));
        }

        /*Overridden functions for stuff */
        #region Overridden functions and Operators

        //Returns... Hash browns...?
        public override int GetHashCode()
        {
            return (int)X^ (int)Y^ (int)Z;
        }

        //Overridden * operator for dot product
        public static double operator *(Vector v1, Vector v2)
        {
            return v1.DotProduct(v2);
        }

        //Overloaded addition operator for vectors
        public static Vector operator +(Vector v1, Vector v2)
        {
            return v1.Add(v2);
        }

        //Overloaded subtraction operator for vectors
        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1.Subtract(v2);
        }

        //Overloaded multiplcation operator for vectors
        public static Vector operator *(Vector v1, double v)
        {
            return v1.Multiply(v);
        }

        //Overloaded equality operator for vectors
        public static bool operator ==(Vector v1, Vector v2)
        {
            if (System.Object.ReferenceEquals(v1, v2))
            {
                return true;
            }

            if (v1 == null || v2 == null)
            {
                return false;
            }

            return v1.Equals(v2);
        }

        //Overloaded Equals object function for vectors
        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                return Equals((Vector)obj);
            }
            return base.Equals(obj);
        }

        //Overloaded 'not equals' operator for vectors
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !v1.Equals(v2);
        }

        public override string ToString()
        {
            return string.Format("X:{0}, Y:{1}, Z:{2}", X, Y, Z); 
        }

        #endregion
    }
}

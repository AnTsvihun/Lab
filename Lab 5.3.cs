using System;

class Quaternion
{
    public double W { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public Quaternion(double w, double x, double y, double z)
    {
        W = w;
        X = x;
        Y = y;
        Z = z;
    }

    public static Quaternion operator +(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.W + q2.W, q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z);
    }

    // Implement other overloaded operators for subtraction, multiplication, etc.

    public double Norm()
    {
        return Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
    }

    public Quaternion Conjugate()
    {
        return new Quaternion(W, -X, -Y, -Z);
    }

    public Quaternion Inverse()
    {
        double normSquared = W * W + X * X + Y * Y + Z * Z;
        return new Quaternion(W / normSquared, -X / normSquared, -Y / normSquared, -Z / normSquared);
    }

    public static bool operator ==(Quaternion q1, Quaternion q2)
    {
        return q1.Equals(q2);
    }

    public static bool operator !=(Quaternion q1, Quaternion q2)
    {
        return !q1.Equals(q2);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Quaternion))
        {
            return false;
        }

        Quaternion other = (Quaternion)obj;
        return W == other.W && X == other.X && Y == other.Y && Z == other.Z;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(W, X, Y, Z);
    }

    public Matrix3x3 ToRotationMatrix()
    {
        // Implement conversion to rotation matrix
        return new Matrix3x3();
    }
}

class Matrix3x3
{
    // Implement a 3x3 matrix class
}

class Program
{
    static void Main()
    {
        Quaternion q1 = new Quaternion(1, 2, 3, 4);
        Quaternion q2 = new Quaternion(5, 6, 7, 8);

        Quaternion sum = q1 + q2;
        Console.WriteLine($"Sum: {sum.W}, {sum.X}, {sum.Y}, {sum.Z}");

        Console.WriteLine($"Norm of q1: {q1.Norm()}");

        Quaternion conjugate = q1.Conjugate();
        Console.WriteLine($"Conjugate of q1: {conjugate.W}, {conjugate.X}, {conjugate.Y}, {conjugate.Z}");

        Quaternion inverse = q1.Inverse();
        Console.WriteLine($"Inverse of q1: {inverse.W}, {inverse.X}, {inverse.Y}, {inverse.Z}");

        Console.WriteLine($"q1 == q2: {q1 == q2}");
        Console.WriteLine($"q1 != q2: {q1 != q2}");

        Matrix3x3 rotationMatrix = q1.ToRotationMatrix();
        // Use the rotation matrix as needed
    }
}

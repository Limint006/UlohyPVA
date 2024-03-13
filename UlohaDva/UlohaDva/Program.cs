using System.Numerics;


List<Vector2> points = new();


for (int i = 0; i < 3; i++)
{
    Vector2 point;
    Console.WriteLine($"Enter point {i + 1} x, y: ");
    if (!float.TryParse(Console.ReadLine(), out point.X))
    {
        Console.WriteLine("Invalid Input");
        return;
    }

    if (!float.TryParse(Console.ReadLine(), out point.Y))
    {
        Console.WriteLine("Invalid Input");
        return;
    }

    points.Add(point);
}

Console.Clear();

if (points.Distinct().Count() != points.Count)
{
    Console.WriteLine("Some points are the same");
    Console.ReadKey();
    return;
}

if (ArePointsLinear(points))
{
    Console.WriteLine("Points are linear");
}
else
{
    Console.WriteLine("Points are not linear");
    Console.ReadKey();
    return;
}

Vector2 midPoint = GetMidPoint(points, out var midPointIndex);
Console.WriteLine($"Midpoint is {midPoint} and it's the point {midPointIndex + 1}");
Console.ReadKey();
return;


bool ArePointsLinear(List<Vector2> points) =>
    (points[1].Y - points[0].Y) * (points[2].X - points[1].X) == (points[2].Y - points[1].Y) * (points[1].X - points[0].X);


Vector2 GetMidPoint(List<Vector2> pts, out int midPointIndex)
{
    Vector2 midPoint = new();
    midPoint.X = (pts[0].X + pts[1].X + pts[2].X) / 3;
    midPoint.Y = (pts[0].Y + pts[1].Y + pts[2].Y) / 3;

    midPointIndex = pts.FindIndex(x => x == midPoint);

    return pts.Find(x => x == midPoint);

}
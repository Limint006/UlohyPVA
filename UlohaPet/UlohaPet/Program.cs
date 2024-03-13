using System.Numerics;

public struct Plane
{
    public Vector2 position;
    public string id;


    public Vector2 GetPosition() => position;

    public string GetId() => id;
}


public struct PlaneData
{
    public float distance;
    public string planeId;
    public string planeId2;
}


class Program
{
    static bool running = true;
    static List<Plane> planes = new();
    static List<PlaneData> planeDistances = new();
    static List<PlaneData> closestPlanes = new();

    static void Calculate()
    {
        while (running)
        {
            Plane plane = new();
            Console.WriteLine("enter plane coordinates (x, y):\n enter 'end' to stop");
            for (int i = 0; i < 2; i++)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    running = false;
                    CalculatePlaneDistances();
                    break;
                }

                if (!float.TryParse(input, out var planeCoordinate)) continue;
                if (i == 0)
                {
                    plane.position.X = planeCoordinate;
                }
                else
                {
                    plane.position.Y = planeCoordinate;
                }
            }
            Console.WriteLine("Enter plane id:");
            plane.id = Console.ReadLine();
            planes.Add(plane);
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void CalculatePlaneDistances()
    {
        for (int i = 0; i < planes.Count; ++i)
        {
            for (int j = i + 1; j < planes.Count; ++j)
            {
                Vector2 distanceVector = Vector2.Subtract(planes[i].position, planes[j].position);
                float distance = distanceVector.Length();
                PlaneData pd = new();
                pd.distance = distance;
                pd.planeId = planes[i].id;
                pd.planeId2 = planes[j].id;
                planeDistances.Add(pd);
            }
        }
        FindClosestPlanes();
        Console.ReadKey();
    }

    static void FindClosestPlanes()
    {
        float minDistance = planeDistances.Select(planeDistance => planeDistance.distance).Prepend(float.MaxValue).Min();
        foreach (var planeDistance in planeDistances.Where(planeDistance =>
                     Math.Abs(planeDistance.distance - minDistance) < 0.01f))
        {
            closestPlanes.Add(planeDistance);
        }

        Console.WriteLine("Closest planes are:");
        foreach (var closestPlane in closestPlanes)
        {
            Console.WriteLine($"{closestPlane.planeId} and {closestPlane.planeId2}");
        }
        Console.WriteLine($"With a distance of {minDistance}");

    }



    public static void Main(string[] args)
    {
        Calculate();
    }
}

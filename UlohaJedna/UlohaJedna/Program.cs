using System;

namespace Instalateri
{
    class Program
    {
        static int isOnWall(int[] point, int edge)
        {
            if (((point[0] == 0 || point[0] == edge) && point[1] >= 20 && point[1] <= edge - 20 && point[2] >= 20 && point[2] <= edge - 20) ||
                ((point[1] == 0 || point[1] == edge) && point[0] >= 20 && point[0] <= edge - 20 && point[2] >= 20 && point[2] <= edge - 20) ||
                ((point[2] == 0 || point[2] == edge) && point[1] >= 20 && point[1] <= edge - 20 && point[0] >= 20 && point[0] <= edge - 20))
            {
                return 1;
            }
            return 0;
        }

        static int findMinimum(int[] array, int count, int wantIndex)
        {
            int minimum = array[0];
            int minIndex = 0;
            for (int i = 0; i < count; i++)
            {
                if (array[i] < minimum)
                {
                    minimum = array[i];
                    minIndex = i;
                }
            }
            return wantIndex != 0 ? minIndex : minimum;
        }

        static double findMinimumDouble(double[] array, int count, int wantIndex)
        {
            double minimum = array[0];
            int minIndex = 0;
            for (int i = 0; i < count; i++)
            {
                if (array[i] < minimum)
                {
                    minimum = array[i];
                    minIndex = i;
                }
            }
            return wantIndex != 0 ? minIndex : minimum;
        }

        static void calculate_pipes()
        {
            int[][] points = new int[2][];
            for (int a = 0; a < 2; a++)
            {
                points[a] = new int[3];
            }
            int edge, opposite = 0, pipes = 0, i;
            double hose = 0;
            Console.WriteLine("Enter the dimensions of the room:");
            if (!int.TryParse(Console.ReadLine(), out edge) || edge < 0)
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            for (i = 0; i < 2; i++)
            {
                Console.WriteLine("Point #{0}(xyz):", i + 1);
                string[] input = Console.ReadLine().Split(' ');
                if (input.Length != 3 || !int.TryParse(input[0], out points[i][0]) || !int.TryParse(input[1], out points[i][1]) || !int.TryParse(input[2], out points[i][2]) || isOnWall(points[i], edge) == 0)
                {
                    Console.WriteLine("Invalid input.");
                    return;
                }
            }
            for (i = 0; i < 3; i++)
            {
                if ((points[0][i] == 0 && points[1][i] == edge) ||
                    (points[0][i] == edge && points[1][i] == 0))
                {
                    opposite = 1;
                    break;
                }
            }
            int wallIndex = 0;
            if (opposite != 0)
            {
                for (i = 0; i < 3; i++)
                {
                    if (points[0][i] == edge || points[0][i] == 0)
                    {
                        wallIndex = i;
                        break;
                    }
                }
                int[][][] lengths = new int[3][][];
                for (int j = 0; j < 3; j++)
                {
                    lengths[j] = new int[2][];
                    for (int k = 0; k < 2; k++)
                    {
                        lengths[j][k] = new int[4];
                    }
                }
                lengths[0][0][0] = edge - points[0][1] + edge + edge - points[1][1];
                lengths[0][0][1] = edge - points[0][2] + edge + edge - points[1][2];
                lengths[0][0][2] = points[0][1] + edge + points[1][1];
                lengths[0][0][3] = points[0][2] + edge + points[1][2];
                lengths[0][1][0] = Math.Abs(points[0][2] - points[1][2]);
                lengths[0][1][1] = Math.Abs(points[0][1] - points[1][1]);
                lengths[0][1][2] = Math.Abs(points[0][2] - points[1][2]);
                lengths[0][1][3] = Math.Abs(points[0][1] - points[1][1]);
                lengths[1][0][0] = edge - points[0][0] + edge + edge - points[1][0];
                lengths[1][0][1] = edge - points[0][2] + edge + edge - points[1][2];
                lengths[1][0][2] = points[0][2] + edge + points[1][2];
                lengths[1][0][3] = points[0][0] + edge + points[1][0];
                lengths[1][1][0] = Math.Abs(points[0][2] - points[1][2]);
                lengths[1][1][1] = Math.Abs(points[0][0] - points[1][0]);
                lengths[1][1][2] = Math.Abs(points[0][0] - points[1][0]);
                lengths[1][1][3] = Math.Abs(points[0][2] - points[1][2]);
                lengths[2][0][0] = edge - points[0][1] + edge + edge - points[1][1];
                lengths[2][0][1] = edge - points[0][0] + edge + edge - points[1][0];
                lengths[2][0][2] = points[0][1] + edge + points[1][1];
                lengths[2][0][3] = points[0][0] + edge + points[1][0];
                lengths[2][1][0] = Math.Abs(points[0][0] - points[1][0]);
                lengths[2][1][1] = Math.Abs(points[0][1] - points[1][1]);
                lengths[2][1][2] = Math.Abs(points[0][0] - points[1][0]);
                lengths[2][1][3] = Math.Abs(points[0][1] - points[1][1]);
                int[] c = new int[4];
                c[0] = lengths[wallIndex][0][0] + lengths[wallIndex][1][0];
                c[1] = lengths[wallIndex][0][1] + lengths[wallIndex][1][1];
                c[2] = lengths[wallIndex][0][2] + lengths[wallIndex][1][2];
                c[3] = lengths[wallIndex][0][3] + lengths[wallIndex][1][3];
                double[] t = new double[4];
                t[0] = Math.Sqrt(Math.Pow(lengths[wallIndex][0][0], 2.0) + Math.Pow(lengths[wallIndex][1][0], 2.0));
                t[1] = Math.Sqrt(Math.Pow(lengths[wallIndex][0][1], 2.0) + Math.Pow(lengths[wallIndex][1][1], 2.0));
                t[2] = Math.Sqrt(Math.Pow(lengths[wallIndex][0][2], 2.0) + Math.Pow(lengths[wallIndex][1][2], 2.0));
                t[3] = Math.Sqrt(Math.Pow(lengths[wallIndex][0][3], 2.0) + Math.Pow(lengths[wallIndex][1][3], 2.0));
                pipes = findMinimum(c, 4, 0);
                hose = findMinimumDouble(t, 4, 0);
            }
            else
            {
                if (points[0][0] != 0 && points[0][0] != edge && points[1][0] != 0 && points[1][0] != edge)
                    hose = Math.Sqrt(Math.Pow(points[1][0] - points[0][0], 2.0) + (Math.Abs(points[1][1] - points[0][1]) + Math.Abs(points[1][2] - points[0][2])) * (Math.Abs(points[1][1] - points[0][1]) + Math.Abs(points[1][2] - points[0][2])));
                else if (points[1][1] != 0 && points[1][1] != edge && points[0][1] != 0 && points[0][1] != edge)
                    hose = Math.Sqrt(Math.Pow(points[1][1] - points[0][1], 2.0) + (Math.Abs(points[1][0] - points[0][0]) + Math.Abs(points[1][2] - points[0][2])) * (Math.Abs(points[1][0] - points[0][0]) + Math.Abs(points[1][2] - points[0][2])));
                else if (points[1][2] != 0 && points[1][2] != edge && points[0][2] != 0 && points[0][2] != edge)
                    hose = Math.Sqrt(Math.Pow(points[1][2] - points[0][2], 2.0) + (Math.Abs(points[1][0] - points[0][0]) + Math.Abs(points[1][1] - points[0][1])) * (Math.Abs(points[1][0] - points[0][0]) + Math.Abs(points[1][1] - points[0][1])));
                pipes = Math.Abs(points[0][0] - points[1][0]) + Math.Abs(points[0][1] - points[1][1]) + Math.Abs(points[0][2] - points[1][2]);
            }
            Console.WriteLine("Delka potrubi: " + pipes);
            Console.WriteLine("Delka hadice: " + hose);
            return;
        }

        static void Main(string[] args)
        {
            calculate_pipes();
        }
    }
}
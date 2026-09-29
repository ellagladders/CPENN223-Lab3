// Lab 3
// Student name: Ella Gladders
// Student number: 78754249

using System;
using System.Collections.Generic;

Console.WriteLine("CPEN223 Lab 3");

//Testing: Write some test cases to test well all methods you are to implement    
//         This is to demonstrates what test cases you have considered
//TODO 
// bool actual = SensorAnalyzer.IsUsableReading(21.5, 0.0, 50.0);
// Console.WriteLine($"Expected: True, Actual: {actual}");

// IsUsableReading
bool test1 = SensorAnalyzer.IsUsableReading(21.5, 0.0, 50.0);
Console.WriteLine($"Expected: True, Actual: {test1}");

bool test2 = SensorAnalyzer.IsUsableReading(double.NaN, 0.0, 50.0);
Console.WriteLine($"Expected: False, Actual: {test2}");


// CleanReadings
List<double> readings = new() { 20.0, double.NaN, -5.0, 21.0 };
List<double> cleaned = SensorAnalyzer.CleanReadings(readings, 0.0, 50.0);
Console.WriteLine($"Expected: 20, 21 | Actual: {string.Join(", ", cleaned)}");


// ContainsApproximately
List<double> values = new() { 0.1 + 0.2 };
bool test3 = SensorAnalyzer.ContainsApproximately(values, 0.3, 1e-12);
Console.WriteLine($"Expected: True, Actual: {test3}");


// MovingAverage
List<double> moving = new() { 1.0, 2.0, 3.0, 4.0 };
List<double> average = SensorAnalyzer.MovingAverage(moving, 2);
Console.WriteLine($"Expected: 1.5, 2.5, 3.5 | Actual: {string.Join(", ", average)}");

List<double> moving2 = new() { 2.0, 4.0, 6.0 };
List<double> average2 = SensorAnalyzer.MovingAverage(moving2, 4);
Console.WriteLine($"Expected: empty | Actual: {string.Join(", ", average2)}");

//end Testing code

//Do not change the program skeleton
public static class SensorAnalyzer
{
    public static bool IsUsableReading(
        double reading, double minimum, double maximum)
    {
        if (!double.IsFinite(minimum) || !double.IsFinite(maximum) || minimum > maximum) 
        {
            throw new ArgumentException();
        }
        if (!double.IsFinite(reading))
        {
            return false;
        }
        else if (reading >= minimum && reading <= maximum)
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }

    public static List<double> CleanReadings(
        IReadOnlyList<double> readings, double minimum, double maximum)
    {
    if (!double.IsFinite(minimum) || !double.IsFinite(maximum)|| minimum > maximum)
        {
            throw new ArgumentException();
        }
    if ((readings == null))
        {
            throw new ArgumentException();
        }
    List<double> cleaned = new List<double>();

    foreach(double reading in readings)
        {
            if (IsUsableReading(reading, minimum, maximum))
            {
                cleaned.Add(reading); 
            }
        }
    return cleaned;
    }

    public static bool ContainsApproximately(
        IReadOnlyList<double> readings, double target, double tolerance)
    {
    if (readings == null) 
        {
            throw new ArgumentException();
        }
    if (!double.IsFinite(target) || !double.IsFinite(tolerance) || tolerance < 0.0) 
        {
            throw new ArgumentException();
        }
    foreach (double reading in readings)
        {
            if (Math.Abs(reading - target) <= tolerance)
            {
                return true;
            }
        }
    return false;
    }

    public static List<double> MovingAverage(
        IReadOnlyList<double> readings, int windowSize)
    {
    if (readings == null) 
        {
            throw new ArgumentException();
        }
    if (windowSize <= 0) 
        {
            throw new ArgumentException();
        }
    
    foreach (double reading in readings)
        {
            if (!double.IsFinite(reading))
            {
                throw new ArgumentException();
            }
        }

    List<double> averages = new List<double>();

    if (windowSize > readings.Count)
        {
            return averages;
        }
    for (int i = 0; i <= readings.Count - windowSize; i++)
        {
        double sum = 0.0;

        for (int j = 0; j < windowSize; j++)
            {
                sum += readings[i+j]; 
            }
        averages.Add(sum / windowSize);
        }
        return averages;
    }
}

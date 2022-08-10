using Math = NeonSugar.Sandbox.Utils.Math;


namespace NeonSugar.SandboxTest;

internal static class Program
{
	internal static void Main()
	{
		Console.WriteLine($"Min: {Math.Min(20, 1.1f, 1.11, 0.5)}");
		Console.WriteLine($"Max: {Math.Max(20, 1.1f, 1.11, 0.5)}");
	}
}
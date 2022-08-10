namespace NeonSugar.Sandbox.Utils;

public static class Math
{
	public static T? Min<T>(params T[] numbers) where T : IComparable
		=> numbers.Min();
	public static T? Max<T>(params T[] numbers) where T : IComparable
		=> numbers.Max();

	
}

using System.Net.NetworkInformation;


namespace NeonSugar.Sandbox.Patterns.Creational.Singleton;
/*
namespace NeonSugar.Sandbox.Patterns.Creational;
namespace NeonSugar.Sandbox.Patterns.Structural;
namespace NeonSugar.Sandbox.Patterns.Behavioral;
*/

public sealed class Singleton
{
	private static Singleton? _instance = null;

	public static Singleton Instance 
		=> _instance ?? new Singleton();
}

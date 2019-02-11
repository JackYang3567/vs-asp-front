using System;
namespace Game.Utils
{
	[Flags]
	public enum FilterType
	{
		Script = 1,
		Html = 2,
		Object = 3,
		AHrefScript = 4,
		Iframe = 5,
		Frameset = 6,
		Src = 7,
		BadWords = 8,
		Sql = 9,
		All = 16
	}
}

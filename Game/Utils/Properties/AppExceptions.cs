using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
namespace Game.Utils.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class AppExceptions
	{
		private static CultureInfo resourceCulture;
		private static ResourceManager resourceMan;
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return AppExceptions.resourceCulture;
			}
			set
			{
				AppExceptions.resourceCulture = value;
			}
		}
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(AppExceptions.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Game.Utils.Properties.Resources", typeof(Resources).Assembly);
					AppExceptions.resourceMan = resourceManager;
				}
				return AppExceptions.resourceMan;
			}
		}
		internal static string Terminator_ExceptionTemplate
		{
			get
			{
				return AppExceptions.ResourceManager.GetString("Terminator_ExceptionTemplate", AppExceptions.resourceCulture);
			}
		}
		internal AppExceptions()
		{
		}
	}
}

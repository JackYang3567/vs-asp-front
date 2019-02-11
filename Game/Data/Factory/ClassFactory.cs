using Game.IData;
using Game.Kernel;
using Game.Utils;
using System;
namespace Game.Data.Factory
{
	public class ClassFactory
	{
		public static IAccountsDataProvider GetIAccountsDataProvider()
		{
			return ProxyFactory.CreateInstance<AccountsDataProvider>(new object[]
			{
				ApplicationSettings.Get("DBAccounts")
			});
		}
		public static INativeWebDataProvider GetINativeWebDataProvider()
		{
			return ProxyFactory.CreateInstance<NativeWebDataProvider>(new object[]
			{
				ApplicationSettings.Get("DBNativeWeb")
			});
		}
		public static IPlatformDataProvider GetIPlatformDataProvider()
		{
			return ProxyFactory.CreateInstance<PlatformDataProvider>(new object[]
			{
				ApplicationSettings.Get("DBPlatform")
			});
		}
		public static IRecordDataProvider GetIRecordDataProvider()
		{
			return ProxyFactory.CreateInstance<RecordDataProvider>(new object[]
			{
				ApplicationSettings.Get("DBRecord")
			});
		}
		public static ITreasureDataProvider GetITreasureDataProvider()
		{
			return ProxyFactory.CreateInstance<TreasureDataProvider>(new object[]
			{
				ApplicationSettings.Get("DBTreasure")
			});
		}
		public static ITreasureDataProvider GetITreasureDataProvider(int KindID)
		{
			return ProxyFactory.CreateInstance<TreasureDataProvider>(new object[]
			{
				new PlatformDataProvider(ApplicationSettings.Get("DBPlatform")).GetConn(KindID)
			});
		}
		public static IGameMatchProvider GetIGameMatchProvider()
		{
			return ProxyFactory.CreateInstance<GameMatchDataProvider>(new object[]
			{
				ApplicationSettings.Get("DBGameMatch")
			});
		}
	}
}

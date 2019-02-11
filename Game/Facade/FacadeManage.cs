using System;
namespace Game.Facade
{
	public class FacadeManage
	{
		private static object lockObj = new object();
		private static volatile NativeWebFacade _aideNativeWebFacade;
		private static volatile PlatformFacade _aidePlatformFacade;
		private static volatile TreasureFacade _aideTreasureFacade;
		private static volatile AccountsFacade _aideAccountsFacade;
		private static volatile RecordFacade _aideRecordFacade;
		private static volatile GameMatchFacade _aideGameMatchFacade;
		public static NativeWebFacade aideNativeWebFacade
		{
			get
			{
				if (FacadeManage._aideNativeWebFacade == null)
				{
					lock (FacadeManage.lockObj)
					{
						if (FacadeManage._aideNativeWebFacade == null)
						{
							FacadeManage._aideNativeWebFacade = new NativeWebFacade();
						}
					}
				}
				return FacadeManage._aideNativeWebFacade;
			}
		}
		public static PlatformFacade aidePlatformFacade
		{
			get
			{
				if (FacadeManage._aidePlatformFacade == null)
				{
					lock (FacadeManage.lockObj)
					{
						if (FacadeManage._aidePlatformFacade == null)
						{
							FacadeManage._aidePlatformFacade = new PlatformFacade();
						}
					}
				}
				return FacadeManage._aidePlatformFacade;
			}
		}
		public static TreasureFacade aideTreasureFacade
		{
			get
			{
				if (FacadeManage._aideTreasureFacade == null)
				{
					lock (FacadeManage.lockObj)
					{
						if (FacadeManage._aideTreasureFacade == null)
						{
							FacadeManage._aideTreasureFacade = new TreasureFacade();
						}
					}
				}
				return FacadeManage._aideTreasureFacade;
			}
		}
		public static AccountsFacade aideAccountsFacade
		{
			get
			{
				if (FacadeManage._aideAccountsFacade == null)
				{
					lock (FacadeManage.lockObj)
					{
						if (FacadeManage._aideAccountsFacade == null)
						{
							FacadeManage._aideAccountsFacade = new AccountsFacade();
						}
					}
				}
				return FacadeManage._aideAccountsFacade;
			}
		}
		public static RecordFacade aideRecordFacade
		{
			get
			{
				if (FacadeManage._aideRecordFacade == null)
				{
					lock (FacadeManage.lockObj)
					{
						if (FacadeManage._aideRecordFacade == null)
						{
							FacadeManage._aideRecordFacade = new RecordFacade();
						}
					}
				}
				return FacadeManage._aideRecordFacade;
			}
		}
		public static GameMatchFacade aideGameMatchFacade
		{
			get
			{
				if (FacadeManage._aideGameMatchFacade == null)
				{
					lock (FacadeManage.lockObj)
					{
						if (FacadeManage._aideGameMatchFacade == null)
						{
							FacadeManage._aideGameMatchFacade = new GameMatchFacade();
						}
					}
				}
				return FacadeManage._aideGameMatchFacade;
			}
		}
	}
}

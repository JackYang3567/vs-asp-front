namespace Game.Utils
{
    public partial class PageBase : System.Web.UI.Page
    {
        public PageBase()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private Logger _logger;

        public string WebDomain
        {
            get { return Common.GetAppSetting("WebDomain"); }
        }

        public Logger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Logger("File");
                }
                return _logger;
            }
        }

        public void ResponseToEnd(string @this)
        {
            Response.Clear();
            Response.Write(@this);
            Response.End();
        }
    }
}
using System;
using System.Collections.Generic;
namespace Game.Facade.SiteLibrary
{
	public class FilesComparer : IComparer<HttpFolderInfo>
	{
		private string _sortColumn;
		public FilesComparer(string sortExpression)
		{
			this._sortColumn = sortExpression;
		}
		public int Compare(HttpFolderInfo a, HttpFolderInfo b)
		{
			string a2;
			int result;
			if ((a2 = this._sortColumn.ToLower()) != null)
			{
				if (a2 == "name")
				{
					result = string.Compare(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase);
					return result;
				}
				if (a2 == "ext")
				{
					result = string.Compare(a.ExtName, b.ExtName, StringComparison.InvariantCultureIgnoreCase);
					return result;
				}
				if (a2 == "size")
				{
					result = string.Compare(a.FormatSize, b.FormatSize, StringComparison.InvariantCultureIgnoreCase);
					return result;
				}
				if (a2 == "modifydate")
				{
					result = DateTime.Compare(DateTime.Parse(a.FormatModifyDate), DateTime.Parse(b.FormatModifyDate));
					return result;
				}
			}
			result = string.Compare(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase);
			return result;
		}
	}
}

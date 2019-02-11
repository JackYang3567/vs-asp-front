using Game.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
namespace Game.Facade.SiteLibrary
{
	public class HttpFileManager
	{
		private string m_value;
		private bool m_access;
		private string m_folderPath;
		private string m_uploadFilePath;
		private int m_folderCount;
		private int m_FileCount;
		public string Value
		{
			get
			{
				return this.m_value;
			}
		}
		public string UploadFilePath
		{
			get
			{
				return this.m_uploadFilePath;
			}
		}
		public bool Access
		{
			get
			{
				return this.m_access;
			}
		}
		public int FolderCount
		{
			get
			{
				return this.m_folderCount;
			}
		}
		public int FileCount
		{
			get
			{
				return this.m_FileCount;
			}
		}
		public HttpFileManager()
		{
			this.m_value = "";
			this.m_access = false;
			this.m_folderPath = "";
			this.m_folderCount = 0;
			this.m_FileCount = 0;
			HttpRequest request = HttpContext.Current.Request;
			this.m_folderPath = request.QueryString["path"];
		}
		public HttpFileManager(string p_act)
		{
			HttpRequest request = HttpContext.Current.Request;
			this.m_folderPath = request.QueryString["path"];
			if (p_act != null)
			{
				if (p_act == "create")
				{
					this.CreateFolder();
					return;
				}
				if (p_act == "delete")
				{
					this.DeleteFileFolder();
					return;
				}
				if (!(p_act == "upload"))
				{
					return;
				}
				this.UploadFile();
			}
		}
		public List<HttpFolderInfo> GetDirectories(string folderPath, string rootPath)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string queryString = GameRequest.GetQueryString("order");
			List<HttpFolderInfo> list = new List<HttpFolderInfo>();
			IList<FolderInfo> directoryFilesListForObject = FileManager.GetDirectoryFilesListForObject(folderPath, FsoMethod.All);
			if (directoryFilesListForObject == null || directoryFilesListForObject.Count <= 0)
			{
				this.m_access = false;
				return list;
			}
			foreach (FolderInfo current in directoryFilesListForObject)
			{
				stringBuilder.Remove(0, stringBuilder.Length);
				if (current.FsoType == FsoMethod.Folder)
				{
					stringBuilder.AppendFormat("<a href=\"Web_FilesManager.aspx?path={0}\">", Utility.UrlEncode(rootPath + "/" + current.Name)).AppendFormat("<img src=\"images/attach/files/folder.gif\" alt=\"文件夹\" align=\"absmiddle\" /> {0} </a>", current.Name).AppendFormat(" <a href=\"Web_FilesManager.aspx?act=compress&amp;path={0}&amp;objfolder={1}\" onclick=\"javascript:compressMsg();\">", Utility.UrlEncode(this.m_folderPath), Utility.UrlEncode(current.FullName));
					HttpFolderInfo item = new HttpFolderInfo(current.Name, Utility.UrlEncode(current.FullName), stringBuilder.ToString(), "", 0L, "folder", current.LastWriteTime);
					list.Add(item);
					this.m_folderCount++;
				}
				if (current.FsoType == FsoMethod.File)
				{
					if (TextUtility.InArray(current.ContentType, "jpg,gif,png,bmp,psd", ",", true))
					{
						stringBuilder.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"showPopWin('Web_FilesView.aspx?url=file.axd?file={0}',700,433,null);\">", Utility.UrlEncode(rootPath + "/" + current.Name)).AppendFormat("<img src=\"images/attach/files/{1}.gif\" alt=\"文件\" align=\"absmiddle\" /> {0}</a>", current.Name, current.ContentType);
					}
					else
					{
						stringBuilder.AppendFormat("<a href=\"file.axd?file={0}\" target=\"_new\">", Utility.UrlEncode(rootPath + "/" + current.Name));
						string arg = "default";
						string contentType;
						switch (contentType = current.ContentType)
						{
						case "mp3":
						case "wav":
						case "wma":
						case "wmv":
							arg = "mp3";
							break;
						case "zip":
						case "7z":
						case "rar":
							arg = "zip";
							break;
						}
						if (!TextUtility.EmptyTrimOrNull(current.ContentType) && TextUtility.InArray(current.ContentType, "css,dll,doc,docx,swf,txt,xls,xlsx,xml", ",", true))
						{
							arg = current.ContentType;
						}
						stringBuilder.AppendFormat("<img src=\"images/attach/files/{1}.gif\" alt=\"文件\" align=\"absmiddle\" /> {0}</a>", current.Name, arg);
					}
					HttpFolderInfo item2 = new HttpFolderInfo(current.Name, Utility.UrlEncode(current.FullName), stringBuilder.ToString(), current.ContentType, current.Length, "file", current.LastWriteTime);
					list.Add(item2);
					this.m_FileCount++;
				}
			}
			this.m_access = true;
			if (!TextUtility.EmptyTrimOrNull(queryString))
			{
				list.Sort(new FilesComparer(queryString));
			}
			return list;
		}
		private void CreateFolder()
		{
			string formString = GameRequest.GetFormString("txtFolderName");
			string realPath = TextUtility.GetRealPath(this.m_folderPath);
			if (TextUtility.EmptyTrimOrNull(formString))
			{
				this.m_value = "目录名不能为空";
				return;
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(realPath + "\\" + formString);
			if (directoryInfo.Exists)
			{
				this.m_value = "目录名已存在";
				return;
			}
			try
			{
				directoryInfo.Create();
				this.m_value = "创建目录成功, 目录名称为: " + formString;
			}
			catch
			{
				this.m_value = "创建目录失败, 权限不足";
			}
		}
		private void DeleteFileFolder()
		{
			string queryString = GameRequest.GetQueryString(HttpContext.Current.Request, "file");
			string realPath = TextUtility.GetRealPath(queryString);
			string queryString2 = GameRequest.GetQueryString(HttpContext.Current.Request, "type");
			if (TextUtility.EmptyTrimOrNull(queryString) || !queryString.StartsWith("/upload"))
			{
				this.m_value = "要删除的文件不存在";
				return;
			}
			if (queryString2 == "file")
			{
				if (File.Exists(realPath))
				{
					try
					{
						File.Delete(realPath);
						this.m_value = "删除文件成功, 被删除的文件为: " + Path.GetFileName(realPath);
						return;
					}
					catch
					{
						this.m_value = "删除文件失败, 权限不足";
						return;
					}
				}
				this.m_value = "要删除的文件不存在";
				return;
			}
			if (queryString2 == "folder")
			{
				if (Directory.Exists(realPath))
				{
					try
					{
						Directory.Delete(realPath, true);
						this.m_value = "删除目录成功, 被删除的目录为: " + Path.GetFileName(realPath);
						return;
					}
					catch
					{
						this.m_value = "删除目录失败, 权限不足";
						return;
					}
				}
				this.m_value = "要删除的目录不存在";
			}
		}
		private void UploadFile()
		{
			HttpRequest request = HttpContext.Current.Request;
			HttpPostedFile httpPostedFile = request.Files["fileUpload"];
			string realPath = TextUtility.GetRealPath(this.m_folderPath);
			if (httpPostedFile.ContentLength == 0)
			{
				this.m_value = "请先选择文件";
				return;
			}
			if (httpPostedFile.ContentLength > 4096000)
			{
				this.m_value = "文件过大，无法进行上传";
				return;
			}
			if (httpPostedFile.ContentType.ToUpper().IndexOf("IMAGE") == -1)
			{
				this.m_value = "请选择图片文件";
				return;
			}
			string fileName = Path.GetFileName(httpPostedFile.FileName);
			if (File.Exists(realPath + "\\" + fileName))
			{
				Random random = new Random();
				string text = string.Concat(new object[]
				{
					Path.GetFileNameWithoutExtension(fileName),
					"_",
					random.Next(1, 1000),
					Path.GetExtension(fileName)
				});
				try
				{
					httpPostedFile.SaveAs(realPath + "\\" + text);
					this.m_value = "上传的文件名已存在, 自动重命名为: " + text;
					this.m_uploadFilePath = TextUtility.AddLast(this.m_folderPath, "/") + text;
					return;
				}
				catch
				{
					this.m_value = "写入文件失败, 权限不足";
					return;
				}
			}
			try
			{
				httpPostedFile.SaveAs(realPath + "\\" + fileName);
				this.m_value = "上传文件完毕, 文件名为: " + fileName;
				this.m_uploadFilePath = TextUtility.AddLast(this.m_folderPath, "/") + fileName;
			}
			catch
			{
				this.m_value = "写入文件失败, 权限不足";
			}
		}
	}
}

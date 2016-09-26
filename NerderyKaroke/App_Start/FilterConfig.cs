using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace NerderyKaroke
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FILEPATH = basePath + @"\Data\songList.json";

            if (!File.Exists(FILEPATH))
                File.AppendText(FILEPATH);
        }
    }
}

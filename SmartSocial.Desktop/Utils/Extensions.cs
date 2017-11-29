using System;
using NLog;

namespace SmartSocial.Desktop.Utils
{
    public class Extensions
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public string GetAllowedExtension(string extension)
        {
            var response = "";
            try {
                if (extension.Equals("xls") || extension.Equals("xlsx"))
                {
                    response = "Excel files (*.xls or .xlsx)|.xls;*.xlsx";
                }
                if(extension.Equals("txt"))
                {
                    response = "Text|*.txt|All|*.*";
                }
            }
            catch (Exception e) {
                _logger.Error("Error ex:" + e.Message);
            }
            return response;

            
        }
    }
}

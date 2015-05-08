using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Descripción breve de AppConfig
/// </summary>

namespace pe.com.rbtec.web
{
    public static class AppConfig
    {
        //PARAMETROS MAIL
        const string sendMailEnabled = "SendMailEnabled";
        const string pathTemplateHTML = "PathTemplateHTML";
        const string url6M = "Url6M";
        const string refreshInterval = "RefreshInterval";

        public static string nombreEmpresa()
        {
            //string strTmp = "";
            //if (System.Configuration.ConfigurationManager.AppSettings["AppNombreEmpresa"] != null) {
            //    strTmp = System.Configuration.ConfigurationManager.AppSettings["AppNombreEmpresa"];
            //}
            return "LA GRAN GUIA S.A.\nSERVICIOS DE PUBLICIDAD\nLOS CONQUITADORES #1700, PISO 4\nPROVIDENCIA\n99.538.470-1\n2SANTIAGO";
        }

        public static string nombreSistema()
        {
            string strTmp = "";
            if (System.Configuration.ConfigurationManager.AppSettings["AppNombreSistema"] != null)
            {
                strTmp = System.Configuration.ConfigurationManager.AppSettings["AppNombreSistema"];
            }
            return strTmp;
        }

        public static string AppCultureInfo()
        {
            string strTmp = "";
            if (System.Configuration.ConfigurationManager.AppSettings["AppCultureInfo"] != null)
            {
                strTmp = System.Configuration.ConfigurationManager.AppSettings["AppCultureInfo"];
            }
            return strTmp;
        }

        public static string usuarioActual()
        {
            return HttpContext.Current.User.Identity.Name;
        }

        public static float iva()
        {
            return 0.19f;
        }

        /// <summary>
        /// Recupera un valor desde el web.config dado un key
        /// </summary>
        private static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        #region -- Parametros Mail --

        public static string Url6R
        {
            get { return Convert.ToString(GetValue(url6R)); }
        }

        public static int RefreshInterval
        {
            get { return Convert.ToInt32(GetValue(refreshInterval)); }
        }

        public static bool SendMailEnabled
        {
            get { return Convert.ToBoolean(GetValue(sendMailEnabled)); }
        }

        public static string PathTemplateHTML
        {
            get { return Convert.ToString(GetValue(pathTemplateHTML)); }
        }

        #endregion
    }
}


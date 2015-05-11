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
        #region Keys

        const string enterprisename = "Enterprisename";
        const string enableClearCacheSystem = "EnableClearCacheSystem";
        const string pathUserImage = "PathUserImage";
        const string pathOrganizationImage = "PathOrganizationImage";
        const string pathAttachmentFiles = "PathAttachmentFiles";
        //PARAMETROS MAIL
        const string sendMailEnabled = "SendMailEnabled";
        const string pathTemplateHTML = "PathTemplateHTML";
        const string url6R = "Url6R";
        const string refreshInterval = "RefreshInterval";        
        
        #endregion


        public static string nombreEmpresa()
        {
            string strTmp = "";
            if (System.Configuration.ConfigurationManager.AppSettings["AppNombreEmpresa"] != null)
            {
                strTmp = System.Configuration.ConfigurationManager.AppSettings["AppNombreEmpresa"];
            }
            return strTmp;
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



        #region Properties

        /// <summary>
        /// Devuelve la direccion de la carpeta de archivos adjuntos
        /// </summary>
        public static string PathAttachmentFiles
        {
            get { return GetValue(pathAttachmentFiles); }
        }

        /// <summary>
        /// Devuelve la direccion de la carpeta de imagenes de usuario
        /// </summary>
        public static string PathOrganizationImage
        {
            get { return GetValue(pathOrganizationImage); }
        }

        /// <summary>
        /// Devuelve la direccion de la carpeta de imagenes de usuario
        /// </summary>
        public static string PathUserImage
        {
            get { return GetValue(pathUserImage); }
        }

        /// <summary>
        ///Recupera Valor que indica si se usara la caracteristica de limpiar cache
        /// </summary>
        public static string EnableClearCacheSystem
        {
            get { return GetValue(enableClearCacheSystem); }
        }

        /// <summary>
        ///Recupera el nombre del sistema actual
        /// </summary>
        public static string Enterprisename
        {
            get { return GetValue(enterprisename); }
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

        #endregion
    }
}


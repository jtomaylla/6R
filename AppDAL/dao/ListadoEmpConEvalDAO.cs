using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using pe.com.sil.dal.dto;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace pe.com.sil.dal.dao
{
    public  class ListadoEmpConEvalDAO
    {

        const string C_GENERAR_LISTADO = "USP_Empleado_ListarConEvaluacion";

        public DataTable ListarTodos(int codigounidad, DateTime fechaini, DateTime fechafin)
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
                DbCommand dbCommand = db.GetStoredProcCommand(C_GENERAR_LISTADO);
                db.AddInParameter(dbCommand, "@codigounidad", DbType.Int32, codigounidad);
                db.AddInParameter(dbCommand, "@fechaini", DbType.Date, fechaini);
                db.AddInParameter(dbCommand, "@fechafin", DbType.Date, fechafin);

                ds = db.ExecuteDataSet(dbCommand);
                dt = ds.Tables[0];
                if (dt != null) { return dt; } else { return null; }
            }

    }
}

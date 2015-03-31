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
    public class GradoDAO
    {

        const string C_LISTAR = "USP_Grado_Listar";
        const string C_ACTUALIZAR = "USP_Grado_Actualizar";
        const string C_AGREGAR = "USP_Grado_Agregar";
        const string C_ELIMINAR = "USP_Grado_Eliminar";

        public List<GradoDTO> Listar()
        {
            List<GradoDTO> Lista = new List<GradoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    GradoDTO obj = new GradoDTO();
                    if (dr["CodigoGrado"] != System.DBNull.Value)
                        obj.CodigoGrado = (int)dr["CodigoGrado"];
                    if (dr["Nombre"] != System.DBNull.Value)
                        obj.Nombre = (string)dr["Nombre"];
                    if (dr["Estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["Estado"];
                    Lista.Add(obj);
                }
            }
            return Lista;
        }

        public int Agregar(GradoDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
            db.AddInParameter(dbCommand, "@Nombre", DbType.String, obj.Nombre);
            db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return id;
        }

        public void Actualizar(GradoDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
            db.AddInParameter(dbCommand, "@CodigoGrado", DbType.Int32, obj.CodigoGrado);
            db.AddInParameter(dbCommand, "@Nombre", DbType.String, obj.Nombre);
            db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Eliminar(string CodigoGrado)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
            db.AddInParameter(dbCommand, "@CodigoGrado", DbType.Int32, CodigoGrado);
            db.ExecuteNonQuery(dbCommand);
        }

    }
}

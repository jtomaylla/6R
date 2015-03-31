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
    public class PuestoDAO
    {

        const string C_LISTAR = "USP_Puesto_Listar";
        const string C_ACTUALIZAR = "USP_Puesto_Actualizar";
        const string C_AGREGAR = "USP_Puesto_Agregar";
        const string C_ELIMINAR = "USP_Puesto_Eliminar";

        public List<PuestoDTO> Listar()
        {
            List<PuestoDTO> Lista = new List<PuestoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    PuestoDTO obj = new PuestoDTO();
                    if (dr["CodigoPuesto"] != System.DBNull.Value)
                        obj.CodigoPuesto = (int)dr["CodigoPuesto"];
                    if (dr["Nombre"] != System.DBNull.Value)
                        obj.Nombre = (string)dr["Nombre"];
                    if (dr["Estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["Estado"];
                    Lista.Add(obj);
                }
            }
            return Lista;
        }

        public int Agregar(PuestoDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
            db.AddInParameter(dbCommand, "@Nombre", DbType.String, obj.Nombre);
            db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return id;
        }

        public void Actualizar(PuestoDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
            db.AddInParameter(dbCommand, "@CodigoPuesto", DbType.Int32, obj.CodigoPuesto);
            db.AddInParameter(dbCommand, "@Nombre", DbType.String, obj.Nombre);
            db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Eliminar(string CodigoPuesto)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
            db.AddInParameter(dbCommand, "@CodigoPuesto", DbType.Int32, CodigoPuesto);
            db.ExecuteNonQuery(dbCommand);
        }

    }
}

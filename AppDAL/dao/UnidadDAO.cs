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
    public class UnidadDAO
    {
        const string C_BUSCAR_POR_CLAVE = "SELECT CodigoUnidad, Nombre, estado " +
                                "FROM Unidad " +
                                "WHERE CodigoUnidad = @CodigoUnidad";

        const string C_LISTAR = "USP_Unidad_Listar";
        const string C_ACTUALIZAR = "USP_Unidad_Actualizar";
        const string C_AGREGAR = "USP_Unidad_Agregar";
        const string C_ELIMINAR = "USP_Unidad_Eliminar";
        public UnidadDTO ListarPorClave(int id)
        {
            UnidadDTO obj = new UnidadDTO();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_BUSCAR_POR_CLAVE);
            db.AddInParameter(dbCommand, "@CodigoUnidad", DbType.Int32, id);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    obj.CodigoUnidad = (int)dr["CodigoUnidad"];

                    if (dr["Nombre"] != System.DBNull.Value)
                        obj.Nombre = (string)dr["Nombre"];

                    if (dr["Estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["Estado"];

                }
            }
            return obj;
        }
        public List<UnidadDTO> Listar()
        {
            List<UnidadDTO> Lista = new List<UnidadDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    UnidadDTO obj = new UnidadDTO();
                    if (dr["CodigoUnidad"] != System.DBNull.Value)
                        obj.CodigoUnidad = (int)dr["CodigoUnidad"];
                    if (dr["Nombre"] != System.DBNull.Value)
                        obj.Nombre = (string)dr["Nombre"];
                    if (dr["Estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["Estado"];
                    Lista.Add(obj);
                }
            }
            return Lista;
        }

        public int Agregar(UnidadDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
            db.AddInParameter(dbCommand, "@Nombre", DbType.String, obj.Nombre);
            db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return id;
        }

        public void Actualizar(UnidadDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
            db.AddInParameter(dbCommand, "@CodigoUnidad", DbType.Int32, obj.CodigoUnidad);
            db.AddInParameter(dbCommand, "@Nombre", DbType.String, obj.Nombre);
            db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Eliminar(string CodigoUnidad)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
            db.AddInParameter(dbCommand, "@CodigoUnidad", DbType.Int32, CodigoUnidad);
            db.ExecuteNonQuery(dbCommand);
        }

    }
}

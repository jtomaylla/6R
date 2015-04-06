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
    public class JefeDAO
    {
        const string C_BUSCAR_POR_CLAVE = "SELECT CodigoJefe, Nombre, estado " +
                                "FROM Jefe " +
                                "WHERE CodigoJefe = @CodigoJefe";
        const string C_LISTAR = "USP_Jefe_Listar";
        const string C_ACTUALIZAR = "USP_Jefe_Actualizar";
        const string C_AGREGAR = "USP_Jefe_Agregar";
        const string C_ELIMINAR = "USP_Jefe_Eliminar";
        public JefeDTO ListarPorClave(int id)
        {
            JefeDTO obj = new JefeDTO();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_BUSCAR_POR_CLAVE);
            db.AddInParameter(dbCommand, "@CodigoJefe", DbType.Int32, id);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    obj.CodigoJefe = (int)dr["CodigoJefe"];

                    if (dr["Nombre"] != System.DBNull.Value)
                        obj.Nombre = (string)dr["Nombre"];

                    if (dr["Estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["Estado"];

                }
            }
            return obj;
        }

        public List<JefeDTO> Listar()
        {
            List<JefeDTO> Lista = new List<JefeDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    JefeDTO obj = new JefeDTO();
                    if (dr["CodigoJefe"] != System.DBNull.Value)
                        obj.CodigoJefe = (int)dr["CodigoJefe"];
                    if (dr["Nombre"] != System.DBNull.Value)
                        obj.Nombre = (string)dr["Nombre"];
                    if (dr["Estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["Estado"];
                    Lista.Add(obj);
                }
            }
            return Lista;
        }

        public int Agregar(JefeDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
            db.AddInParameter(dbCommand, "@Nombre", DbType.String, obj.Nombre);
            db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return id;
        }

        public void Actualizar(JefeDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
            db.AddInParameter(dbCommand, "@CodigoJefe", DbType.Int32, obj.CodigoJefe);
            db.AddInParameter(dbCommand, "@Nombre", DbType.String, obj.Nombre);
            db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Eliminar(string CodigoJefe)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
            db.AddInParameter(dbCommand, "@CodigoJefe", DbType.Int32, CodigoJefe);
            db.ExecuteNonQuery(dbCommand);
        }

    }
}

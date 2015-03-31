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
    public class SedeDAO
    {
        const string C_BUSCAR_POR_CLAVE = "SELECT CodigoSede, Nombre, estado " +
                                        "FROM SEDE " +
                                        "WHERE CodigoSede = @CodigoSede";
        const string C_LISTAR = "USP_Sede_Listar";
        const string C_ACTUALIZAR = "USP_Sede_Actualizar";
        const string C_AGREGAR = "USP_Sede_Agregar";
        const string C_ELIMINAR = "USP_Sede_Eliminar";


        public SedeDTO ListarPorClave(int id)
        {
            SedeDTO obj = new SedeDTO();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_BUSCAR_POR_CLAVE);
            db.AddInParameter(dbCommand, "@CodigoSede", DbType.Int32, id);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    obj.CodigoSede = (int)dr["CodigoSede"];

                    if (dr["Nombre"] != System.DBNull.Value)
                        obj.Nombre = (string)dr["Nombre"];

                    if (dr["Estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["Estado"];

                }
            }
            return obj;
        }
        public List<SedeDTO> Listar()
        {
            List<SedeDTO> Lista = new List<SedeDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    SedeDTO obj = new SedeDTO();
                    if (dr["CodigoSede"] != System.DBNull.Value)
                        obj.CodigoSede = (int)dr["CodigoSede"];
                    if (dr["Nombre"] != System.DBNull.Value)
                        obj.Nombre = (string)dr["Nombre"];
                    if (dr["Estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["Estado"];
                    Lista.Add(obj);
                }
            }
            return Lista;
        }

        public int Agregar(SedeDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
            db.AddInParameter(dbCommand, "@Nombre", DbType.String, obj.Nombre);
            db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return id;
        }

        public void Actualizar(SedeDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
            db.AddInParameter(dbCommand, "@CodigoSede", DbType.Int32, obj.CodigoSede);
            db.AddInParameter(dbCommand, "@Nombre", DbType.String, obj.Nombre);
            db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Eliminar(string CodigoSede)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
            db.AddInParameter(dbCommand, "@CodigoSede", DbType.Int32, CodigoSede);
            db.ExecuteNonQuery(dbCommand);
        }

    }
}

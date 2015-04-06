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
    public class CargoDAO
    {
        const string C_BUSCAR_POR_CLAVE = "SELECT CodigoCargo, Nombre, estado " +
                                "FROM Cargo " +
                                "WHERE CodigoCargo = @CodigoCargo";
        const string C_LISTAR = "USP_Cargo_Listar";
        const string C_ACTUALIZAR = "USP_Cargo_Actualizar";
        const string C_AGREGAR = "USP_Cargo_Agregar";
        const string C_ELIMINAR = "USP_Cargo_Eliminar";

        public CargoDTO ListarPorClave(int id)
        {
            CargoDTO obj = new CargoDTO();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_BUSCAR_POR_CLAVE);
            db.AddInParameter(dbCommand, "@CodigoCargo", DbType.Int32, id);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    obj.CodigoCargo = (int)dr["CodigoCargo"];

                    if (dr["Nombre"] != System.DBNull.Value)
                        obj.Nombre = (string)dr["Nombre"];

                    if (dr["Estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["Estado"];

                }
            }
            return obj;
        }

        public List<CargoDTO> Listar()
        {
            List<CargoDTO> Lista = new List<CargoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_LISTAR);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    CargoDTO obj = new CargoDTO();
                    if (dr["CodigoCargo"] != System.DBNull.Value)
                        obj.CodigoCargo = (int)dr["CodigoCargo"];
                    if (dr["Nombre"] != System.DBNull.Value)
                        obj.Nombre = (string)dr["Nombre"];
                    if (dr["Estado"] != System.DBNull.Value)
                        obj.Estado = (string)dr["Estado"];
                    Lista.Add(obj);
                }
            }
            return Lista;
        }

        public int Agregar(CargoDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
            db.AddInParameter(dbCommand, "@Nombre", DbType.String, obj.Nombre);
            db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
            int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return id;
        }

        public void Actualizar(CargoDTO obj)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
            db.AddInParameter(dbCommand, "@CodigoCargo", DbType.Int32, obj.CodigoCargo);
            db.AddInParameter(dbCommand, "@Nombre", DbType.String, obj.Nombre);
            db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Eliminar(string CodigoCargo)
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
            db.AddInParameter(dbCommand, "@CodigoCargo", DbType.Int32, CodigoCargo);
            db.ExecuteNonQuery(dbCommand);
        }

    }
}

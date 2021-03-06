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
    public class FormatoDAO
    {
        const string C_BUSCAR_POR_CLAVE = "SELECT IdFormato, Titulo " +
                                "FROM SEIS_DATA.dbo.Formato " +
                                "WHERE IdFormato = @IdFormato";
        const string C_LISTAR_POR_PROYECTO = "SPS_FORMATO_PROYECTO";
        const string C_LISTAR_TODOS = "USP_Formato_ListarTodos";
        const string C_LISTAR_POR_NOMBRE = "USP_Formato_ListarPorNombre";
        public FormatoDTO ListarPorClave(string IdFormato)
        {
            FormatoDTO obj = new FormatoDTO();
            Database db = DatabaseFactory.CreateDatabase("eConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(C_BUSCAR_POR_CLAVE);
            db.AddInParameter(dbCommand, "@IdFormato", DbType.Int32, IdFormato);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    obj.IdFormato = (string)dr["IdFormato"];

                    if (dr["Titulo"] != System.DBNull.Value)
                        obj.Titulo = (string)dr["Titulo"];

                }
            }
            return obj;
        }

        public List<FormatoDTO> ListarPorProyecto(int CodigoProyecto)
        {
            Guid newGuid = Guid.NewGuid(); 
            List<FormatoDTO> Lista = new List<FormatoDTO>();
            Database db = DatabaseFactory.CreateDatabase("eConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_PROYECTO);
            db.AddInParameter(dbCommand, "@CodigoProyecto", DbType.Int32, CodigoProyecto);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    FormatoDTO obj = new FormatoDTO();

                    if (dr["IdFormato"] != System.DBNull.Value)
                    {
                        newGuid = (Guid)dr["IdFormato"];
                        obj.IdFormato = newGuid.ToString();
                    }else{
                        obj.IdFormato = "";
                    }
                    if (dr["Titulo"] != System.DBNull.Value)
                        obj.Titulo = (string)dr["Titulo"];
                    Lista.Add(obj);
                }
            }
            return Lista;
        }

        public List<FormatoDTO> ListarTodos()
        {
            Guid newGuid = Guid.NewGuid(); 
            List<FormatoDTO> Lista = new List<FormatoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_TODOS);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    FormatoDTO obj = new FormatoDTO();

                    if (dr["IdFormato"] != System.DBNull.Value)
                    {
                        newGuid = (Guid)dr["IdFormato"];
                        obj.IdFormato = newGuid.ToString();
                    }
                    else
                    {
                        obj.IdFormato = "";
                    }

                    if (dr["Titulo"] != System.DBNull.Value)
                        obj.Titulo = (string)dr["Titulo"];
                    Lista.Add(obj);
                }
            }
            return Lista;
        }
        public List<FormatoDTO> ListarPorNombre(string Nombre)
        {
            Guid newGuid = Guid.NewGuid(); 
            List<FormatoDTO> Lista = new List<FormatoDTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_NOMBRE);
            db.AddInParameter(dbCommand, "@Nombre", DbType.String, Nombre);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    FormatoDTO obj = new FormatoDTO();

                    if (dr["IdFormato"] != System.DBNull.Value)
                    {
                        newGuid = (Guid)dr["IdFormato"];
                        obj.IdFormato = newGuid.ToString();
                    }else{
                        obj.IdFormato = "";
                    }
                    if (dr["Titulo"] != System.DBNull.Value)
                        obj.Titulo = (string)dr["Titulo"];
                    Lista.Add(obj);
                }
            }
            return Lista;
        }


    }
}

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
    public class Formato6DAO
    {
        const string C_LISTAR_POR_CODIGO = "USP_Formato_ListarPorCodigo";
        const string C_BUSCAR_POR_CLAVE = "USP_Formato_BuscarPorClave";

        public List<Formato6DTO> ListarPorCodigo(string CodigoEmpleado)
        {
            Guid newGuid = Guid.NewGuid();
            List<Formato6DTO> Lista = new List<Formato6DTO>();
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CODIGO);
            db.AddInParameter(dbCommand, "@codigo", DbType.String, CodigoEmpleado);
            //db.AddInParameter(dbCommand, "@FechaD", DbType.DateTime, FechaD);
            //db.AddInParameter(dbCommand, "@FechaD", DbType.DateTime, FechaD);
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    Formato6DTO obj = new Formato6DTO();

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
                        obj.Titulo = (string) dr["Titulo"];

                    if (dr["IdCabecera"] != System.DBNull.Value)
                        obj.IdCabecera = (int) dr["IdCabecera"];

                    if (dr["CodigoUsuario"] != System.DBNull.Value)
                        obj.CodigoUsuario = (string)dr["CodigoUsuario"]; // "00000"; 

                    if (dr["FechaRegistro"] != System.DBNull.Value)
                        obj.FechaRegistro = (DateTime) dr["FechaRegistro"];

                    Lista.Add(obj);
                    
                }
            }
            return Lista;
        }
        public Formato6DTO BuscarPorClave(int IdCabecera)
        {
            Guid newGuid = Guid.NewGuid();
            Formato6DTO obj = null;
            Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand(C_BUSCAR_POR_CLAVE);
            db.AddInParameter(dbCommand, "@IdCabecera", DbType.Int32, IdCabecera);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {

                    obj = new Formato6DTO();

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

                    if (dr["IdCabecera"] != System.DBNull.Value)
                        obj.IdCabecera = (int)dr["IdCabecera"];

                    if (dr["CodigoUsuario"] != System.DBNull.Value)
                        obj.CodigoUsuario = (string)dr["CodigoUsuario"]; // "00000"; 

                    if (dr["FechaRegistro"] != System.DBNull.Value)
                        obj.FechaRegistro = (DateTime)dr["FechaRegistro"];

                }
            }
            return obj;
        }
    }
}

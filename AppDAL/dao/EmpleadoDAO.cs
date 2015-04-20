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
  public class EmpleadoDAO
  {

      const string C_LISTAR = "USP_Empleado_Listar";
      const string C_ACTUALIZAR = "USP_Empleado_Actualizar";
      const string C_AGREGAR = "USP_Empleado_Agregar";
      const string C_ELIMINAR = "USP_Empleado_Eliminar";
      const string C_LISTAR_POR_CLAVE = "USP_Empleado_ListarPorClave";
      const string C_LISTAR_BUSQUEDA = "USP_Empleado_Busqueda";
      const string C_LISTAR_BUSQUEDA_POR_JEFE = "USP_Empleado_BusquedaPorJefe";

      public List<EmpleadoDTO> Listar()
      {
          List<EmpleadoDTO> Lista = new List<EmpleadoDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR);
          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              while (dr.Read())
              {
                  EmpleadoDTO obj = new EmpleadoDTO();
                  if (dr["IdEmpleado"] != System.DBNull.Value)
                      obj.IdEmpleado = (int)dr["IdEmpleado"];
                  if (dr["CodigoEmpleado"] != System.DBNull.Value)
                      obj.CodigoEmpleado = (string)dr["CodigoEmpleado"];
                  if (dr["DocumentoIdentidad"] != System.DBNull.Value)
                      obj.DocumentoIdentidad = (string)dr["DocumentoIdentidad"];
                  if (dr["Nombre"] != System.DBNull.Value)
                      obj.Nombre = (string)dr["Nombre"];
                  if (dr["CodigoCargo"] != System.DBNull.Value)
                      obj.CodigoCargo = (int)dr["CodigoCargo"];
                  if (dr["Fiscalizado"] != System.DBNull.Value)
                      obj.Fiscalizado = (string)dr["Fiscalizado"];
                  if (dr["CodigoPuesto"] != System.DBNull.Value)
                      obj.CodigoPuesto = (int)dr["CodigoPuesto"];
                  if (dr["GradoPuesto"] != System.DBNull.Value)
                      obj.GradoPuesto = (int)dr["GradoPuesto"];
                  if (dr["CodigoArea"] != System.DBNull.Value)
                      obj.CodigoArea = (int)dr["CodigoArea"];
                  if (dr["CodigoUnidad"] != System.DBNull.Value)
                      obj.CodigoUnidad = (int)dr["CodigoUnidad"];
                  if (dr["FechaIngreso"] != System.DBNull.Value)
                      obj.FechaIngreso = (DateTime)dr["FechaIngreso"];
                  if (dr["CodigoJefe"] != System.DBNull.Value)
                      obj.CodigoJefe = (int)dr["CodigoJefe"];
                  if (dr["CodigoSede"] != System.DBNull.Value)
                      obj.CodigoSede = (int)dr["CodigoSede"];
                  if (dr["Estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["Estado"];
                  if (dr["Puesto"] != System.DBNull.Value)
                      obj.Puesto = (string)dr["Puesto"];
                  if (dr["Grado"] != System.DBNull.Value)
                      obj.Grado = (string)dr["Grado"];
                  if (dr["Unidad"] != System.DBNull.Value)
                      obj.Unidad = (string)dr["Unidad"];
                  if (dr["Sede"] != System.DBNull.Value)
                      obj.Sede = (string)dr["Sede"];

				   Lista.Add(obj);

              }
          }
          return Lista;
      }

	  public EmpleadoDTO ListarPorClave(int IdEmpleado)
      {
          List<EmpleadoDTO> Lista = new List<EmpleadoDTO>();
          EmpleadoDTO obj = null;
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_POR_CLAVE);
          db.AddInParameter(dbCommand, "@IdEmpleado", DbType.Int32, IdEmpleado);

          using (IDataReader dr = db.ExecuteReader(dbCommand)) 
          {
              if (dr.Read())
              {
                  obj = new EmpleadoDTO();

                  if (dr["IdEmpleado"] != System.DBNull.Value)
                      obj.IdEmpleado = (int)dr["IdEmpleado"];
                  if (dr["CodigoEmpleado"] != System.DBNull.Value)
                      obj.CodigoEmpleado = (string)dr["CodigoEmpleado"];
                  if (dr["DocumentoIdentidad"] != System.DBNull.Value)
                      obj.DocumentoIdentidad = (string)dr["DocumentoIdentidad"];
                  if (dr["Nombre"] != System.DBNull.Value)
                      obj.Nombre = (string)dr["Nombre"];
                  if (dr["CodigoCargo"] != System.DBNull.Value)
                      obj.CodigoCargo = (int)dr["CodigoCargo"];
                  if (dr["Fiscalizado"] != System.DBNull.Value)
                      obj.Fiscalizado = (string)dr["Fiscalizado"];
                  if (dr["CodigoPuesto"] != System.DBNull.Value)
                      obj.CodigoPuesto = (int)dr["CodigoPuesto"];
                  if (dr["GradoPuesto"] != System.DBNull.Value)
                      obj.GradoPuesto = (int)dr["GradoPuesto"];
                  if (dr["CodigoArea"] != System.DBNull.Value)
                      obj.CodigoArea = (int)dr["CodigoArea"];
                  if (dr["CodigoUnidad"] != System.DBNull.Value)
                      obj.CodigoUnidad = (int)dr["CodigoUnidad"];
                  if (dr["FechaIngreso"] != System.DBNull.Value)
                      obj.FechaIngreso = (DateTime)dr["FechaIngreso"];
                  if (dr["CodigoJefe"] != System.DBNull.Value)
                      obj.CodigoJefe = (int)dr["CodigoJefe"];
                  if (dr["CodigoSede"] != System.DBNull.Value)
                      obj.CodigoSede = (int)dr["CodigoSede"];
                  if (dr["Estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["Estado"];
                  if (dr["Puesto"] != System.DBNull.Value)
                      obj.Puesto = (string)dr["Puesto"];
                  if (dr["Grado"] != System.DBNull.Value)
                      obj.Grado = (string)dr["Grado"];
                  if (dr["Unidad"] != System.DBNull.Value)
                      obj.Unidad = (string)dr["Unidad"];
                  if (dr["Sede"] != System.DBNull.Value)
                      obj.Sede = (string)dr["Sede"];
                  if (dr["IdFormato"] != System.DBNull.Value)
                      {
                          obj.IdFormato = (string)dr["IdFormato"];
                      }
                      else
                      {
                          obj.IdFormato = "";
                      };
              }
          }
          return obj;
      }

      public List<EmpleadoDTO> ListarBusquedaPorJefe(int CodigoJefe)
      {
          List<EmpleadoDTO> Lista = new List<EmpleadoDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_BUSQUEDA_POR_JEFE);
          db.AddInParameter(dbCommand, "@CodigoJefe", DbType.Int32, CodigoJefe);

          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  EmpleadoDTO obj = new EmpleadoDTO();

                  if (dr["IdEmpleado"] != System.DBNull.Value)
                      obj.IdEmpleado = (int)dr["IdEmpleado"];
                  if (dr["CodigoEmpleado"] != System.DBNull.Value)
                      obj.CodigoEmpleado = (string)dr["CodigoEmpleado"];
                  if (dr["DocumentoIdentidad"] != System.DBNull.Value)
                      obj.DocumentoIdentidad = (string)dr["DocumentoIdentidad"];
                  if (dr["Nombre"] != System.DBNull.Value)
                      obj.Nombre = (string)dr["Nombre"];
                  if (dr["CodigoCargo"] != System.DBNull.Value)
                      obj.CodigoCargo = (int)dr["CodigoCargo"];
                  if (dr["Fiscalizado"] != System.DBNull.Value)
                      obj.Fiscalizado = (string)dr["Fiscalizado"];
                  if (dr["CodigoPuesto"] != System.DBNull.Value)
                      obj.CodigoPuesto = (int)dr["CodigoPuesto"];
                  if (dr["GradoPuesto"] != System.DBNull.Value)
                      obj.GradoPuesto = (int)dr["GradoPuesto"];
                  if (dr["CodigoArea"] != System.DBNull.Value)
                      obj.CodigoArea = (int)dr["CodigoArea"];
                  if (dr["CodigoUnidad"] != System.DBNull.Value)
                      obj.CodigoUnidad = (int)dr["CodigoUnidad"];
                  if (dr["FechaIngreso"] != System.DBNull.Value)
                      obj.FechaIngreso = (DateTime)dr["FechaIngreso"];
                  if (dr["CodigoJefe"] != System.DBNull.Value)
                      obj.CodigoJefe = (int)dr["CodigoJefe"];
                  if (dr["CodigoSede"] != System.DBNull.Value)
                      obj.CodigoSede = (int)dr["CodigoSede"];
                  if (dr["Estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["Estado"];
                  if (dr["Puesto"] != System.DBNull.Value)
                      obj.Puesto = (string)dr["Puesto"];
                  if (dr["Grado"] != System.DBNull.Value)
                      obj.Grado = (string)dr["Grado"];
                  if (dr["Unidad"] != System.DBNull.Value)
                      obj.Unidad = (string)dr["Unidad"];
                  if (dr["Sede"] != System.DBNull.Value)
                      obj.Sede = (string)dr["Sede"];


                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public List<EmpleadoDTO> ListarBusqueda(string Nombre)
      {
          List<EmpleadoDTO> Lista = new List<EmpleadoDTO>();
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_LISTAR_BUSQUEDA);
          db.AddInParameter(dbCommand, "@Nombre", DbType.String, Nombre);
          using (IDataReader dr = db.ExecuteReader(dbCommand))
          {
              while (dr.Read())
              {
                  EmpleadoDTO obj = new EmpleadoDTO();

                  if (dr["IdEmpleado"] != System.DBNull.Value)
                      obj.IdEmpleado = (int)dr["IdEmpleado"];
                  if (dr["CodigoEmpleado"] != System.DBNull.Value)
                      obj.CodigoEmpleado = (string)dr["CodigoEmpleado"];
                  if (dr["DocumentoIdentidad"] != System.DBNull.Value)
                      obj.DocumentoIdentidad = (string)dr["DocumentoIdentidad"];
                  if (dr["Nombre"] != System.DBNull.Value)
                      obj.Nombre = (string)dr["Nombre"];
                  if (dr["CodigoCargo"] != System.DBNull.Value)
                      obj.CodigoCargo = (int)dr["CodigoCargo"];
                  if (dr["Fiscalizado"] != System.DBNull.Value)
                      obj.Fiscalizado = (string)dr["Fiscalizado"];
                  if (dr["CodigoPuesto"] != System.DBNull.Value)
                      obj.CodigoPuesto = (int)dr["CodigoPuesto"];
                  if (dr["GradoPuesto"] != System.DBNull.Value)
                      obj.GradoPuesto = (int)dr["GradoPuesto"];
                  if (dr["CodigoArea"] != System.DBNull.Value)
                      obj.CodigoArea = (int)dr["CodigoArea"];
                  if (dr["CodigoUnidad"] != System.DBNull.Value)
                      obj.CodigoUnidad = (int)dr["CodigoUnidad"];
                  if (dr["FechaIngreso"] != System.DBNull.Value)
                      obj.FechaIngreso = (DateTime)dr["FechaIngreso"];
                  if (dr["CodigoJefe"] != System.DBNull.Value)
                      obj.CodigoJefe = (int)dr["CodigoJefe"];
                  if (dr["CodigoSede"] != System.DBNull.Value)
                      obj.CodigoSede = (int)dr["CodigoSede"];
                  if (dr["Estado"] != System.DBNull.Value)
                      obj.Estado = (string)dr["Estado"];
                  if (dr["Puesto"] != System.DBNull.Value)
                      obj.Puesto = (string)dr["Puesto"];
                  if (dr["Grado"] != System.DBNull.Value)
                      obj.Grado = (string)dr["Grado"];
                  if (dr["Unidad"] != System.DBNull.Value)
                      obj.Unidad = (string)dr["Unidad"];
                  if (dr["Sede"] != System.DBNull.Value)
                      obj.Sede = (string)dr["Sede"];
                  
                  Lista.Add(obj);
              }
          }
          return Lista;
      }

      public int Agregar(EmpleadoDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_AGREGAR);
          //db.AddInParameter(dbCommand, "@id_Empleado", DbType.Int32, obj.IdEmpleado);
          db.AddInParameter(dbCommand, "@CodigoEmpleado", DbType.String, obj.CodigoEmpleado);
          db.AddInParameter(dbCommand, "@DocumentoIdentidad", DbType.String, obj.DocumentoIdentidad);
          db.AddInParameter(dbCommand, "@Nombre", DbType.String, obj.Nombre);
          db.AddInParameter(dbCommand, "@CodigoCargo", DbType.Int32, obj.CodigoCargo);
          db.AddInParameter(dbCommand, "@Fiscalizado", DbType.String, obj.Fiscalizado);
          db.AddInParameter(dbCommand, "@CodigoPuesto", DbType.Int32, obj.CodigoPuesto);
          db.AddInParameter(dbCommand, "@GradoPuesto", DbType.Int32, obj.GradoPuesto);
          db.AddInParameter(dbCommand, "@CodigoArea", DbType.Int32, obj.CodigoArea);
          db.AddInParameter(dbCommand, "@CodigoUnidad", DbType.Int32, obj.CodigoUnidad);
          db.AddInParameter(dbCommand, "@FechaIngreso", DbType.DateTime, GetFechaValida(obj.FechaIngreso));
          db.AddInParameter(dbCommand, "@CodigoJefe", DbType.String, obj.CodigoJefe);
          db.AddInParameter(dbCommand, "@CodigoSede", DbType.Int32, obj.CodigoSede); 
          db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
          db.AddInParameter(dbCommand, "@usuario_creacion", DbType.Int32, obj.Usuario_creacion);

          
          int id = Convert.ToInt32(db.ExecuteScalar(dbCommand));
          return id;
      }

      public void Actualizar(EmpleadoDTO obj)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ACTUALIZAR);
          db.AddInParameter(dbCommand, "@IdEmpleado", DbType.Int32, obj.IdEmpleado);
          db.AddInParameter(dbCommand, "@CodigoEmpleado", DbType.String, obj.CodigoEmpleado);
          db.AddInParameter(dbCommand, "@DocumentoIdentidad", DbType.String, obj.DocumentoIdentidad);
          db.AddInParameter(dbCommand, "@Nombre", DbType.String, obj.Nombre);
          db.AddInParameter(dbCommand, "@CodigoCargo", DbType.Int32, obj.CodigoCargo);
          db.AddInParameter(dbCommand, "@Fiscalizado", DbType.String, obj.Fiscalizado);
          db.AddInParameter(dbCommand, "@CodigoPuesto", DbType.Int32, obj.CodigoPuesto);
          db.AddInParameter(dbCommand, "@GradoPuesto", DbType.Int32, obj.GradoPuesto);
          db.AddInParameter(dbCommand, "@CodigoArea", DbType.Int32, obj.CodigoArea);
          db.AddInParameter(dbCommand, "@CodigoUnidad", DbType.Int32, obj.CodigoUnidad);
          db.AddInParameter(dbCommand, "@FechaIngreso", DbType.DateTime, obj.FechaIngreso);
          db.AddInParameter(dbCommand, "@CodigoJefe", DbType.String, obj.CodigoJefe);
          db.AddInParameter(dbCommand, "@CodigoSede", DbType.Int32, obj.CodigoSede);
          db.AddInParameter(dbCommand, "@Estado", DbType.String, obj.Estado);
          db.AddInParameter(dbCommand, "@usuario_modificacion", DbType.Int32, obj.Usuario_modificacion);


          db.ExecuteNonQuery(dbCommand);
      }

      public void Eliminar(int IdEmpleado)
      {
          Database db = DatabaseFactory.CreateDatabase("ApplicationConnectionString");
          DbCommand dbCommand = db.GetStoredProcCommand(C_ELIMINAR);
          db.AddInParameter(dbCommand, "@IdEmpleado", DbType.Int32, IdEmpleado);
          db.ExecuteNonQuery(dbCommand);
      }

      protected object GetFechaValida(DateTime fecha)
      {
          if (fecha.Year == 1)
              return null;
          else
              return fecha;
      } 
  }
}

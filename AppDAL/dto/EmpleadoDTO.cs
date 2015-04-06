using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class EmpleadoDTO
  {

      //Propiedades
      private int _IdEmpleado;
      private string _CodigoEmpleado;
      private string _DocumentoIdentidad;
      private string _Nombre;
      private int _CodigoCargo;
      private string _Fiscalizado;
      private int _CodigoPuesto;
      private int _GradoPuesto;
      private int _CodigoArea;
      private int _CodigoUnidad;
      private DateTime _FechaIngreso;
      private int _CodigoJefe;
      private int _CodigoSede;
      private string _Estado;
      private DateTime _fecha_creacion;
      private int _usuario_creacion;
      private DateTime _fecha_modificacion;
      private int _usuario_modificacion;
      private string _Puesto;
      private string _Grado;
      private string _Unidad;
      private string _Sede;


 

      public EmpleadoDTO() { }

      public EmpleadoDTO(
           int _IdEmpleado,
           string _CodigoEmpleado,
           string _DocumentoIdentidad,
           string _Nombre,
           int _CodigoCargo,
           string _Fiscalizado,
           int _CodigoPuesto,
           string _Puesto,
           int _GradoPuesto,
           string _Grado,
           int _CodigoArea,
           string _Unidad,
           int _CodigoUnidad,
           DateTime _FechaIngreso,
           int _CodigoJefe,
           int _CodigoSede,
           string _Sede,
           string _Estado,
           DateTime _fecha_creacion,
           int _usuario_creacion,
           DateTime _fecha_modificacion,
           int _usuario_modificacion)
      {
          this._IdEmpleado = _IdEmpleado;
          this._CodigoEmpleado = _CodigoEmpleado;
          this._DocumentoIdentidad = _DocumentoIdentidad;
          this._Nombre = _Nombre;
          this._CodigoCargo = _CodigoCargo;
          this._Fiscalizado = _Fiscalizado;
          this._CodigoPuesto = _CodigoPuesto;
          this._Puesto = _Puesto;
          this._GradoPuesto = _GradoPuesto;
          this._Grado = _Grado;
          this._CodigoArea = _CodigoArea;
          this._CodigoUnidad = _CodigoUnidad;
          this._Unidad = _Unidad;
          this._FechaIngreso = _FechaIngreso;
          this._CodigoJefe = _CodigoJefe;
          this._CodigoSede = _CodigoSede;
          this._Sede = _Sede;
          this._Estado = _Estado;
          this._fecha_creacion = _fecha_creacion;
          this._usuario_creacion = _usuario_creacion;
          this._fecha_modificacion = _fecha_modificacion;
          this._usuario_modificacion = _usuario_modificacion;
      }


      public int IdEmpleado
      {
          get { return _IdEmpleado; }
          set { _IdEmpleado = value; }
      }

      public string CodigoEmpleado
      {
          get { return _CodigoEmpleado; }
          set { _CodigoEmpleado = value; }
      }


      public string DocumentoIdentidad
      {
          get { return _DocumentoIdentidad; }
          set { _DocumentoIdentidad = value; }
      }


      public string Nombre
      {
          get { return _Nombre; }
          set { _Nombre = value; }
      }


      public int CodigoCargo
      {
          get { return _CodigoCargo; }
          set { _CodigoCargo = value; }
      }


      public string Fiscalizado
      {
          get { return _Fiscalizado; }
          set { _Fiscalizado = value; }
      }


      public int CodigoPuesto
      {
          get { return _CodigoPuesto; }
          set { _CodigoPuesto = value; }
      }


      public int GradoPuesto
      {
          get { return _GradoPuesto; }
          set { _GradoPuesto = value; }
      }


      public int CodigoArea
      {
          get { return _CodigoArea; }
          set { _CodigoArea = value; }
      }
      

      public int CodigoUnidad
      {
          get { return _CodigoUnidad; }
          set { _CodigoUnidad = value; }
      }
      

      public DateTime FechaIngreso
      {
          get { return _FechaIngreso; }
          set { _FechaIngreso = value; }
      }
      

      public int CodigoJefe
      {
          get { return _CodigoJefe; }
          set { _CodigoJefe = value; }
      }
      

      public int CodigoSede
      {
          get { return _CodigoSede; }
          set { _CodigoSede = value; }
      }
      

      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
      }
      

      public DateTime Fecha_creacion
      {
          get { return _fecha_creacion; }
          set { _fecha_creacion = value; }
      }
      

      public int Usuario_creacion
      {
          get { return _usuario_creacion; }
          set { _usuario_creacion = value; }
      }
      

      public DateTime Fecha_modificacion
      {
          get { return _fecha_modificacion; }
          set { _fecha_modificacion = value; }
      }
      

      public int Usuario_modificacion
      {
          get { return _usuario_modificacion; }
          set { _usuario_modificacion = value; }
      }


      public Boolean EstadoBool
      {
          get
          {
              if (_Estado == "1")
                  return true;
              else
                  return false;
          }
      }
      public Boolean FiscalizadoBool
      {
          get
          {
              if (_Fiscalizado == "1")
                  return true;
              else
                  return false;
          }
      }
      public string Puesto
      {
          get { return _Puesto; }
          set { _Puesto = value; }
      }


      public string Grado
      {
          get { return _Grado; }
          set { _Grado = value; }
      }


      public string Unidad
      {
          get { return _Unidad; }
          set { _Unidad = value; }
      }


      public string Sede
      {
          get { return _Sede; }
          set { _Sede = value; }
      }
      //Constructor


  }
}

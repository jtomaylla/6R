using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class UnidadDTO
  {

      //Propiedades
      private int _CodigoUnidad;
      private string _Nombre;
      private string _Estado;

      //Constructor

      public UnidadDTO() { }

      public UnidadDTO(int _CodigoUnidad, string _Nombre, string _Estado)
      {
          this._CodigoUnidad = _CodigoUnidad;
          this._Nombre = _Nombre;
          this._Estado = _Estado;
      }

      //Get y Set
      public int CodigoUnidad
      {
          get { return _CodigoUnidad; }
          set { _CodigoUnidad = value; }
      }
      public string Nombre
      {
          get { return _Nombre; }
          set { _Nombre = value; }
      }
      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
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
  }
}

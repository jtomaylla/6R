using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class SedeDTO
  {

      //Propiedades
      private int _CodigoSede;
      private string _Nombre;
      private string _Estado;

      //Constructor

      public SedeDTO() { }

      public SedeDTO(int _CodigoSede, string _Nombre, string _Estado)
      {
          this._CodigoSede = _CodigoSede;
          this._Nombre = _Nombre;
          this._Estado = _Estado;
      }

      //Get y Set
      public int CodigoSede
      {
          get { return _CodigoSede; }
          set { _CodigoSede = value; }
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

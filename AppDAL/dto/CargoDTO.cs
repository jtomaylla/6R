using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class CargoDTO
  {

      //Propiedades
      private int _CodigoCargo;
      private string _Nombre;
      private string _Estado;

      //Constructor

      public CargoDTO() { }

      public CargoDTO(int _CodigoCargo, string _Nombre, string _Estado)
      {
          this._CodigoCargo = _CodigoCargo;
          this._Nombre = _Nombre;
          this._Estado = _Estado;
      }

      //Get y Set
      public int CodigoCargo
      {
          get { return _CodigoCargo; }
          set { _CodigoCargo = value; }
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

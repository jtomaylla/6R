using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class GradoDTO
  {

      //Propiedades
      private int _CodigoGrado;
      private string _Nombre;
      private string _Estado;

      //Constructor

      public GradoDTO() { }

      public GradoDTO(int _CodigoGrado, string _Nombre, string _Estado)
      {
          this._CodigoGrado = _CodigoGrado;
          this._Nombre = _Nombre;
          this._Estado = _Estado;
      }

      //Get y Set
      public int CodigoGrado
      {
          get { return _CodigoGrado; }
          set { _CodigoGrado = value; }
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

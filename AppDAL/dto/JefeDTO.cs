using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class JefeDTO
  {

      //Propiedades
      private int _CodigoJefe;
      private string _Nombre;
      private string _Estado;

      //Constructor

      public JefeDTO() { }

      public JefeDTO(int _CodigoJefe, string _Nombre, string _Estado)
      {
          this._CodigoJefe = _CodigoJefe;
          this._Nombre = _Nombre;
          this._Estado = _Estado;
      }

      //Get y Set
      public int CodigoJefe
      {
          get { return _CodigoJefe; }
          set { _CodigoJefe = value; }
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
  }
}

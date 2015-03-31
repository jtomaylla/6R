using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class AreaDTO
  {

      //Propiedades
      private int _CodigoArea;
      private string _Nombre;
      private string _Estado;

      //Constructor

      public AreaDTO() { }

      public AreaDTO(int _CodigoArea, string _Nombre, string _Estado )
      {
          this._CodigoArea = _CodigoArea;
          this._Nombre = _Nombre;
          this._Estado = _Estado;
      }

      //Get y Set
      public int CodigoArea
      {
          get { return _CodigoArea; }
          set { _CodigoArea = value; }
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

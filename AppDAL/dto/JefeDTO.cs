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
      private int _id_usuario;

      //Constructor

      public JefeDTO() { }

      public JefeDTO(int _CodigoJefe, string _Nombre, string _Estado,
           int _id_usuario)
      {
          this._CodigoJefe = _CodigoJefe;
          this._Nombre = _Nombre;
          this._Estado = _Estado;
          this._id_usuario = _id_usuario;
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

      public int Id_usuario
      {
          get { return _id_usuario; }
          set { _id_usuario = value; }
      }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class PuestoDTO
  {

      //Propiedades
      private int _CodigoPuesto;
      private string _Nombre;
      private string _Estado;
      private string _IdFormato;

      //Constructor

      public PuestoDTO() { }

      public PuestoDTO(int _CodigoPuesto, string _Nombre, string _Estado, string _IdFormato)
      {
          this._CodigoPuesto = _CodigoPuesto;
          this._Nombre = _Nombre;
          this._Estado = _Estado;
          this._IdFormato = _IdFormato;
      }

      //Get y Set
      public int CodigoPuesto
      {
          get { return _CodigoPuesto; }
          set { _CodigoPuesto = value; }
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

      public string IdFormato
      {
          get { return _IdFormato; }
          set { _IdFormato = value; }
      }
  }
}

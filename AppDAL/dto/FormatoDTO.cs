using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class FormatoDTO
  {

      //Propiedades
      private string _IdFormato;
      private string _Titulo;


      //Constructor

      public FormatoDTO() { }

      public FormatoDTO(
          string _IdFormato, 
          string _Titulo
          )
      {

          this._IdFormato = _IdFormato;
          this._Titulo = _Titulo;
      }

      //Get y Set

      public string IdFormato
      {
          get { return _IdFormato; }
          set { _IdFormato = value; }
      }
      public string Titulo
      {
          get { return _Titulo; }
          set { _Titulo = value; }
      }
      
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class Formato6DTO
  {

      //Propiedades
      private string _IdFormato;
      private string _Titulo;
      private string _Codigo;
      private int _IdCabecera;
      private DateTime _FechaRegistro;
      private string _CodigoUsuario;
      private string _NombreUsuario;


      //Constructor

      public Formato6DTO() { }

      public Formato6DTO(
          string _IdFormato, 
          string _Titulo,
          string _Codigo,
          int _IdCabecera,
          DateTime _FechaRegistro,
          string _CodigoUsuario,
          string _NombreUsuario
          )
      {

          this._IdFormato = _IdFormato;
          this._Titulo = _Titulo;
          this._Codigo = _Codigo;
          this._IdCabecera = _IdCabecera;
          this._FechaRegistro = _FechaRegistro;
          this._CodigoUsuario = _CodigoUsuario;
          this._NombreUsuario = _NombreUsuario;
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
      public string Codigo
      {
          get { return _Codigo; }
          set { _Codigo = value; }
      }
      public int IdCabecera
      {
          get { return _IdCabecera; }
          set { _IdCabecera = value; }
      }


      public DateTime FechaRegistro
      {
          get { return _FechaRegistro; }
          set { _FechaRegistro = value; }
      }


      public string CodigoUsuario
      {
          get { return _CodigoUsuario; }
          set { _CodigoUsuario = value; }
      }

      public string NombreUsuario
      {
          get { return _NombreUsuario; }
          set { _NombreUsuario = value; }
      }
  }
}

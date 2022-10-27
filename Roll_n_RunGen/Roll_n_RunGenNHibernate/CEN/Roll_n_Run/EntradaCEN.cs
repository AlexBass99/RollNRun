

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Roll_n_RunGenNHibernate.Exceptions;

using Roll_n_RunGenNHibernate.EN.Roll_n_Run;
using Roll_n_RunGenNHibernate.CAD.Roll_n_Run;


namespace Roll_n_RunGenNHibernate.CEN.Roll_n_Run
{
/*
 *      Definition of the class EntradaCEN
 *
 */
public partial class EntradaCEN
{
private IEntradaCAD _IEntradaCAD;

public EntradaCEN()
{
        this._IEntradaCAD = new EntradaCAD ();
}

public EntradaCEN(IEntradaCAD _IEntradaCAD)
{
        this._IEntradaCAD = _IEntradaCAD;
}

public IEntradaCAD get_IEntradaCAD ()
{
        return this._IEntradaCAD;
}

public int New_ (int p_subforo, int p_usuario, string p_texto)
{
        EntradaEN entradaEN = null;
        int oid;

        //Initialized EntradaEN
        entradaEN = new EntradaEN ();

        if (p_subforo != -1) {
                // El argumento p_subforo -> Property subforo es oid = false
                // Lista de oids id
                entradaEN.Subforo = new Roll_n_RunGenNHibernate.EN.Roll_n_Run.SubforoEN ();
                entradaEN.Subforo.Id = p_subforo;
        }


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                entradaEN.Usuario = new Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN ();
                entradaEN.Usuario.Id = p_usuario;
        }

        entradaEN.Texto = p_texto;

        //Call to EntradaCAD

        oid = _IEntradaCAD.New_ (entradaEN);
        return oid;
}

public void Modify (int p_Entrada_OID, string p_texto)
{
        EntradaEN entradaEN = null;

        //Initialized EntradaEN
        entradaEN = new EntradaEN ();
        entradaEN.Id = p_Entrada_OID;
        entradaEN.Texto = p_texto;
        //Call to EntradaCAD

        _IEntradaCAD.Modify (entradaEN);
}

public void Destroy (int id
                     )
{
        _IEntradaCAD.Destroy (id);
}

public EntradaEN ReadOID (int id
                          )
{
        EntradaEN entradaEN = null;

        entradaEN = _IEntradaCAD.ReadOID (id);
        return entradaEN;
}

public System.Collections.Generic.IList<EntradaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EntradaEN> list = null;

        list = _IEntradaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.EntradaEN> GetEntradasSubforo (int ? p_subforo)
{
        return _IEntradaCAD.GetEntradasSubforo (p_subforo);
}
}
}

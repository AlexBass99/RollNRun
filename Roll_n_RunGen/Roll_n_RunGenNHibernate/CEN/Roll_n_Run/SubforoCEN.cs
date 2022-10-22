

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
 *      Definition of the class SubforoCEN
 *
 */
public partial class SubforoCEN
{
private ISubforoCAD _ISubforoCAD;

public SubforoCEN()
{
        this._ISubforoCAD = new SubforoCAD ();
}

public SubforoCEN(ISubforoCAD _ISubforoCAD)
{
        this._ISubforoCAD = _ISubforoCAD;
}

public ISubforoCAD get_ISubforoCAD ()
{
        return this._ISubforoCAD;
}

public int New_ (int p_autor, string p_titulo, Nullable<DateTime> p_fecha, string p_descripcion, int p_numComentarios)
{
        SubforoEN subforoEN = null;
        int oid;

        //Initialized SubforoEN
        subforoEN = new SubforoEN ();

        if (p_autor != -1) {
                // El argumento p_autor -> Property autor es oid = false
                // Lista de oids id
                subforoEN.Autor = new Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN ();
                subforoEN.Autor.Id = p_autor;
        }

        subforoEN.Titulo = p_titulo;

        subforoEN.Fecha = p_fecha;

        subforoEN.Descripcion = p_descripcion;

        subforoEN.NumComentarios = p_numComentarios;

        //Call to SubforoCAD

        oid = _ISubforoCAD.New_ (subforoEN);
        return oid;
}

public void Modify (int p_Subforo_OID, string p_titulo, Nullable<DateTime> p_fecha, string p_descripcion, int p_numComentarios)
{
        SubforoEN subforoEN = null;

        //Initialized SubforoEN
        subforoEN = new SubforoEN ();
        subforoEN.Id = p_Subforo_OID;
        subforoEN.Titulo = p_titulo;
        subforoEN.Fecha = p_fecha;
        subforoEN.Descripcion = p_descripcion;
        subforoEN.NumComentarios = p_numComentarios;
        //Call to SubforoCAD

        _ISubforoCAD.Modify (subforoEN);
}

public void Destroy (int id
                     )
{
        _ISubforoCAD.Destroy (id);
}

public SubforoEN ReadOID (int id
                          )
{
        SubforoEN subforoEN = null;

        subforoEN = _ISubforoCAD.ReadOID (id);
        return subforoEN;
}

public System.Collections.Generic.IList<SubforoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SubforoEN> list = null;

        list = _ISubforoCAD.ReadAll (first, size);
        return list;
}
}
}

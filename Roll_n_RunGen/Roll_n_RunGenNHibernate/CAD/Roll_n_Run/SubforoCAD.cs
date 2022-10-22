
using System;
using System.Text;
using Roll_n_RunGenNHibernate.CEN.Roll_n_Run;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Roll_n_RunGenNHibernate.EN.Roll_n_Run;
using Roll_n_RunGenNHibernate.Exceptions;


/*
 * Clase Subforo:
 *
 */

namespace Roll_n_RunGenNHibernate.CAD.Roll_n_Run
{
public partial class SubforoCAD : BasicCAD, ISubforoCAD
{
public SubforoCAD() : base ()
{
}

public SubforoCAD(ISession sessionAux) : base (sessionAux)
{
}



public SubforoEN ReadOIDDefault (int id
                                 )
{
        SubforoEN subforoEN = null;

        try
        {
                SessionInitializeTransaction ();
                subforoEN = (SubforoEN)session.Get (typeof(SubforoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Roll_n_RunGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Roll_n_RunGenNHibernate.Exceptions.DataLayerException ("Error in SubforoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return subforoEN;
}

public System.Collections.Generic.IList<SubforoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SubforoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SubforoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<SubforoEN>();
                        else
                                result = session.CreateCriteria (typeof(SubforoEN)).List<SubforoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Roll_n_RunGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Roll_n_RunGenNHibernate.Exceptions.DataLayerException ("Error in SubforoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (SubforoEN subforo)
{
        try
        {
                SessionInitializeTransaction ();
                SubforoEN subforoEN = (SubforoEN)session.Load (typeof(SubforoEN), subforo.Id);


                subforoEN.Titulo = subforo.Titulo;


                subforoEN.Fecha = subforo.Fecha;


                subforoEN.Descripcion = subforo.Descripcion;



                subforoEN.NumComentarios = subforo.NumComentarios;


                session.Update (subforoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Roll_n_RunGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Roll_n_RunGenNHibernate.Exceptions.DataLayerException ("Error in SubforoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (SubforoEN subforo)
{
        try
        {
                SessionInitializeTransaction ();
                if (subforo.Autor != null) {
                        // Argumento OID y no colección.
                        subforo.Autor = (Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN)session.Load (typeof(Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN), subforo.Autor.Id);

                        subforo.Autor.Subforo_autor
                        .Add (subforo);
                }

                session.Save (subforo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Roll_n_RunGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Roll_n_RunGenNHibernate.Exceptions.DataLayerException ("Error in SubforoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return subforo.Id;
}

public void Modify (SubforoEN subforo)
{
        try
        {
                SessionInitializeTransaction ();
                SubforoEN subforoEN = (SubforoEN)session.Load (typeof(SubforoEN), subforo.Id);

                subforoEN.Titulo = subforo.Titulo;


                subforoEN.Fecha = subforo.Fecha;


                subforoEN.Descripcion = subforo.Descripcion;


                subforoEN.NumComentarios = subforo.NumComentarios;

                session.Update (subforoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Roll_n_RunGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Roll_n_RunGenNHibernate.Exceptions.DataLayerException ("Error in SubforoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                SubforoEN subforoEN = (SubforoEN)session.Load (typeof(SubforoEN), id);
                session.Delete (subforoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Roll_n_RunGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Roll_n_RunGenNHibernate.Exceptions.DataLayerException ("Error in SubforoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: SubforoEN
public SubforoEN ReadOID (int id
                          )
{
        SubforoEN subforoEN = null;

        try
        {
                SessionInitializeTransaction ();
                subforoEN = (SubforoEN)session.Get (typeof(SubforoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Roll_n_RunGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Roll_n_RunGenNHibernate.Exceptions.DataLayerException ("Error in SubforoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return subforoEN;
}

public System.Collections.Generic.IList<SubforoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SubforoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SubforoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<SubforoEN>();
                else
                        result = session.CreateCriteria (typeof(SubforoEN)).List<SubforoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Roll_n_RunGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Roll_n_RunGenNHibernate.Exceptions.DataLayerException ("Error in SubforoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}

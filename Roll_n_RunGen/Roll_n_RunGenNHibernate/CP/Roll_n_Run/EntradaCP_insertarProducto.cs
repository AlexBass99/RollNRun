
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using Roll_n_RunGenNHibernate.EN.Roll_n_Run;
using Roll_n_RunGenNHibernate.CAD.Roll_n_Run;
using Roll_n_RunGenNHibernate.CEN.Roll_n_Run;



/*PROTECTED REGION ID(usingRoll_n_RunGenNHibernate.CP.Roll_n_Run_Entrada_insertarProducto) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Roll_n_RunGenNHibernate.CP.Roll_n_Run
{
public partial class EntradaCP : BasicCP
{
public void InsertarProducto (int p_oid)
{
        /*PROTECTED REGION ID(Roll_n_RunGenNHibernate.CP.Roll_n_Run_Entrada_insertarProducto) ENABLED START*/

        IEntradaCAD entradaCAD = null;
        EntradaCEN entradaCEN = null;



        try
        {
                SessionInitializeTransaction ();
                entradaCAD = new EntradaCAD (session);
                entradaCEN = new  EntradaCEN (entradaCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method InsertarProducto() not yet implemented.");



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}

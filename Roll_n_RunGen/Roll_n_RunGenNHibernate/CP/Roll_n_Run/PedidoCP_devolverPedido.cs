
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



/*PROTECTED REGION ID(usingRoll_n_RunGenNHibernate.CP.Roll_n_Run_Pedido_devolverPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Roll_n_RunGenNHibernate.CP.Roll_n_Run
{
public partial class PedidoCP : BasicCP
{
public void DevolverPedido (int p_oid)
{
        /*PROTECTED REGION ID(Roll_n_RunGenNHibernate.CP.Roll_n_Run_Pedido_devolverPedido) ENABLED START*/

        IPedidoCAD pedidoCAD = null;
        PedidoCEN pedidoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                pedidoCAD = new PedidoCAD (session);
                pedidoCEN = new  PedidoCEN (pedidoCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method DevolverPedido() not yet implemented.");



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

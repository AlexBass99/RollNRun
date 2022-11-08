
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



/*PROTECTED REGION ID(usingRoll_n_RunGenNHibernate.CP.Roll_n_Run_LineaPedido_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Roll_n_RunGenNHibernate.CP.Roll_n_Run
{
public partial class LineaPedidoCP : BasicCP
{
public void Destroy (int p_LineaPedido_OID)
{
        /*PROTECTED REGION ID(Roll_n_RunGenNHibernate.CP.Roll_n_Run_LineaPedido_destroy) ENABLED START*/

        ILineaPedidoCAD lineaPedidoCAD = null;
        LineaPedidoCEN lineaPedidoCEN = null;
        PedidoCAD pedidoCAD = null;
        PedidoCEN pedidoCEN = null;

        pedidoCAD = new PedidoCAD(session);
        pedidoCEN = new PedidoCEN(pedidoCAD);


        try
        {
                SessionInitializeTransaction ();
                lineaPedidoCAD = new LineaPedidoCAD (session);
                lineaPedidoCEN = new  LineaPedidoCEN (lineaPedidoCAD);
                LineaPedidoEN lineaPedidoEN = lineaPedidoCEN.ReadOID(p_LineaPedido_OID); 

                PedidoEN pedidoEN = pedidoCEN.ReadOID(lineaPedidoEN.Pedido.Id);
                pedidoEN.Precio -= lineaPedidoEN.Precio * lineaPedidoEN.Cantidad;
                pedidoCAD.ModifyDefault(pedidoEN);

                lineaPedidoCAD.Destroy (p_LineaPedido_OID);

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
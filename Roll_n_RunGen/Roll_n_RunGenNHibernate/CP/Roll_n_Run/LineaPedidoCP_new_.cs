
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



/*PROTECTED REGION ID(usingRoll_n_RunGenNHibernate.CP.Roll_n_Run_LineaPedido_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Roll_n_RunGenNHibernate.CP.Roll_n_Run
{
public partial class LineaPedidoCP : BasicCP
{
public Roll_n_RunGenNHibernate.EN.Roll_n_Run.LineaPedidoEN New_ (int p_cantidad, double p_precio, int p_pedido, int p_producto)
{
        /*PROTECTED REGION ID(Roll_n_RunGenNHibernate.CP.Roll_n_Run_LineaPedido_new_) ENABLED START*/

        ILineaPedidoCAD lineaPedidoCAD = null;
        LineaPedidoCEN lineaPedidoCEN = null;
        PedidoCAD pedidoCAD = null;
        PedidoCEN pedidoCEN = null;

        pedidoCAD = new PedidoCAD (session);
        pedidoCEN = new PedidoCEN (pedidoCAD);
        Roll_n_RunGenNHibernate.EN.Roll_n_Run.LineaPedidoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                lineaPedidoCAD = new LineaPedidoCAD (session);
                lineaPedidoCEN = new LineaPedidoCEN (lineaPedidoCAD);

                int oid;
                //Initialized LineaPedidoEN
                LineaPedidoEN lineaPedidoEN;
                lineaPedidoEN = new LineaPedidoEN ();
                lineaPedidoEN.Cantidad = p_cantidad;

                lineaPedidoEN.Precio = p_precio;


                if (p_pedido != -1) {
                        lineaPedidoEN.Pedido = new Roll_n_RunGenNHibernate.EN.Roll_n_Run.PedidoEN ();
                        lineaPedidoEN.Pedido.Id = p_pedido;
                }


                if (p_producto != -1) {
                        lineaPedidoEN.Producto = new Roll_n_RunGenNHibernate.EN.Roll_n_Run.ProductoEN ();
                        lineaPedidoEN.Producto.Id = p_producto;
                }

                //Call to LineaPedidoCAD

                oid = lineaPedidoCAD.New_ (lineaPedidoEN);

                PedidoEN pedidoEN = pedidoCEN.ReadOID (lineaPedidoEN.Pedido.Id);
                pedidoEN.Cantidad += lineaPedidoEN.Cantidad;
                pedidoEN.Total += lineaPedidoEN.Precio * lineaPedidoEN.Cantidad;
                pedidoCAD.ModifyDefault (pedidoEN);

                result = lineaPedidoCAD.ReadOIDDefault (oid);

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
        return result;


        /*PROTECTED REGION END*/
}
}
}

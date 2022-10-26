
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Roll_n_RunGenNHibernate.Exceptions;
using Roll_n_RunGenNHibernate.EN.Roll_n_Run;
using Roll_n_RunGenNHibernate.CAD.Roll_n_Run;


/*PROTECTED REGION ID(usingRoll_n_RunGenNHibernate.CEN.Roll_n_Run_Pedido_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Roll_n_RunGenNHibernate.CEN.Roll_n_Run
{
public partial class PedidoCEN
{
public int New_ (Nullable<DateTime> p_fecha, string p_direccion, double p_precio, int p_cantidad, int p_usuario)
{
        /*PROTECTED REGION ID(Roll_n_RunGenNHibernate.CEN.Roll_n_Run_Pedido_new__customized) START*/

        PedidoEN pedidoEN = null;

        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Fecha = p_fecha;

        pedidoEN.Direccion = p_direccion;

        pedidoEN.Precio = p_precio;

        pedidoEN.Cantidad = p_cantidad;

        


        if (p_usuario != -1) {
                pedidoEN.Usuario = new Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN ();
                pedidoEN.Usuario.Id = p_usuario;
        }

        pedidoEN.Estado = Enumerated.Roll_n_Run.EstadoEnum.enCarrito;
        pedidoEN.MetodoPago = Enumerated.Roll_n_Run.PagoEnum.tarjeta;

        //Call to PedidoCAD

        oid = _IPedidoCAD.New_ (pedidoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}

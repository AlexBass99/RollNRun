

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
 *      Definition of the class FacturaCEN
 *
 */
public partial class FacturaCEN
{
private IFacturaCAD _IFacturaCAD;

public FacturaCEN()
{
        this._IFacturaCAD = new FacturaCAD ();
}

public FacturaCEN(IFacturaCAD _IFacturaCAD)
{
        this._IFacturaCAD = _IFacturaCAD;
}

public IFacturaCAD get_IFacturaCAD ()
{
        return this._IFacturaCAD;
}

public int New_ (Nullable<DateTime> p_fecha, string p_direccion, double p_precio, Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.PagoEnum p_metodoPago, int p_pedido)
{
        FacturaEN facturaEN = null;
        int oid;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();
        facturaEN.Fecha = p_fecha;

        facturaEN.Direccion = p_direccion;

        facturaEN.Precio = p_precio;

        facturaEN.MetodoPago = p_metodoPago;


        if (p_pedido != -1) {
                // El argumento p_pedido -> Property pedido es oid = false
                // Lista de oids id
                facturaEN.Pedido = new Roll_n_RunGenNHibernate.EN.Roll_n_Run.PedidoEN ();
                facturaEN.Pedido.Id = p_pedido;
        }

        //Call to FacturaCAD

        oid = _IFacturaCAD.New_ (facturaEN);
        return oid;
}

public void Modify (int p_Factura_OID, Nullable<DateTime> p_fecha, string p_direccion, double p_precio, Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.PagoEnum p_metodoPago)
{
        FacturaEN facturaEN = null;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();
        facturaEN.Id = p_Factura_OID;
        facturaEN.Fecha = p_fecha;
        facturaEN.Direccion = p_direccion;
        facturaEN.Precio = p_precio;
        facturaEN.MetodoPago = p_metodoPago;
        //Call to FacturaCAD

        _IFacturaCAD.Modify (facturaEN);
}

public void Destroy (int id
                     )
{
        _IFacturaCAD.Destroy (id);
}

public FacturaEN ReadOID (int id
                          )
{
        FacturaEN facturaEN = null;

        facturaEN = _IFacturaCAD.ReadOID (id);
        return facturaEN;
}

public System.Collections.Generic.IList<FacturaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<FacturaEN> list = null;

        list = _IFacturaCAD.ReadAll (first, size);
        return list;
}
}
}

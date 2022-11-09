
using System;
// Definición clase PedidoEN
namespace Roll_n_RunGenNHibernate.EN.Roll_n_Run
{
public partial class PedidoEN
{
/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo total
 */
private double total;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo metodoPago
 */
private Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.PagoEnum metodoPago;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo estado
 */
private Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.EstadoEnum estado;



/**
 *	Atributo usuario
 */
private Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN usuario;



/**
 *	Atributo factura
 */
private Roll_n_RunGenNHibernate.EN.Roll_n_Run.FacturaEN factura;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.LineaPedidoEN> lineaPedido;



/**
 *	Atributo devolucion
 */
private System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.DevolucionEN> devolucion;






public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual double Total {
        get { return total; } set { total = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.PagoEnum MetodoPago {
        get { return metodoPago; } set { metodoPago = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.EstadoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual Roll_n_RunGenNHibernate.EN.Roll_n_Run.FacturaEN Factura {
        get { return factura; } set { factura = value;  }
}



public virtual System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.DevolucionEN> Devolucion {
        get { return devolucion; } set { devolucion = value;  }
}





public PedidoEN()
{
        lineaPedido = new System.Collections.Generic.List<Roll_n_RunGenNHibernate.EN.Roll_n_Run.LineaPedidoEN>();
        devolucion = new System.Collections.Generic.List<Roll_n_RunGenNHibernate.EN.Roll_n_Run.DevolucionEN>();
}



public PedidoEN(int id, Nullable<DateTime> fecha, string direccion, double total, int cantidad, Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.PagoEnum metodoPago, Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.EstadoEnum estado, Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN usuario, Roll_n_RunGenNHibernate.EN.Roll_n_Run.FacturaEN factura, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.DevolucionEN> devolucion
                )
{
        this.init (Id, fecha, direccion, total, cantidad, metodoPago, estado, usuario, factura, lineaPedido, devolucion);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (Id, pedido.Fecha, pedido.Direccion, pedido.Total, pedido.Cantidad, pedido.MetodoPago, pedido.Estado, pedido.Usuario, pedido.Factura, pedido.LineaPedido, pedido.Devolucion);
}

private void init (int id
                   , Nullable<DateTime> fecha, string direccion, double total, int cantidad, Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.PagoEnum metodoPago, Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.EstadoEnum estado, Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN usuario, Roll_n_RunGenNHibernate.EN.Roll_n_Run.FacturaEN factura, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.DevolucionEN> devolucion)
{
        this.Id = id;


        this.Fecha = fecha;

        this.Direccion = direccion;

        this.Total = total;

        this.Cantidad = cantidad;

        this.MetodoPago = metodoPago;

        this.Estado = estado;

        this.Usuario = usuario;

        this.Factura = factura;

        this.LineaPedido = lineaPedido;

        this.Devolucion = devolucion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}

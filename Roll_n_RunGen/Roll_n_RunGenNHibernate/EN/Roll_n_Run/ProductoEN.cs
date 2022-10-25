
using System;
// Definición clase ProductoEN
namespace Roll_n_RunGenNHibernate.EN.Roll_n_Run
{
public partial class ProductoEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo marca
 */
private string marca;



/**
 *	Atributo stock
 */
private int stock;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo lineaPedido
 */
private Roll_n_RunGenNHibernate.EN.Roll_n_Run.LineaPedidoEN lineaPedido;



/**
 *	Atributo valoracion
 */
private System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ValoracionEN> valoracion;



/**
 *	Atributo val_media
 */
private double val_media;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN> usuario;



/**
 *	Atributo tipo
 */
private Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.Tipo_productoEnum tipo;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ComentarioEN> comentario;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Marca {
        get { return marca; } set { marca = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Roll_n_RunGenNHibernate.EN.Roll_n_Run.LineaPedidoEN LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ValoracionEN> Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual double Val_media {
        get { return val_media; } set { val_media = value;  }
}



public virtual System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.Tipo_productoEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}





public ProductoEN()
{
        valoracion = new System.Collections.Generic.List<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ValoracionEN>();
        usuario = new System.Collections.Generic.List<Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN>();
        comentario = new System.Collections.Generic.List<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ComentarioEN>();
}



public ProductoEN(int id, string nombre, string marca, int stock, double precio, string imagen, string descripcion, Roll_n_RunGenNHibernate.EN.Roll_n_Run.LineaPedidoEN lineaPedido, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ValoracionEN> valoracion, double val_media, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN> usuario, Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.Tipo_productoEnum tipo, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ComentarioEN> comentario
                  )
{
        this.init (Id, nombre, marca, stock, precio, imagen, descripcion, lineaPedido, valoracion, val_media, usuario, tipo, comentario);
}


public ProductoEN(ProductoEN producto)
{
        this.init (Id, producto.Nombre, producto.Marca, producto.Stock, producto.Precio, producto.Imagen, producto.Descripcion, producto.LineaPedido, producto.Valoracion, producto.Val_media, producto.Usuario, producto.Tipo, producto.Comentario);
}

private void init (int id
                   , string nombre, string marca, int stock, double precio, string imagen, string descripcion, Roll_n_RunGenNHibernate.EN.Roll_n_Run.LineaPedidoEN lineaPedido, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ValoracionEN> valoracion, double val_media, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN> usuario, Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.Tipo_productoEnum tipo, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ComentarioEN> comentario)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Marca = marca;

        this.Stock = stock;

        this.Precio = precio;

        this.Imagen = imagen;

        this.Descripcion = descripcion;

        this.LineaPedido = lineaPedido;

        this.Valoracion = valoracion;

        this.Val_media = val_media;

        this.Usuario = usuario;

        this.Tipo = tipo;

        this.Comentario = comentario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProductoEN t = obj as ProductoEN;
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

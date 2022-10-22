
using System;
// Definición clase UsuarioEN
namespace Roll_n_RunGenNHibernate.EN.Roll_n_Run
{
public partial class UsuarioEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo nickname
 */
private string nickname;



/**
 *	Atributo telefono
 */
private int telefono;



/**
 *	Atributo tarjeta
 */
private System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.TarjetaEN> tarjeta;



/**
 *	Atributo direccion
 */
private System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.DireccionEN> direccion;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.PedidoEN> pedido;



/**
 *	Atributo valoracion
 */
private System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ValoracionEN> valoracion;



/**
 *	Atributo subforo_autor
 */
private System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.SubforoEN> subforo_autor;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ComentarioEN> comentario;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo productos_deseados
 */
private System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ProductoEN> productos_deseados;



/**
 *	Atributo subforo
 */
private System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.SubforoEN> subforo;



/**
 *	Atributo rol
 */
private Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.RolEnum rol;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string Nickname {
        get { return nickname; } set { nickname = value;  }
}



public virtual int Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.TarjetaEN> Tarjeta {
        get { return tarjeta; } set { tarjeta = value;  }
}



public virtual System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.DireccionEN> Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ValoracionEN> Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.SubforoEN> Subforo_autor {
        get { return subforo_autor; } set { subforo_autor = value;  }
}



public virtual System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ProductoEN> Productos_deseados {
        get { return productos_deseados; } set { productos_deseados = value;  }
}



public virtual System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.SubforoEN> Subforo {
        get { return subforo; } set { subforo = value;  }
}



public virtual Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.RolEnum Rol {
        get { return rol; } set { rol = value;  }
}





public UsuarioEN()
{
        tarjeta = new System.Collections.Generic.List<Roll_n_RunGenNHibernate.EN.Roll_n_Run.TarjetaEN>();
        direccion = new System.Collections.Generic.List<Roll_n_RunGenNHibernate.EN.Roll_n_Run.DireccionEN>();
        pedido = new System.Collections.Generic.List<Roll_n_RunGenNHibernate.EN.Roll_n_Run.PedidoEN>();
        valoracion = new System.Collections.Generic.List<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ValoracionEN>();
        subforo_autor = new System.Collections.Generic.List<Roll_n_RunGenNHibernate.EN.Roll_n_Run.SubforoEN>();
        comentario = new System.Collections.Generic.List<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ComentarioEN>();
        productos_deseados = new System.Collections.Generic.List<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ProductoEN>();
        subforo = new System.Collections.Generic.List<Roll_n_RunGenNHibernate.EN.Roll_n_Run.SubforoEN>();
}



public UsuarioEN(int id, string nombre, string email, string apellidos, string nickname, int telefono, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.TarjetaEN> tarjeta, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.DireccionEN> direccion, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.PedidoEN> pedido, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ValoracionEN> valoracion, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.SubforoEN> subforo_autor, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ComentarioEN> comentario, String pass, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ProductoEN> productos_deseados, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.SubforoEN> subforo, Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.RolEnum rol
                 )
{
        this.init (Id, nombre, email, apellidos, nickname, telefono, tarjeta, direccion, pedido, valoracion, subforo_autor, comentario, pass, productos_deseados, subforo, rol);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Id, usuario.Nombre, usuario.Email, usuario.Apellidos, usuario.Nickname, usuario.Telefono, usuario.Tarjeta, usuario.Direccion, usuario.Pedido, usuario.Valoracion, usuario.Subforo_autor, usuario.Comentario, usuario.Pass, usuario.Productos_deseados, usuario.Subforo, usuario.Rol);
}

private void init (int id
                   , string nombre, string email, string apellidos, string nickname, int telefono, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.TarjetaEN> tarjeta, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.DireccionEN> direccion, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.PedidoEN> pedido, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ValoracionEN> valoracion, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.SubforoEN> subforo_autor, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ComentarioEN> comentario, String pass, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ProductoEN> productos_deseados, System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.SubforoEN> subforo, Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.RolEnum rol)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Email = email;

        this.Apellidos = apellidos;

        this.Nickname = nickname;

        this.Telefono = telefono;

        this.Tarjeta = tarjeta;

        this.Direccion = direccion;

        this.Pedido = pedido;

        this.Valoracion = valoracion;

        this.Subforo_autor = subforo_autor;

        this.Comentario = comentario;

        this.Pass = pass;

        this.Productos_deseados = productos_deseados;

        this.Subforo = subforo;

        this.Rol = rol;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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

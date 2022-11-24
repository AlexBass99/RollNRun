
using System;
// Definición clase TarjetaEN
namespace Roll_n_RunGenNHibernate.EN.Roll_n_Run
{
public partial class TarjetaEN
{
/**
 *	Atributo titular
 */
private string titular;



/**
 *	Atributo numero
 */
private string numero;



/**
 *	Atributo cvv
 */
private string cvv;



/**
 *	Atributo fechaCad
 */
private Nullable<DateTime> fechaCad;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN usuario;






public virtual string Titular {
        get { return titular; } set { titular = value;  }
}



public virtual string Numero {
        get { return numero; } set { numero = value;  }
}



public virtual string Cvv {
        get { return cvv; } set { cvv = value;  }
}



public virtual Nullable<DateTime> FechaCad {
        get { return fechaCad; } set { fechaCad = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public TarjetaEN()
{
}



public TarjetaEN(int id, string titular, string numero, string cvv, Nullable<DateTime> fechaCad, Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN usuario
                 )
{
        this.init (Id, titular, numero, cvv, fechaCad, usuario);
}


public TarjetaEN(TarjetaEN tarjeta)
{
        this.init (Id, tarjeta.Titular, tarjeta.Numero, tarjeta.Cvv, tarjeta.FechaCad, tarjeta.Usuario);
}

private void init (int id
                   , string titular, string numero, string cvv, Nullable<DateTime> fechaCad, Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN usuario)
{
        this.Id = id;


        this.Titular = titular;

        this.Numero = numero;

        this.Cvv = cvv;

        this.FechaCad = fechaCad;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TarjetaEN t = obj as TarjetaEN;
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


using System;
// Definición clase DireccionEN
namespace Roll_n_RunGenNHibernate.EN.Roll_n_Run
{
public partial class DireccionEN
{
/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo localidad
 */
private string localidad;



/**
 *	Atributo cp
 */
private string cp;



/**
 *	Atributo calle
 */
private string calle;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN usuario;






public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual string Localidad {
        get { return localidad; } set { localidad = value;  }
}



public virtual string Cp {
        get { return cp; } set { cp = value;  }
}



public virtual string Calle {
        get { return calle; } set { calle = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public DireccionEN()
{
}



public DireccionEN(int id, string provincia, string localidad, string cp, string calle, Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN usuario
                   )
{
        this.init (Id, provincia, localidad, cp, calle, usuario);
}


public DireccionEN(DireccionEN direccion)
{
        this.init (Id, direccion.Provincia, direccion.Localidad, direccion.Cp, direccion.Calle, direccion.Usuario);
}

private void init (int id
                   , string provincia, string localidad, string cp, string calle, Roll_n_RunGenNHibernate.EN.Roll_n_Run.UsuarioEN usuario)
{
        this.Id = id;


        this.Provincia = provincia;

        this.Localidad = localidad;

        this.Cp = cp;

        this.Calle = calle;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DireccionEN t = obj as DireccionEN;
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


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


/*PROTECTED REGION ID(usingRoll_n_RunGenNHibernate.CEN.Roll_n_Run_Producto_sumarStock) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Roll_n_RunGenNHibernate.CEN.Roll_n_Run
{
public partial class ProductoCEN
{
public void SumarStock (int p_oid, int p_cantidad)
{
        /*PROTECTED REGION ID(Roll_n_RunGenNHibernate.CEN.Roll_n_Run_Producto_sumarStock) ENABLED START*/

        ProductoEN productoEN = new ProductoEN ();
        ProductoCEN productoCEN = new ProductoCEN ();

        productoEN = productoCEN.ReadOID (p_oid);
        if (p_cantidad > 0) {
                productoEN.Stock = productoEN.Stock + p_cantidad;
                //se avisa de que se ha sumado el stock
        }
        else{
                //se avisa de que no se ha podido sumar el stock
        }

        // Write here your custom code...

        throw new NotImplementedException ("Method SumarStock() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}



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
 *      Definition of the class ProductoCEN
 *
 */
public partial class ProductoCEN
{
private IProductoCAD _IProductoCAD;

public ProductoCEN()
{
        this._IProductoCAD = new ProductoCAD ();
}

public ProductoCEN(IProductoCAD _IProductoCAD)
{
        this._IProductoCAD = _IProductoCAD;
}

public IProductoCAD get_IProductoCAD ()
{
        return this._IProductoCAD;
}

public int New_ (string p_nombre, string p_marca, int p_stock, double p_precio, string p_imagen, string p_descripcion, double p_val_media, Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.Tipo_productoEnum p_tipo)
{
        ProductoEN productoEN = null;
        int oid;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Nombre = p_nombre;

        productoEN.Marca = p_marca;

        productoEN.Stock = p_stock;

        productoEN.Precio = p_precio;

        productoEN.Imagen = p_imagen;

        productoEN.Descripcion = p_descripcion;

        productoEN.Val_media = p_val_media;

        productoEN.Tipo = p_tipo;

        //Call to ProductoCAD

        oid = _IProductoCAD.New_ (productoEN);
        return oid;
}

public void Modify (int p_Producto_OID, string p_nombre, string p_marca, int p_stock, double p_precio, string p_imagen, string p_descripcion, double p_val_media, Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run.Tipo_productoEnum p_tipo)
{
        ProductoEN productoEN = null;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Id = p_Producto_OID;
        productoEN.Nombre = p_nombre;
        productoEN.Marca = p_marca;
        productoEN.Stock = p_stock;
        productoEN.Precio = p_precio;
        productoEN.Imagen = p_imagen;
        productoEN.Descripcion = p_descripcion;
        productoEN.Val_media = p_val_media;
        productoEN.Tipo = p_tipo;
        //Call to ProductoCAD

        _IProductoCAD.Modify (productoEN);
}

public void Destroy (int id
                     )
{
        _IProductoCAD.Destroy (id);
}

public ProductoEN ReadOID (int id
                           )
{
        ProductoEN productoEN = null;

        productoEN = _IProductoCAD.ReadOID (id);
        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> list = null;

        list = _IProductoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ProductoEN> BuscarPrecio ()
{
        return _IProductoCAD.BuscarPrecio ();
}
public System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ProductoEN> BuscarNombre ()
{
        return _IProductoCAD.BuscarNombre ();
}
public System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ProductoEN> BuscarTipo ()
{
        return _IProductoCAD.BuscarTipo ();
}
public System.Collections.Generic.IList<Roll_n_RunGenNHibernate.EN.Roll_n_Run.ProductoEN> GetProductosDeseadosUsuario ()
{
        return _IProductoCAD.GetProductosDeseadosUsuario ();
}
}
}

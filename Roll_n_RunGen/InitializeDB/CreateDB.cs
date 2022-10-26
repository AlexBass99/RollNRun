
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Roll_n_RunGenNHibernate.EN.Roll_n_Run;
using Roll_n_RunGenNHibernate.CEN.Roll_n_Run;
using Roll_n_RunGenNHibernate.CAD.Roll_n_Run;
using Roll_n_RunGenNHibernate.Enumerated.Roll_n_Run;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes

                //USUARIOS
                UsuarioCEN usuarioCEN = new UsuarioCEN ();
                int id_usu = usuarioCEN.New_ (p_nombre: "Yo", p_email: "yo@gmail.com", p_apellidos: "Yomismo", p_nickname: "Mimismo1", p_pass: "1234", p_rol: RolEnum.usuario_base);
                int id_usu2 = usuarioCEN.New_ (p_nombre: "Tu", p_email: "tu@gmail.com", p_apellidos: "Tumismo", p_nickname: "Mimismo2", p_pass: "1234", p_rol: RolEnum.administrador);
                int id_usu3 = usuarioCEN.New_ (p_nombre: "El", p_email: "el@gmail.com", p_apellidos: "Elmismo", p_nickname: "Mimismo3", p_pass: "1234", p_rol: RolEnum.usuario_base);
                int id_usu4 = usuarioCEN.New_ (p_nombre: "Nosotros", p_email: "nosotros@gmail.com", p_apellidos: "Nosotrosmismos", p_nickname: "Mimismo4", p_pass: "1234", p_rol: RolEnum.administrador);
                int id_usu5 = usuarioCEN.New_ (p_nombre: "Vosotros", p_email: "vosotros@gmail.com", p_apellidos: "Vosotrosmismos", p_nickname: "Mimismo5", p_pass: "1234", p_rol: RolEnum.usuario_base);

                //LOGIN usuario
                if (usuarioCEN.Login (id_usu, "1234") != null) {
                        Console.WriteLine ("El Login es correcto");
                        Console.WriteLine ();
                }

                //TARJETAS
                TarjetaCEN tarjetaCEN = new TarjetaCEN ();
                tarjetaCEN.New_ ("Yo Yomismo", "12341234", 123, new DateTime (2023, 1, 1), id_usu);
                tarjetaCEN.New_ ("Tu Tumismo", "12341234", 123, new DateTime (2023, 1, 2), id_usu2);
                tarjetaCEN.New_ ("El Elmismo", "12341234", 123, new DateTime (2023, 1, 3), id_usu3);
                tarjetaCEN.New_ ("Nosotros Nosotrosmismos", "12341234", 123, new DateTime (2023, 1, 4), id_usu4);
                tarjetaCEN.New_ ("Vosotros Vosotrosmismos", "12341234", 123, new DateTime (2023, 1, 5), id_usu5);

                //DIRECCIONES
                DireccionCEN direccionCEN = new DireccionCEN ();
                direccionCEN.New_ ("Alicante", "Alcoy", "03803", "Odio existir", id_usu);
                direccionCEN.New_ ("Alicante", "Elche", "03205", "Tampoco es para tanto", id_usu2);
                direccionCEN.New_ ("Alicante", "Alicante", "03103", "Que si que si", id_usu3);
                direccionCEN.New_ ("Alicante", "Elda", "03603", "Va alegrate", id_usu4);
                direccionCEN.New_ ("Alicante", "Petrer", "03608", "Es verdad tienes razon", id_usu5);

                //PRODUCTOS
                ProductoCEN productoCEN = new ProductoCEN ();
                int id_producto = productoCEN.New_ ("Dados d6", "Marca Blanca", 270, 2.99, "Imagen", "Chulisimos dados de seis caras", 0, Tipo_productoEnum.dado);
                int id_producto2 = productoCEN.New_ ("Figura", "Marca 1", 300, 20.99, "Imagen", "Figura de tus personajes favoritos", 0, Tipo_productoEnum.figura);
                int id_producto3 = productoCEN.New_ ("Juego de Cartas", "Marca 2", 305, 25.99, "Imagen", "El nuevo juego de cartas de Marca 2", 0, Tipo_productoEnum.juego_cartas);
                int id_producto4 = productoCEN.New_ ("Juego de Mesa", "Marca 3", 400, 42.99, "Imagen", "Preparate para noches divertidas con tus amigos", 0, Tipo_productoEnum.juego_mesa);
                int id_producto5 = productoCEN.New_ ("Manual D&D", "Marca 4", 403, 32.99, "Imagen", "Manual del Dungeon Master D&D 5E", 0, Tipo_productoEnum.libro);
                int id_producto6 = productoCEN.New_ ("Colmillos Vampiro", "Marca 5", 600, 1.99, "Imagen", "Colmillos falsos de vampiro", 0, Tipo_productoEnum.otros);

                //PEDIDOS
                PedidoCEN pedidoCEN = new PedidoCEN ();
                int id_pedido = pedidoCEN.New_ (new DateTime (2023, 1, 1), "Sigo igual", 30, 1, PagoEnum.paypal, EstadoEnum.enProceso, id_usu);
                int id_pedido2 = pedidoCEN.New_ (new DateTime (2023, 1, 2), "Calle Falsa 123", 30, 1, PagoEnum.tarjeta, EstadoEnum.enProceso, id_usu);
                int id_pedido3 = pedidoCEN.New_ (new DateTime (2023, 1, 3), "Calle Real 321", 30, 1, PagoEnum.tarjeta, EstadoEnum.enProceso, id_usu);
                int id_pedido4 = pedidoCEN.New_ (new DateTime (2023, 1, 4), "IES Carrus", 30, 1, PagoEnum.paypal, EstadoEnum.enProceso, id_usu);
                int id_pedido5 = pedidoCEN.New_ (new DateTime (2023, 1, 5), "No se donde estoy", 30, 1, PagoEnum.tarjeta, EstadoEnum.enProceso, id_usu);
                int id_pedido6 = pedidoCEN.New_ (new DateTime (2023, 1, 6), "Sigo andando", 30, 1, PagoEnum.tarjeta, EstadoEnum.enProceso, id_usu);

                //LINEAS DE PEDIDO
                LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN ();
                lineaPedidoCEN.New_ (3, 30, id_pedido, id_producto);
                lineaPedidoCEN.New_ (2, 20, id_pedido2, id_producto2);
                lineaPedidoCEN.New_ (5, 10, id_pedido3, id_producto3);
                lineaPedidoCEN.New_ (1, 50, id_pedido4, id_producto4);
                lineaPedidoCEN.New_ (2, 20, id_pedido5, id_producto5);
                lineaPedidoCEN.New_ (3, 1, id_pedido6, id_producto6);


                //VALORACIONES
                ValoracionCEN valoracionCEN = new ValoracionCEN ();
                valoracionCEN.New_ (3, "Pues esta bastante bien", id_producto, id_usu);
                valoracionCEN.New_ (2, "Pues esta bastante bien", id_producto, id_usu2);
                valoracionCEN.New_ (5, "Pues esta bastante bien", id_producto, id_usu3);
                valoracionCEN.New_ (3, "Pues esta bastante bien", id_producto2, id_usu);
                valoracionCEN.New_ (1, "Pues esta bastante bien", id_producto2, id_usu2);
                valoracionCEN.New_ (5, "Pues esta bastante bien", id_producto2, id_usu3);
                valoracionCEN.New_ (4, "Pues esta bastante bien", id_producto2, id_usu4);

                //SUBFOROS
                SubforoCEN subforoCEN = new SubforoCEN ();
                int id_subforo = subforoCEN.New_ (id_usu, "Mesa cuadrada para flexear de personaje", new DateTime (2022, 10, 25), "Pues eso, que se habla de cosas de rol", 3); // El numero de comentarios esta por cambiar a falta de confirmacion
                int id_subforo2 = subforoCEN.New_ (id_usu, "Mesa cuadrada para flexear de personaje", new DateTime (2022, 10, 25), "Pues eso, que se habla de cosas de rol", 3);
                int id_subforo3 = subforoCEN.New_ (id_usu2, "Mesa cuadrada para flexear de personaje", new DateTime (2022, 10, 25), "Pues eso, que se habla de cosas de rol", 3);
                int id_subforo4 = subforoCEN.New_ (id_usu2, "Mesa cuadrada para flexear de personaje", new DateTime (2022, 10, 25), "Pues eso, que se habla de cosas de rol", 3);
                //COMENTARIOS
                ComentarioCEN comentarioCEN = new ComentarioCEN ();
                comentarioCEN.New_ (id_subforo, id_usu, "Que si que no me apetece pensar.");
                comentarioCEN.New_ (id_subforo, id_usu2, "Que si que no me apetece pensar.");
                comentarioCEN.New_ (id_subforo, id_usu3, "Que si que no me apetece pensar.");
                comentarioCEN.New_ (id_subforo2, id_usu, "Que si que no me apetece pensar.");
                comentarioCEN.New_ (id_subforo3, id_usu2, "Que si que no me apetece pensar.");
                comentarioCEN.New_ (id_subforo2, id_usu3, "Que si que no me apetece pensar.");

                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");


                Console.WriteLine ("-------------COMPROBACIONES DE LOS CUSTOM-------------");
                Console.WriteLine ();
                Console.WriteLine ();

                // metodo restar, sumar y comprobar stock y mortrar por consola

                ProductoEN prodEN = new ProductoCAD ().ReadOIDDefault (id_producto);
                PedidoEN pedEN = new PedidoCAD ().ReadOIDDefault (id_pedido);

                Console.WriteLine ("Stock inicial: " + prodEN.Stock);
                Console.WriteLine ();

                Console.WriteLine ("-------------Metodo restar stock-------------");

                try
                {
                        productoCEN.RestarStock (id_producto, 23);
                }
                catch (Exception e)
                {
                        System.Console.WriteLine (e.Message);
                }

                prodEN = new ProductoCAD ().ReadOIDDefault (id_producto);

                Console.WriteLine ("Stock restado(23): " + prodEN.Stock);
                Console.WriteLine ();
                Console.WriteLine ();

                Console.WriteLine ("-------------Metodo sumar stock-------------");
                productoCEN.SumarStock (id_producto, 47);
                prodEN = new ProductoCAD ().ReadOIDDefault (id_producto);
                Console.WriteLine ("Stock sumado(47): " + prodEN.Stock);
                Console.WriteLine ();
                Console.WriteLine ();

                Console.WriteLine ("-------------Metodo comprobar stock-------------");
                Console.WriteLine ("¿Hay 2021 de Stock? " + productoCEN.HayStock (id_producto, 2201));
                Console.WriteLine ();

                Console.WriteLine ("¿Hay 21 de Stock? " + productoCEN.HayStock (id_producto, 21));
                Console.WriteLine ();
                Console.WriteLine ();

                Console.WriteLine ("-------------Metodo cambiar estado-------------");
                Console.WriteLine ("El estado actual del pedido es: " + pedEN.Estado);
                Console.WriteLine ();

                Console.WriteLine ("Se va a intentar cambiar el estado del pedido a 'EnProceso' (su estado actual)");
                pedidoCEN.CambiarEstado (id_pedido, EstadoEnum.enProceso);
                pedEN = new PedidoCAD ().ReadOIDDefault (id_pedido);
                Console.WriteLine ("El estado actual del pedido es: " + pedEN.Estado);
                Console.WriteLine ();

                Console.WriteLine ("Se va a intentar cambiar el estado del pedido a 'Devuelto'");
                pedidoCEN.CambiarEstado (id_pedido, EstadoEnum.devuelto);
                pedEN = new PedidoCAD ().ReadOIDDefault (id_pedido);
                Console.WriteLine ("El estado actual del pedido es: " + pedEN.Estado);
                Console.WriteLine ();
                Console.WriteLine ();

                Console.WriteLine ("-------------COMPROBACIONES DE LOS READFILTER-------------");
                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}


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
                int id_usu = usuarioCEN.New_ (p_nombre: "Yo", p_email: "yo@gmail.com", p_apellidos: "Yomismo", p_nickname: "Mimismo", p_pass: "1234", p_rol: RolEnum.usuario_base);
                //LOGIN usuario
                if (usuarioCEN.Login (id_usu, "1234") != null) {
                        Console.WriteLine ("El Login es correcto");
                }

                //TARJETAS
                TarjetaCEN tarjetaCEN = new TarjetaCEN ();
                tarjetaCEN.New_ ("Yo Yomismo", "12341234", 123, new DateTime (2023, 1, 1), id_usu);

                //DIRECCIONES
                DireccionCEN direccionCEN = new DireccionCEN ();
                direccionCEN.New_ ("Alicante", "Alcoy", "03803", "Odio existir", id_usu);

                //PRODUCTOS
                ProductoCEN productoCEN = new ProductoCEN ();
                int id_producto = productoCEN.New_ ("Dados", "Marca Blanca", 27, 2.99, "Imagen", "Chulisimos dados de seis caras", 0, Tipo_productoEnum.dado);

                //PEDIDOS
                PedidoCEN pedidoCEN = new PedidoCEN ();
                int id_pedido = pedidoCEN.New_ (new DateTime (2023, 1, 1), "Sigo igual", 30, 1, PagoEnum.tarjeta, EstadoEnum.enProceso, id_usu);

                //LINEAS DE PEDIDO
                LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN ();
                lineaPedidoCEN.New_ (3, 10, id_pedido, id_producto);

                //VALORACIONES
                ValoracionCEN valoracionCEN = new ValoracionCEN ();
                valoracionCEN.New_ (3, "Pues esta bastante bien", id_producto, id_usu);

                //SUBFOROS
                SubforoCEN subforoCEN = new SubforoCEN ();
                int id_subforo = subforoCEN.New_ (id_usu, "Mesa cuadrada para flexear de personaje", new DateTime (2022, 10, 25), "Pues eso, que se habla de cosas de rol", 3); // El numero de comentarios esta por cambiar a falta de confirmacion

                //COMENTARIOS
                ComentarioCEN comentarioCEN = new ComentarioCEN ();
                comentarioCEN.New_ (id_subforo, id_usu, "Que si que no me apetece pensar");






                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");



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

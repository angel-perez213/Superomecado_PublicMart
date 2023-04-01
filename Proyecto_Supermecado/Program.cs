using System;
using System.ComponentModel.Design;

class PublicMart
{
    public static DateTime Today
    {
        get;
    }
    static void Main(string[] args)
    {
        //son todas las variables que vamos a usar en todo el programa donde,cd es codigo de producto
        string seguir, cd;
        char seguir2, seguir3;
        int cantidad1 = 0, cantidad2 = 0, cantidad3 = 0, cantidad4 = 0, cantidad5 = 0;
        double precio1 = 0, precio2 = 0, precio3 = 0, precio4 = 0, precio5 = 0;
        int cant1 = 0, cant2 = 0, cant3 = 0, cant4 = 0, cant5 = 0, cantTotal = 0, puntos = 0, cantFac = 0, cantPuntos = 0, totalTarjeta = 0, totalEfectivo = 0;
        double pre1 = 0, pre2 = 0, pre3 = 0, pre4 = 0, pre5 = 0, subtotal = 0, IVA = 0, ISR = 0, total = 0, sumaTotal = 0;
        do
        {
            //Menu, opciones del menu
            Console.WriteLine("Ingrese la opción: ");
            Console.WriteLine("1. Facturación");
            Console.WriteLine("2. Reportes de facturación");
            Console.WriteLine("3. Cerrar programa");
            int opciones = Convert.ToInt32(Console.ReadLine());
            DateTime thisDay = DateTime.Today;
            Random rnd = new Random();
            int x = rnd.Next(1, 1001);

            Console.Clear();
            switch (opciones)
            {
                // Son las variables para la facturacion 
                case 1:
                    do
                    {
                        cant1 = 0; cant2 = 0; cant3 = 0; cant4 = 0; cant5 = 0;
                        pre1 = 0; pre2 = 0; pre3 = 0; pre4 = 0; pre5 = 0;
                        Console.WriteLine("numero de NIT:");
                        double nit = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("e-mail");
                        string em = Console.ReadLine();
                        Console.WriteLine("Nombre");
                        string name = Console.ReadLine();
                        Console.Clear();
                        do
                        {
                            //pro se refiere al codigo del producto
                            Console.WriteLine("Codigo de producto");
                            cd = Console.ReadLine();
                            while (cd != "001" && cd != "002" && cd != "003" && cd != "004" && cd != "005")
                            {
                                Console.WriteLine("El codigo no es valido");
                                cd = Console.ReadLine();
                            }
                            // es el switch que nos dice que al ingresar el codigo hace estas acciones
                            switch (cd)
                            {
                                case "001":

                                    Console.WriteLine("Cantidad del producto: ");
                                    cant1 = Convert.ToInt32(Console.ReadLine());
                                    while (cant1 < 0)
                                    {
                                        Console.WriteLine("La cantidad debe ser mayor a 0");
                                        cant1 = Convert.ToInt32(Console.ReadLine());
                                    }
                                    pre1 = cant1 * 1.10;
                                    precio1 = precio1 + pre1;
                                    cantidad1 = cantidad1 + cant1;

                                    break;
                                case "002":
                                    Console.WriteLine("Cantidad del producto: ");
                                    cant2 = Convert.ToInt32(Console.ReadLine());
                                    while (cant2 < 0)
                                    {
                                        Console.WriteLine("Cantidad del producto: ");
                                        cant2 = Convert.ToInt32(Console.ReadLine());
                                    }
                                    pre2 = cant2 * 5;
                                    precio2 = precio2 + pre2;
                                    cantidad2 = cantidad2 + cant2;
                                    break;
                                case "003":
                                    Console.WriteLine("Cantidad del producto: ");
                                    cant3 = Convert.ToInt32(Console.ReadLine());
                                    while (cant3 < 0)
                                    {
                                        Console.WriteLine("La cantidad debe ser mayor a 0");
                                        cant3 = Convert.ToInt32(Console.ReadLine());
                                    }
                                    pre3 = cant3 * 7.30;
                                    precio3 = precio3 + pre3;
                                    cantidad3 = cantidad3 + cant3;
                                    break;
                                case "004":
                                    Console.WriteLine("Cantidad del producto: ");
                                    cant4 = Convert.ToInt32(Console.ReadLine());
                                    while (cant4 < 0)
                                    {
                                        Console.WriteLine("La cantidad debe ser mayor a 0");
                                        cant4 = Convert.ToInt32(Console.ReadLine());
                                    }
                                    pre4 = cant4 * 32.50;
                                    precio4 = precio4 + pre4;
                                    cantidad4 = cantidad4 + cant4;
                                    break;
                                case "005":
                                    Console.WriteLine("Cantidad del producto: ");
                                    cant5 = Convert.ToInt32(Console.ReadLine());
                                    while (cant5 < 0)
                                    {
                                        Console.WriteLine("La cantidad debe ser mayor a 0");
                                        cant5 = Convert.ToInt32(Console.ReadLine());
                                    }
                                    pre5 = cant5 * 17.95;
                                    precio5 = precio5 + pre5;
                                    cantidad5 = cantidad5 + cant5;
                                    break;

                            }
                            Console.Clear();
                            Console.WriteLine("Desea ingresar otro producto? S/N");
                            seguir = Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine();

                            //aqui se declaran las variables de los impuestos 

                        } while (seguir == "S");
                        subtotal = pre1 + pre2 + pre3 + pre4 + pre5;
                        cantTotal = cant1 + cant2 + cant3 + cant4 + cant5;
                        IVA = subtotal * 0.12;
                        ISR = subtotal * 0.05;
                        total = subtotal + IVA + ISR;
                        //metodos de pago 
                        Console.WriteLine("Metodo de pago: tarjeta/efectivo");
                        string pago = Console.ReadLine();
                        Console.Clear();
                        //si es tarjeta de credito haga la siguiente funcion
                        if (pago == "tarjeta")
                        {
                            if (subtotal < 50 && subtotal > 0)
                            {
                                puntos = (int)(subtotal / 10);
                            }
                            else if (subtotal < 150 && subtotal > 50)
                            {
                                puntos = (int)(subtotal / 10) * 2;
                            }
                            else if (subtotal > 150)
                            {
                                puntos = (int)(subtotal / 10) * 3;
                            }
                            totalTarjeta++;
                        }
                        //si es efectivo haga la siguiente funcion
                        else if (pago == "efectivo")
                        {
                            totalEfectivo++;
                        }
                        cantPuntos = cantPuntos + puntos;
                        //math.pow una clase que eleva al cuadrado

                        double NoFact = ((2 * x + Math.Pow(puntos, 2)) + (2021 * cantTotal)) % 1000;
                        string nNoFact = NoFact.ToString();

                        if (nNoFact.Length < 4)
                        {
                            nNoFact = "0" + nNoFact;
                        }
                        if (nNoFact.Length < 3)
                        {
                            nNoFact = "00" + nNoFact;
                        }
                        //se imprime la factura
                        Console.WriteLine("Se enviara una copia de la factura al correo: " + em);
                        Console.WriteLine("************************");
                        Console.WriteLine("                               FACTURA                              ");
                        Console.WriteLine("                              PUBLIC MART                           ");
                        Console.WriteLine("************************");
                        Console.WriteLine(thisDay.ToString("dd/MM/yyyy"));
                        Console.WriteLine("No. de Factura: " + nNoFact);
                        Console.WriteLine("NIT: " + nit);
                        Console.WriteLine("Nombre: " + name);
                        Console.WriteLine("************************");
                        Console.WriteLine("  CODIGO |          PRODUCTO         | CANTIDAD | PRECIO |   TOTAL  ");
                        Console.WriteLine("************************");
                        Console.WriteLine("   001      Pan frances                  " + cant1 + "       Q 1.10       " + pre1);
                        Console.WriteLine("   002      Libra azucar                 " + cant2 + "       Q 5.00       " + pre2);
                        Console.WriteLine("   003      Caja de galletas             " + cant3 + "       Q 7.30       " + pre3);
                        Console.WriteLine("   004      Caja de granola              " + cant4 + "       Q32.50       " + pre4);
                        Console.WriteLine("   005      Litro jugo naranja           " + cant5 + "       Q17.95       " + pre5);
                        Console.WriteLine("************************");
                        Console.WriteLine("SUBTOTAL                                                    Q" + subtotal);
                        Console.WriteLine("ISR                                                         Q" + ISR);
                        Console.WriteLine("IVA                                                         Q" + IVA);
                        Console.WriteLine("************************");
                        Console.WriteLine("TOTAL A PAGAR                                               Q" + total);
                        Console.WriteLine("************************");
                        Console.WriteLine("METODO DE PAGO: " + pago);
                        Console.WriteLine("TOTAL DE PUNTOS ACUMULADOS: " + puntos);
                        Console.WriteLine("************************");
                        Console.WriteLine(" ");
                        cantFac++;
                        Console.WriteLine("Desea ingresar mas facturas? S/N");
                        seguir2 = Convert.ToChar(Console.ReadLine());
                        Console.Clear();
                        sumaTotal = total + sumaTotal;
                        cant1 = 0;

                    } while (seguir2 == 'S');

                    // la opcion que al poner la opcion 2 nos da el reporte de facturacion

                    break;
                case 2:
                    Console.WriteLine("************************");
                    Console.WriteLine("                      REPORTES DE FACTURACION                       ");
                    Console.WriteLine("                           PUBLIC MART                              ");
                    Console.WriteLine("************************");
                    Console.WriteLine("FACTURAS GENERADAS: " + cantFac + " FACTURAS");
                    Console.WriteLine("PRODUCTOS VENTIDOS: " + cantTotal + " PRODUCTOS");
                    Console.WriteLine("PUNTOS GENERADOS: " + cantPuntos + " PUNTOS");
                    Console.WriteLine("************************");
                    Console.WriteLine("                    LISTADO DE PRODUCTOS VENTIDOS                   ");
                    Console.WriteLine("************************");
                    Console.WriteLine("  CODIGO |          PRODUCTO         | CANTIDAD | PRECIO |   TOTAL  ");
                    Console.WriteLine("************************");
                    Console.WriteLine("   001      Pan frances                  " + cantidad1 + "       Q 1.10       " + precio1);
                    Console.WriteLine("   002      Libra azucar                 " + cantidad2 + "       Q 5.00       " + precio2);
                    Console.WriteLine("   003      Caja de galletas             " + cantidad3 + "       Q 7.30       " + precio3);
                    Console.WriteLine("   004      Caja de granola              " + cantidad4 + "       Q32.50       " + precio4);
                    Console.WriteLine("   005      Litro jugo naranja           " + cantidad5 + "       Q17.95       " + precio5);
                    Console.WriteLine("************************");
                    Console.WriteLine("************************");
                    Console.WriteLine("                                VENTAS                              ");
                    Console.WriteLine("************************");
                    Console.WriteLine("TOTAL DE VENTAS AL CREDITO: " + totalTarjeta);
                    Console.WriteLine("TOTAL DE VENTAS AL CONTADO: " + totalEfectivo);
                    Console.WriteLine("TOTAL DE TODAS LAS VENTAS: " + sumaTotal);
                    break;
                //opcion 3 la opcion 3 es para cerrar el programa
                case 3:

                    break;
            }
            Console.WriteLine("Desea volver al menu? S/N");
            seguir3 = Convert.ToChar(Console.ReadLine());

            Console.Clear();
        } while (seguir3 == 'S');
    }
}


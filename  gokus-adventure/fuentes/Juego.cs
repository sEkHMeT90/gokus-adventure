﻿/** 
 *   Juego: Clase "de apoyo" casi vacía que lanza la presentación o el juego
 *  
 *   @see Hardware Partida
 *   @author 1-DAI IES San Vicente 2010/11
 */

/* --------------------------------------------------         
   Versiones hasta la fecha:
   
   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  17-Dic-2010  Nacho Cabanes
                      Version inicial, que entra a modo gráfico
                        y lanza la presentación y permite entrar
                        a la partida.
   0.02  05-Jul-2011  Andrés Marotta
                      Agregados los atributos "plano" y "datos"
                        para enlazar con las clases "Plano" y
                        "CargarGuardar" respectivamente
    0.03  18-Jul-2011  Raquel Lloréns
                       Añadida la opción "OPC_NIVELAYUDA"
 ---------------------------------------------------- */



public class Juego
{
    private Presentacion presentacion;
    private Partida partida;
    private Creditos creditos;
    private Plano plano;
    private CargarGuardar datos;


    // Inicialización al comenzar la sesión de juego
    public Juego()
    {
      // Inicializo modo grafico 800x600 puntos, 24 bits de color
      bool pantallaCompleta = false;
      Hardware.Inicializar(800, 600, 24, pantallaCompleta);

      // Inicializo componentes del juego
      presentacion = new Presentacion();
      partida = new Partida();
      creditos = new Creditos();
      plano = new Plano();
      datos = new CargarGuardar();
    }


    // --- Comienzo de un nueva partida: reiniciar variables ---
    public void Ejecutar()
    {
      do
      {
        presentacion.Ejecutar();

        switch (presentacion.GetOpcionEscogida())
        {
          case Presentacion.OPC_CREDITOS:
            creditos.Ejecutar();
            break;
          case Presentacion.OPC_JUGAR:
            partida.miMapa.SetNivel(1);
            partida.BuclePrincipal();
            break;
          case Presentacion.OPC_NIVELAYUDA:
            partida.miMapa.SetNivel(0);
            partida.BuclePrincipal();
            break;
        }
      }
      while (presentacion.GetOpcionEscogida() != Presentacion.OPC_SALIR);
    }


    // --- Cuerpo del programa -----
    public static void Main()
    {
      Juego juego = new Juego();
      juego.Ejecutar();
    }

} /* fin de la clase Juego */


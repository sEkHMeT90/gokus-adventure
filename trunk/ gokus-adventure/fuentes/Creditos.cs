/** 
         *   Creditos: pantalla de créditos (autor/es)
         *  
         *       @see Hardware Juego Presentacion
         *       @author 1-DAI IES San Vicente 2010/11
         */

/* --------------------------------------------------
   Versiones hasta la fecha:
   
   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  17-Dic-2010  Nacho Cabanes
                        Version inicial: muestra el nombre del (supuesto) autor
                      del remake, y del juego original
   0.02  12-Jul-2011  Raquel Lloréns
                        Actualizado con los autores y el nombre del juego reales.
                        Añadida imágen de fondo.
                        Añadidas sombras a los textos.
   0.03  18-Jul-2011  Raquel Lloréns
                        Cambiada la tecla de salida de ESC a INTRO.
 ---------------------------------------------------- */


public class Creditos
{
    // Atributos
   private ElemGrafico fondo;
   private Fuente fuenteSans14;
   private Fuente fuentedball26;
   private Fuente fuentedball44;
   private Fuente fuentedball88;

   public Creditos()  // Constructor
   {
      fondo = new ElemGrafico("imagenes/creditos.png");
      fuenteSans14 = new Fuente("FreeSansBold.ttf", 14);
      fuentedball26 = new Fuente("Saiyan-Sans.ttf", 26);
      fuentedball44 = new Fuente("Saiyan-Sans.ttf", 44);
      fuentedball88 = new Fuente("Saiyan-Sans.ttf", 88);
   }


   /// Lanza la pantalla de creditos
   public void Ejecutar()
   {
      int yMax = 50;
      int y = 600;
        
      do
      {
         // Borro la pantalla
         Hardware.BorrarPantallaOculta(0, 0, 0);

         // Dibujo la imagen de la presentacion
         fondo.DibujarOculta(0, 0);

         while (y > yMax)
         {
               // Borro la pantalla
               Hardware.BorrarPantallaOculta(0, 0, 0);

               // Dibujo la imagen de la presentacion
               fondo.DibujarOculta(0, 0);
                
               // Muestro los créditos

               Hardware.EscribirTextoOculta(
                  "GOKU'S ADVENTURE", 102, (short)( y + 1 ),
                      255, 255, 0, fuentedball88 );
               Hardware.EscribirTextoOculta(
                  "GOKU'S ADVENTURE", 101, (short)( y + 1 ),
                     255, 255, 0, fuentedball88 );
               Hardware.EscribirTextoOculta(
                  "GOKU'S ADVENTURE", 100, (short)y,
                     255, 140, 0, fuentedball88 );

               Hardware.EscribirTextoOculta(
                  "2011", 371, (short)( y + 101 ),
                     0, 0, 128, fuenteSans14 );
               Hardware.EscribirTextoOculta(
                  "2011", 370, (short)( y + 100 ),
                     255, 255, 0, fuenteSans14 );

               Hardware.EscribirTextoOculta( "Aitor Salgado Molina", 261, (short)( y + 141 ),
                     0, 0, 128, fuentedball44 );
               Hardware.EscribirTextoOculta( "Aitor Salgado Molina", 260, (short)( y + 140 ),
                     255, 0, 0, fuentedball44 ); 
               Hardware.EscribirTextoOculta("Andres Marotta", 261, (short)(y + 191),
                     0, 0, 128, fuentedball44 );
               Hardware.EscribirTextoOculta( "Andres Marotta", 260, (short)( y + 190 ),
                     255, 0, 0, fuentedball44 );
               Hardware.EscribirTextoOculta("Antonio Perez Pareja", 261, (short)(y + 241),
                     0, 0, 128, fuentedball44 );
               Hardware.EscribirTextoOculta( "Antonio Perez Pareja", 260, (short)( y + 240 ),
                     255, 0, 0, fuentedball44 );
               Hardware.EscribirTextoOculta( "Antonio Ramos Torres", 261, (short)( y + 291 ),
                     0, 0, 128, fuentedball44 );
               Hardware.EscribirTextoOculta( "Antonio Ramos Torres", 260, (short)( y + 290 ),
                     255, 0, 0, fuentedball44 );
               Hardware.EscribirTextoOculta("Pedro Zalacain", 261, (short)(y + 341),
                     0, 0, 128, fuentedball44 );
               Hardware.EscribirTextoOculta( "Pedro Zalacain", 260, (short)( y + 340 ),
                     255, 0, 0, fuentedball44 );
               Hardware.EscribirTextoOculta("Raquel Llorens Gambin", 261, (short)(y + 391),
                     0, 0, 128, fuentedball44 );
               Hardware.EscribirTextoOculta( "Raquel Llorens Gambin", 260, (short)( y + 390 ),
                     255, 0, 0, fuentedball44 );

               Hardware.EscribirTextoOculta(
                     "Pulsa INTRO para volver a la presentacion...",
                     241, (short)( y + 490 ), 255, 255, 0, fuentedball26 );
               Hardware.EscribirTextoOculta(
                     "Pulsa INTRO para volver a la presentacion...",
                     240, (short)( y + 490 ), 255, 140, 0, fuentedball26 );

               Hardware.VisualizarOculta();

               y -= 10;
         }

         Hardware.Pausa(40);

      }
      while (!Hardware.TeclaPulsada(Hardware.TECLA_INTRO)) ;
   }

} /* fin de la clase Creditos */

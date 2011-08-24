/* --------------------------------------------------
   Parte de: Goku's Adventure - ObjetoRecogible.cs
   Versiones hasta la fecha:

   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  25-Ago-2011  Pedro Zalacain
                       Base para objetos que se recojan (Monedas)
 ---------------------------------------------------- */

public class ObjetoRecogible : ElemGrafico
{
    public ObjetoRecogible(short nuevaX, short nuevaY)
    {
        x = nuevaX;
        y = nuevaY;
    }

    public virtual void Animar()
    {
        SiguienteFotograma();
    }

    public void MoverScroll(short valor)
    {
        x += valor;
        minX += valor;
        maxX += valor;
    }

    public void Desaparecer()
    {
        visible = false;
    }

} /* end class ObjetoRecogible */
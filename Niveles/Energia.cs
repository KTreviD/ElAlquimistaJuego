using UnityEngine;
using UnityEngine.UI;
using System;

public class Energia : MonoBehaviour
{
    public Slider SliderBola;
    public Text MultiplicadorT;
    public Text MultiplicadorTQueNoSeVe;
    public Text NivelJuegoT;
    private double NivelJuego;
    private double Multiplicador = 0;
    private float EnergiaMaxima = 20;
    private float EnergiaActual;
    private bool YaSePuedeQuitar = false;
    private bool TiempoActivar = true;
    private float TiempoPasado;
    private double VecesPresionado = 0;
    public Text VecesPresionadoT;
    private int i = 1;
    private int j = 1;

    public void Start()
    {
        MultiplicadorT.text = "X" + Multiplicador;
        EnergiaActual = EnergiaMaxima;
    }


    public void TocarBoton()
    {
        if(EnergiaActual > 0)
        {
            Multiplicador += .4;
            Multiplicador = Math.Round(Multiplicador ,1);
            MultiplicadorT.text = "X" + Multiplicador;
            MultiplicadorTQueNoSeVe.text =  Multiplicador.ToString();
            EnergiaActual--;
            SliderBola.value = EnergiaActual / EnergiaMaxima;
            TiempoActivar = false;
            TiempoPasado = 0;
            YaSePuedeQuitar = false;
            VecesPresionado++;
            VecesPresionadoT.text = VecesPresionado.ToString();
        }
    }

    public void Update()
    {
            if(TiempoActivar == false)
            {
                TiempoPasado += Time.deltaTime;  
            }
            if(TiempoPasado >= 3)
            {
                TiempoActivar = true;
                YaSePuedeQuitar = true;
            }


        j++;
        if(j == 9)
        {
            if(Multiplicador > 0 && YaSePuedeQuitar)
            {
                Multiplicador -= .4;
                Multiplicador = Math.Round(Multiplicador ,1);
                MultiplicadorT.text = "X" + Multiplicador;
                MultiplicadorTQueNoSeVe.text =  Multiplicador.ToString();
            }
            j = 0;
        }




        i++;
        if(i == 179)
        {
            if(EnergiaActual < EnergiaMaxima)
            {
                EnergiaActual++;
                SliderBola.value = EnergiaActual / EnergiaMaxima;
            }
            i = 0;
        }
    }

    public void Reiniciar()
    {
        NivelJuego = Convert.ToDouble(NivelJuegoT.text);
        if(NivelJuego >= 1)
        {
            Multiplicador = 0;
            MultiplicadorT.text = "X" + Multiplicador;
            MultiplicadorTQueNoSeVe.text =  Multiplicador.ToString();
            EnergiaActual = EnergiaMaxima;
            SliderBola.value = 1;
        }
    }
}

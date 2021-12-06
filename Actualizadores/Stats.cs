using UnityEngine.UI;
using UnityEngine;
using System;

public class Stats : MonoBehaviour
{
    public Text MPSMaximoT;
    public Text VecesReiniciadasT;
    public Text NivelMaximoT;
    public Text MineralMaximoT;
    public Text MaximaEnergiaT;
    public Text VecesPresionadoBotonTocameT;
    public Text MineralReinicioMaximoT;
    public Text PuntosHabilidadGastadosT;
    public Text NivelMaximoLibroAlcanzadoT;
    public Text NivelGemaMaximoT;
    public Text NumeroAscencionesT;
    public Text NumeroMinionsMaximosT;
    public Text CantidadMinionsCompradosT;
    public Text CantidadMinionsCompradosEsteReinicioT;
    public Text MineralAscencionMaximoT;
    public Text NivelJuegoT;

    private double NivelJuego;
    private double MPSMaximo;
    private double VecesReiniciadas;
    private double NivelMaximo;
    private double MineralMaximo;
    private double MaximaEnergia;
    private double VecesPresionadoBotonTocame;
    private double MineralReinicioMaximo;
    private double PuntosHabilidadGastados;
    private double NivelMaximoLibroAlcanzado;
    private double NivelGemaMaximo;
    private double NumeroAscenciones;
    private double NumeroMinionsMaximos;
    private double CantidadMinionsComprados;
    private double CantidadMinionsCompradosEsteReinicio;
    private double MineralAscencionMaximo;

    public void Start()
    {
        MPSMaximoT.text = "0";
        VecesReiniciadasT.text = "0";
        NivelMaximoT.text = "1";
        MineralMaximoT.text = "1";
        MaximaEnergiaT.text = "20";
        VecesPresionadoBotonTocameT.text = "0";
        MineralReinicioMaximoT.text = "0";
        PuntosHabilidadGastadosT.text = "0";
        NivelMaximoLibroAlcanzadoT.text = "1";
        NivelGemaMaximoT.text = "0";
        NumeroAscencionesT.text = "0";
        NumeroMinionsMaximosT.text = "0"; 
        CantidadMinionsCompradosT.text = "0";
        CantidadMinionsCompradosEsteReinicioT.text = "0"; 
        MineralAscencionMaximoT.text = "0";
    }

    public void Reiniciar()
    {
        NivelJuego = Convert.ToDouble(NivelJuegoT.text);
        if(NivelJuego >= 1)
        {
            CantidadMinionsCompradosEsteReinicioT.text = "0";
        }
    }
}

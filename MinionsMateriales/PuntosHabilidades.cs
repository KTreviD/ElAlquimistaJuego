using System;
using UnityEngine;
using UnityEngine.UI;

public class PuntosHabilidades : MonoBehaviour
{
	public Text PuntosGanadosT;
	public Text PuntosAsignadosT;
	public Text PuntosMaximosT;
	public Text PuntosDisponiblesT;
	public Text NivelJuegoT;

	public int PuntosMaximos;
	private double NivelJuego;
	private int PuntosGanados;
	private int PuntosAsignados;
	private int PuntosDisponibles;

	public void Start()
	{	
		PuntosGanadosT.text = PuntosGanados.ToString();
		PuntosMaximosT.text = PuntosMaximos.ToString();
		PuntosAsignadosT.text = "0";
	}

	public void AsignarPunto()
	{
		PuntosDisponibles = Convert.ToInt32(PuntosDisponiblesT.text);

		if(PuntosDisponibles >= 1 && PuntosAsignados < PuntosMaximos)
		{
			PuntosAsignados++;
			PuntosAsignadosT.text = PuntosAsignados.ToString();

			PuntosDisponibles--;
			PuntosDisponiblesT.text = PuntosDisponibles.ToString();
		}
	}
	public void Reiniciar()
	{
		NivelJuego = Convert.ToDouble(NivelJuegoT.text);
    	if(NivelJuego >= 1)
    	{
			PuntosAsignados = 0;
			PuntosAsignadosT.text = "0";
		}
	}
}

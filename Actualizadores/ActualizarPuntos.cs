using System;
using UnityEngine;
using UnityEngine.UI;

public class ActualizarPuntos : MonoBehaviour
{	
	public Minion PasadorLetra;
	public Text PuntosDisponibles;
	public Text ContadorTotal;
	public Text MineralTotalT;
	public Text PuntosGanados;
	public Text MineralReiniciar;
	public Text MineralReiniciarQueSeMostrara;
	public Text MineralReiniciarGuardar;
	public Text MineralReiniciarGuardarQueSeMostraraT;
	public Text MineralNecesario;
	public Text MineralNecesarioQueSeMostraraT;
	public Text NivelJuegoT;
	private double NivelJuego;
	private double Pasador;
	private double Pasador2;
	private double MineralReiniciarCosto = 10;
	public void Start()
	{
		MineralReiniciar.text = "0";
		MineralReiniciarQueSeMostrara.text = "0";
		MineralReiniciarGuardarQueSeMostraraT.text = "0";
		MineralNecesario.text = MineralReiniciarCosto.ToString();
		MineralNecesarioQueSeMostraraT.text = "10";
	}

	public void MineralReiniciarCostoF()
	{
		MineralReiniciarCosto += MineralReiniciarCosto;
		MineralNecesario.text = MineralReiniciarCosto.ToString();
		PasadorLetra.UniversalPonerLetra(MineralReiniciarCosto, MineralNecesarioQueSeMostraraT);
	}

	public void Update()
	{
		Pasador = Convert.ToDouble(MineralTotalT.text);
		if(Pasador >= MineralReiniciarCosto)
		{
			Pasador = Convert.ToDouble(MineralReiniciarGuardar.text);
			Pasador = (Pasador + 1)* 2;
			MineralReiniciarGuardar.text = Pasador.ToString();
			PasadorLetra.UniversalPonerLetra(Pasador, MineralReiniciarGuardarQueSeMostraraT);
			MineralReiniciarCostoF();
		}
	}

    public void Reiniciar()
    {
    	NivelJuego = Convert.ToDouble(NivelJuegoT.text);
    	if(NivelJuego >= 1)
    	{
    		MineralReiniciarCosto = 10;
    		PuntosDisponibles.text = "0";
    		MineralTotalT.text = "1";
   	 		ContadorTotal.text = "0";
			PuntosGanados.text = "0";
			Pasador = Convert.ToDouble(MineralReiniciarGuardar.text);
			Pasador2 = Convert.ToDouble(MineralReiniciar.text);
			Pasador += Pasador2;
			MineralReiniciar.text = Pasador.ToString();
			PasadorLetra.UniversalPonerLetra(Pasador, MineralReiniciarQueSeMostrara);
			MineralNecesario.text = MineralReiniciarCosto.ToString();
			MineralReiniciarGuardar.text = "0";
			MineralReiniciarGuardarQueSeMostraraT.text = "0";
		}
    }
}

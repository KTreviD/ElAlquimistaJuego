using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Niveles : MonoBehaviour
{
	public Inventory Inventario;
	public Text NumMounstroActualT;
	public Text NumMounstroTotalT;
	public Text VidaActualT;
	public Text VidaMaximaT;
	public Text NivelT;
	public Text NivelTextCajita;
	public Text NivelTextCajitaMenor;
	public Text NivelTextCajitaMayor;
	public Text MPST;
	public Text NivelMaximoT;
	public Text MineralesPendientesNT;
	public Minion CobrarDinero;
	public Text ContadorTiempoT;
	private bool EsJefe;
	public Text MultiplicadorEnergiaT;
	public GameObject CajaCompletaMenor;
	public GameObject MineralesPendientes;
	private double NumMounstroTotal;
	private double NumMounstroActual;
	public Text NumMounstroBaseT;
	private float ContadorSegundo = 0;
	private float Vida;
	private int HastaQueNivelVas = 0;
	private double VidaMaxima;
	private double NumMounstroBase;
	private double VidaJefe;
	private float ConstanteDeTiempo = 30;
	private double MPS;
	private double Pasador;
	private float Tiempo;
	private int NivelEscoger;
	private int MineralesPendientesN = 0;
	private int Nivel;
	private double NivelMaximo = 1;

	public CraftingRecipe Espacio;
	public ItemContainer ItemContainer;
	public Item Mineral;
    public void Start()
    {
    	ContadorTiempoT.text = "";
    	slider.value = 1;
        Nivel = 1;
        NivelEscoger = 1;
        NivelTextCajita.text = Nivel.ToString();
        CajaCompletaMenor.SetActive(false);
		NivelTextCajitaMayor.text = (Nivel + 1).ToString();
        Vida = 10;
        NumMounstroActual = 1;
        NumMounstroBaseT.text = "0";
        HastaQueNivelVas = 1;
        NumMounstroBase = 0;
        NumMounstroTotal = 10 - NumMounstroBase;
        VidaMaxima = 10;
        NivelT.text = Nivel.ToString();
        VidaActualT.text = Vida.ToString();
        VidaMaximaT.text = "/ " + VidaMaxima.ToString() + " HP";
        NumMounstroActualT.text = NumMounstroActual.ToString();
        NumMounstroTotalT.text = "/ " + NumMounstroTotal.ToString();
        Inventario = GameObject.FindGameObjectWithTag("MineralInvent").GetComponent<Inventory>();
    }

    public void FlechaDerecha()
    {
    	if(NivelEscoger + 1 <= HastaQueNivelVas)
    	{
    		NivelEscoger++;
    		NivelTextCajita.text = NivelEscoger.ToString();
    		if(NivelEscoger == 2)
    		{
    			CajaCompletaMenor.SetActive(true);
    		}
	        NivelTextCajitaMenor.text = (NivelEscoger - 1).ToString();
			NivelTextCajitaMayor.text = (NivelEscoger + 1).ToString();
	        PonerNivel(NivelEscoger);
    	}   
    }

    public void FlechaIzquierda()
    {
        if(Nivel > 1)
        {
            NivelEscoger--;
            NivelTextCajita.text = NivelEscoger.ToString();
            if(NivelEscoger == 1)
            {
            	CajaCompletaMenor.SetActive(false);
            }
            else
            {
            	NivelTextCajitaMenor.text = (NivelEscoger - 1).ToString();
            }
			NivelTextCajitaMayor.text = (NivelEscoger + 1).ToString();
            PonerNivel(NivelEscoger);
        }
    }

    public void CalcularLaVida()
    {
    	Pasador = Math.Pow(1.57,Nivel-1);
    	Pasador = ((Nivel - 1) + Pasador); 
    	VidaMaxima = 10 * Pasador;
    	VidaMaxima = Math.Ceiling(VidaMaxima);
    	if(EsJefe)
    	{
    		
    		VidaMaxima *= 15;
    		Tiempo = ConstanteDeTiempo;
    		ContadorTiempoT.text = Tiempo.ToString();
    	}
    	Vida = Convert.ToSingle(VidaMaxima);
    	
    	VidaMaximaT.text = "/ " + VidaMaxima.ToString() + " HP";
    	VidaActualT.text = VidaMaxima.ToString();
    }

    public void PonerNivel(int NivelStage)
    {
    	ContadorTiempoT.text = "";
    	Nivel = NivelStage;
    	NivelTextCajita.text = Nivel.ToString();
    	if(Nivel == 1)
    	{
    		CajaCompletaMenor.SetActive(false);
    	}
    	if(Nivel == 2)
    	{
    		CajaCompletaMenor.SetActive(true);
    	}
    	NivelTextCajitaMenor.text = (Nivel - 1).ToString();
		NivelTextCajitaMayor.text = (Nivel + 1).ToString();
    	NivelT.text = Nivel.ToString();
		if(Nivel % 5 == 0)
    	{
    		EsJefe = true;
    	}
    	else
    	{
    		EsJefe = false;
    	}
    	if(Nivel > HastaQueNivelVas)
    	{
    		HastaQueNivelVas = Nivel;
    	}
    	CalcularLaVida();
    	if(EsJefe)
    	{
    		NivelJefe();
    	}
    	if(!EsJefe && HastaQueNivelVas == Nivel)
    	{
    		NivelNormal();
    	}
    	if(!EsJefe && HastaQueNivelVas > Nivel)
    	{
    		NivelYaPasado();
    	}
    }
    public void AvanzarEnMismoNivel()
    {
    	NumMounstroActual++;
    	NumMounstroActualT.text = NumMounstroActual.ToString();
    	Vida = Convert.ToSingle(VidaMaxima);
    	VidaActualT.text = Vida.ToString();
    }

    public void AvanzarEnNivelYaPasado()
    {
    	Vida = Convert.ToSingle(VidaMaxima);
    	VidaActualT.text = Vida.ToString();
    }

    public void BajarVida()
    {
    	MPS = Convert.ToDouble(MPST.text);
    	Vida = Convert.ToSingle(VidaActualT.text);
    	Pasador =  Convert.ToDouble(MultiplicadorEnergiaT.text);
    	Vida -= Convert.ToSingle(MPS + (MPS * Pasador));
    	VidaActualT.text = Vida.ToString();
    }

    public void ComprobarEspacio(IItemContainer itemContainer,Item Mineral2)
    {
    	if(Espacio.HasSpaceMineral(itemContainer,Mineral2))
		{
			Inventario.AgregarMineral();
		}
		else
		{
			MineralesPendientes.SetActive(true);
			MineralesPendientesN++;
			MineralesPendientesNT.text = MineralesPendientesN.ToString();
		}
    }

    public void ReclamarBoton()
    {
    	ReclamarMineralesPendientes(ItemContainer,Mineral);
    }

    public void ReclamarMineralesPendientes(IItemContainer itemContainer,Item Mineral2)
    {
    	if(Espacio.HasSpaceMineral(itemContainer,Mineral2))
		{
			for(int i = 0; i < MineralesPendientesN; i ++)
			{
				Inventario.AgregarMineral();
			}
			MineralesPendientesN = 0;
			MineralesPendientesNT.text = "0";
			MineralesPendientes.SetActive(false);
		}
		else
		{
			Debug.Log("Tu espacio sigue estando lleno, vacialo primero");
		}
    }

    public void Update()
	{
    	if(EsJefe)
    	{
    		Tiempo -= Time.deltaTime;
 		   	ContadorTiempoT.text = Tiempo.ToString();
 		   	if(Tiempo <= 0)
 		   	{
 		   		NivelEscoger--;
 		   		PonerNivel(NivelEscoger);
 		   	}
    	}
    	ContadorSegundo += Time.deltaTime;
    	if(ContadorSegundo >= 1)
    	{
    		ContadorSegundo -= 1;
    		BajarVida();
    	}
		
    	if(Vida <= 0)
    	{
    		if(EsJefe && HastaQueNivelVas == Nivel)
		   	{
		   		slider.value = 0.03f;
		    	CobrarDinero.PasarDeNivel(VidaMaxima);
		    	NivelEscoger++;
		    	PonerNivel(NivelEscoger);
		    	if(NivelEscoger > NivelMaximo)
		    	{
		    		ComprobarEspacio(ItemContainer,Mineral);
			    	NivelMaximo++;
		    		NivelMaximoT.text = NivelMaximo.ToString();
		    	}
		    	return;
		   	}
		   	if(EsJefe && HastaQueNivelVas > Nivel)
		   	{
		   		slider.value = 0.03f;
		    	CobrarDinero.PasarDeNivel(VidaMaxima);
		    	PonerNivel(NivelEscoger);
		    	return;
		   	}
		   	if(!EsJefe && HastaQueNivelVas == Nivel)
		   	{	
		   		CobrarDinero.PasarDeNivel(VidaMaxima);
		   		if(NumMounstroActual == NumMounstroTotal)
		   		{
		   			slider.value = 0.03f;
		    		NivelEscoger++;
		    		PonerNivel(NivelEscoger);
		    		if(NivelEscoger > NivelMaximo)
			    	{
			    		ComprobarEspacio(ItemContainer,Mineral);
				    	NivelMaximo++;
			    		NivelMaximoT.text = NivelMaximo.ToString();
			    	}
		   		}
		   		else
		   		{
		   			slider.value = 0.03f;
		   			AvanzarEnMismoNivel();
		   		}
		   		return;
		   	}
		   	if(!EsJefe && HastaQueNivelVas > Nivel)
		   	{
		   		slider.value = 0.03f;
		   		CobrarDinero.PasarDeNivel(VidaMaxima);
		   		AvanzarEnNivelYaPasado();
		   		return;
		   	}
    	}
		Pasador2 = Convert.ToSingle(Vida/VidaMaxima);
        slider.value = Pasador2;
    }
    public Slider slider;
    private float Pasador2;

    public void Reiniciar()
    {
    	Nivel = Convert.ToInt32(NivelT.text);
    	if(Nivel >= 1)
    	{
    		NivelEscoger = 1;
    		PonerNivel(NivelEscoger);
    		HastaQueNivelVas = 1;
    		NumMounstroBase = Convert.ToSingle(NumMounstroBaseT.text);
			NumMounstroTotal = 10 - NumMounstroBase;
    		NumMounstroTotalT.text = "/ " + NumMounstroTotal.ToString();
    		NumMounstroActual = 1;
    		NumMounstroActualT.text = "1";
    	}
    }

    public void NivelNormal()
    {
    	NumMounstroBase = Convert.ToSingle(NumMounstroBaseT.text);
		NumMounstroTotal = 10 - NumMounstroBase;
    	NumMounstroTotalT.text = "/ " + NumMounstroTotal.ToString();
    	NumMounstroActual = 1;
    	NumMounstroActualT.text = "1";
    }

    public void NivelJefe()
    {
    	NumMounstroActualT.text = " Jefe";
    	NumMounstroTotalT.text = " ";
    }

    public void NivelYaPasado()
    {
    	NumMounstroActualT.text = "";
    	NumMounstroTotalT.text = "";
    }
}

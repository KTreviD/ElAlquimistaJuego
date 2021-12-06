using System;
using UnityEngine;
using UnityEngine.UI;

public class Minion : MonoBehaviour
{
	private double[] NivelMinion = new double[2];
	private double PasadorActualizarPrecioNivel;
	private double PasadorActualizarPrecio;
	private double CostoComprarMGuardar;
	private double MultiplicadorTotem;
	private double CostoNivelGuardar;
	private double NumMinionsGlobal;
	private double EfectoBajarCosto;
	private double EfectoBajarCostoNivel;
	private double MineralReiniciar;
	private double NumMinions;
	private double CostoNivel;
	private double Material;
	private double Pasador3;
	private double Pasador2;
	private double Pasador;	
	private double MPSMaximo = 0;
	private double pasadorSumaTotalChecar = 0;
	private double SumaMPS;
	private double Puntos;
	private string TamanoConvertir;
	private string ConvertirELPasadorMayor16;
	private string NumerosAntesE;
	private char[] LetrasParaUsar = {'K', 'M', 'B', 'T', 'q', 'Q', 's', 'S', 'O', 'N', 'd', 'U', 'D', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '<', '>', '¿', '?', '-', '+', '-', '_', '='};
	private char[] PasadorString = new char[2];
	private char[] PasadorMayor16 = new char[10];
	private bool[] MultiplicadorB = new bool[4];
	private bool[] SePuedeSubirN = new bool[2];
	private bool[] YaSeUso = new bool[2];
	private bool Encontrado;
	private bool MenorOMayorQueLetra;
	private int Multiplicador = 1;
	private int YaSeUsoNumero = 0;
	private int NumeroNivel;
	private double NivelJuego;
	private double VecesReiniciadas = 0;
	private int PasadorInt;
	private int Nivel;
   	private int z = 0;

   	public Text VecesReiniciadasT;
   	public Text MultiplicadorTotemT;
	public Text PuntosDisponiblesT;
	public Text NumMinionsGlobalT;
	public Text CostoSubirNivelT;
	public Text MineralReiniciarT;
	public Text EfectoBajarCostoNivelT;
	public Text EfectoBajarCostoT;
	public Text CostoComprarMT;
	public Text MinionNombreT;
	public Text MineralTotalT;
	public Text MPSMaximoT;
	public Text MPSTPrincipal;
	public Text MPSTPrincipalQueSeMostraraT;
	public Text MineralTotalQueSeMostraraT;
	public Text PuntosGanados;
	public Text PonerNivelT;
	public Text NivelJuegoT;
	public Text NumMinionsT;
	public Text MPST;
   	public double CuantoMinaMinion;
   	public double CostoComprarM;		
	
	public string PonerNombre;

	public Sprite Imagen;

	public Image ImagenMinion;	

	public bool EsElPrimero;

   	public void Start()
   	{	
   		X1();
   		PonerCantidadMinions();
		NivelMinion[0] = 1;
		NumeroNivel = 50;
		MPSMaximo = 0;
		Nivel = 1;
		CostoComprarMGuardar = CostoComprarM;
   		PonerNivelT.text = Nivel.ToString();
   		MinionNombreT.text = PonerNombre;
   		ImagenMinion.sprite = Imagen;
   		MPSTPrincipal.text = "0";
   		EfectoBajarCostoNivelT.text = "0";
   		EfectoBajarCostoNivel = Convert.ToDouble(EfectoBajarCostoNivelT.text);
   		MineralTotalT.text = "1";
   		MineralTotalQueSeMostraraT.text = "1";
   		MultiplicadorTotemT.text = "0";
   		MineralReiniciar = 0;
   		XNivel(NumeroNivel);
   		MPST.text = "0";
   		if(EsElPrimero)
		{
			CostoComprarMT.text = "1";
		}
		else
		{
			CostoComprarMT.text = CostoComprarM.ToString();
		}
   	}

	public void PasarDeNivel(double _Vida)
	{
		Pasador = _Vida/14;
		Pasador = Math.Ceiling(Pasador);
		Pasador = Convert.ToDouble(MineralTotalT.text) + Pasador;
		MineralTotalT.text = Pasador.ToString();
		UniversalPonerLetra(Pasador, MineralTotalQueSeMostraraT);
	}

	public void Contratar()
	{
		Pasador3 =  Convert.ToDouble(MineralTotalT.text);
		XFuncion(Multiplicador);
		CostoComprarM = PasadorActualizarPrecio;
		if(Pasador3 >= CostoComprarM)
		{
			pasadorSumaTotalChecar = pasadorSumaTotalChecar + CostoComprarM;
			//Restar numero de minions totales para puntos
			NumMinionsGlobal = Convert.ToInt32(NumMinionsGlobalT.text);
			NumMinionsGlobal -= NumMinions;
			//Sumar minions dependiendo que multiplicador tengas
			NumMinions += Multiplicador;	
			NumMinionsT.text = NumMinions.ToString();
			//Sumar numero de minions totales para puntos
			NumMinionsGlobal += NumMinions;
			NumMinionsGlobalT.text = NumMinionsGlobal.ToString();
			//Restar precio de compra
			Pasador3 -= CostoComprarM;
			MineralTotalT.text = Pasador3.ToString();
			//Poner letra al mineralTotal
			UniversalPonerLetra(Pasador3, MineralTotalQueSeMostraraT);
			//Poner MPS actual de la compra
			SacarMPS();
			UniversalPonerLetra(SumaMPS, MPST);
			//Niveles
			ChecarNoSubir2Niveles();
			if(MultiplicadorB[0] == true)
			{
				MultiplicadorContratarFuncion(1);
			}
			if(MultiplicadorB[1] == true)
			{
				MultiplicadorContratarFuncion(10);
			}
			if(MultiplicadorB[2] == true)
			{
				MultiplicadorContratarFuncion(50);
			}
			if(MultiplicadorB[3] == true)
			{
				MultiplicadorContratarFuncion(100);
			}
			//Conseguir puntos para las habilidades.
			Pasador = NumMinionsGlobal;
			for(double i = 1; i <= NumMinionsGlobal; i++)
			{
				if(Pasador - 50 >= 0)
				{	
					GenerarPuntos();
				}
				Pasador = Convert.ToDouble(NumMinionsGlobalT.text);
				if(Pasador - 50 >= 0)
				{	
					GenerarPuntos();
				}
			}
		}
	}
	//Calcular el costo de compra de los minions.
	public void XFuncion(int _NMinions)
	{
		Multiplicador = _NMinions;
		PasadorActualizarPrecio = 0;
		for(int i = 0; i < _NMinions; i++)
		{
			if(EsElPrimero && NumMinions < 20)
			{
				if((NumMinions + i) == 0)
				{
					Pasador = 1;
				}
				else
				{
					NumMinions = Convert.ToDouble(NumMinionsT.text);
					Pasador = (NumMinions + i) * 3.6;
					Pasador = Math.Ceiling(Pasador);
				}
				PasadorActualizarPrecio = Pasador + PasadorActualizarPrecio;
			}
			else
			{
				Pasador2 = Math.Pow(1.07,i + NumMinions);
				Pasador = CostoComprarMGuardar * Pasador2;
				Pasador = Math.Ceiling(Pasador);
				PasadorActualizarPrecio = Pasador + PasadorActualizarPrecio;
			}
		}
		EfectoBajarCosto = Convert.ToDouble(EfectoBajarCostoT.text);
		PasadorActualizarPrecio *= (100 - EfectoBajarCosto) / 100;
		PasadorActualizarPrecio = Math.Ceiling(PasadorActualizarPrecio);

		UniversalPonerLetra(PasadorActualizarPrecio, CostoComprarMT);
	}

	public void SacarMPS()
	{
		MultiplicadorTotem = Convert.ToDouble(MultiplicadorTotemT.text);
		MineralReiniciar = Convert.ToDouble(MineralReiniciarT.text);
		SumaMPS =  NivelMinion[Nivel-1] * CuantoMinaMinion;
		SumaMPS = SumaMPS + (SumaMPS * MultiplicadorTotem);
		
		if(MineralReiniciar != 0)
		{
			SumaMPS = (SumaMPS * (MineralReiniciar / 10) + SumaMPS);	
		}
		SumaMPS = Math.Floor(SumaMPS);
		SumaMPS *= NumMinions;
	}

	public void UniversalPonerLetra(double _QueNumeroChecara, UnityEngine.UI.Text _TextoParaCambiar)
	{
		ChecarEntreQueNumerosEstara(_QueNumeroChecara);
		FuncionVerSiYaEsMayorDe16();
		if(MenorOMayorQueLetra == false)
		{
			if(TamanoConvertir.Length >= 0 && TamanoConvertir.Length < 6)
			{
				_TextoParaCambiar.text = _QueNumeroChecara.ToString();
			}
			else
			{
				PasadorInt = Convert.ToInt32((Pasador / 3) - 2);
				CambiarLetra(Pasador, PasadorInt, _TextoParaCambiar);
			}
		}
		else
		{
			PasadorInt = Convert.ToInt32((Pasador / 3) - 2);
			_TextoParaCambiar.text = NumerosAntesE + LetrasParaUsar[PasadorInt];
		}
		z = 0;
	}

	public void ChecarEntreQueNumerosEstara(double _TamanoConvertirF)
	{
		TamanoConvertir = _TamanoConvertirF.ToString();
		Pasador = TamanoConvertir.Length;
		Encontrado = false;
		if(Pasador >= 6)
		{
			while(Encontrado == false)
			{
				if(Pasador % 3 == 0)
				{
					Encontrado = true;
				}
				else
				{
					z++;
					Pasador--;
				}

			}
		}
	}

	public void FuncionVerSiYaEsMayorDe16()
	{
		for(int i = 0; i < TamanoConvertir.Length; i++)
		{
			if(TamanoConvertir[i] == '+')
			{
				ConvertirELPasadorMayor16 = "";
				NumerosAntesE = "";
				MenorOMayorQueLetra = true;
				z = 0;
				for(int j = i + 1; j < TamanoConvertir.Length; j++)
				{
					PasadorMayor16[z] = TamanoConvertir[j];
					ConvertirELPasadorMayor16 += PasadorMayor16[z];
					z++;
				}
				ChecarEntreQueNumerosEstaraMayor16(ConvertirELPasadorMayor16);
				for(int j = 0; j <= 3 + z; j++)
				{
					if(TamanoConvertir[j] != '.')
					{
						PasadorMayor16[j] = TamanoConvertir[j];
						if(z == j - 1)
						{
							NumerosAntesE += "," + PasadorMayor16[j] ;
						}
						else
						{
							NumerosAntesE += PasadorMayor16[j];
						}
					}
				}
				break;
			}
			else
			{
				MenorOMayorQueLetra = false;
			}
		}
	}

	public void ChecarEntreQueNumerosEstaraMayor16(string _TamanoConvertirF)
	{
		Pasador = Convert.ToDouble(_TamanoConvertirF);
		Encontrado = false;
		z = 0;
		if(Pasador >= 6)
		{
			while(Encontrado == false)
			{
				if(Pasador % 3 == 2)
				{
					Encontrado = true;
				}
				else
				{
					z++;
					Pasador--;
				}
			}
		}
	}

	public void CambiarLetra(double _PasadorF, int _Pasador2F, UnityEngine.UI.Text _TextoParaCambiar)
	{
		if(TamanoConvertir.Length >= _PasadorF && TamanoConvertir.Length < _PasadorF + 3)
		{
			_TextoParaCambiar.text = "";
			for(int i = 0; i < TamanoConvertir.Length - (_PasadorF - 3); i ++)
			{
				PasadorString[i] = TamanoConvertir[i];
				Array.Resize(ref PasadorString, PasadorString.Length + 1);
				if(z == i && z != 0)
				{
					_TextoParaCambiar.text += "," + PasadorString[i];
				}
				else
				{
					_TextoParaCambiar.text += PasadorString[i];
				}
				
			}
			_TextoParaCambiar.text += LetrasParaUsar[_Pasador2F];
		}
		z = 0;
	}

	public void MultiplicadorContratarFuncion(int _NMinions)
	{
		MultiplicadorTotem = Convert.ToDouble(MultiplicadorTotemT.text);
		MineralReiniciar = Convert.ToDouble(MineralReiniciarT.text);
		SumaMPS = NivelMinion[Nivel-1] * CuantoMinaMinion;
		SumaMPS *= Multiplicador;
		SumaMPS = SumaMPS + (SumaMPS * MultiplicadorTotem);
		if(MineralReiniciar != 0)
		{
			SumaMPS = (SumaMPS * (MineralReiniciar / 10) + SumaMPS);	
		}
		SumaMPS = Math.Floor(SumaMPS);
		Pasador = Convert.ToDouble(MPSTPrincipal.text);
		Pasador += SumaMPS;
		if(Pasador > MPSMaximo)
		{
			MPSMaximo = Pasador;
			MPSMaximoT.text = MPSMaximo.ToString();
		}
		
		MPSTPrincipal.text = Pasador.ToString();
		UniversalPonerLetra(Pasador, MPSTPrincipalQueSeMostraraT);
		XFuncion(_NMinions);
	}
	
	public void X1()
	{
		MultiplicadorB[0] = true;
		MultiplicadorB[1] = false;
		MultiplicadorB[2] = false;
		MultiplicadorB[3] = false;
		XFuncion(1);
	}

	public void X10()
	{
		MultiplicadorB[0] = false;
		MultiplicadorB[1] = true;
		MultiplicadorB[2] = false;
		MultiplicadorB[3] = false;
		XFuncion(10);
	}

	public void X50()
	{
		MultiplicadorB[0] = false;
		MultiplicadorB[1] = false;
		MultiplicadorB[2] = true;
		MultiplicadorB[3] = false;
		XFuncion(50);
	}

	public void X100()
	{
		MultiplicadorB[0] = false;
		MultiplicadorB[1] = false;
		MultiplicadorB[2] = false;
		MultiplicadorB[3] = true;
		XFuncion(100);
	}

	public void GenerarPuntos()
	{
		Puntos++;
		Pasador -= 50;
		NumMinionsGlobalT.text = Pasador.ToString();
		Pasador = Convert.ToDouble(PuntosGanados.text);
		PuntosGanados.text = (Pasador + Puntos).ToString();
		Pasador = Convert.ToDouble(PuntosDisponiblesT.text);
		PuntosDisponiblesT.text = (Pasador + Puntos).ToString();
		Puntos = 0;
	}

	public void ChecarNoSubir2Niveles()
	{
		if(YaSeUsoNumero == 0)
		{
			if(NumMinions >= 50 && YaSeUso[0] == false)
			{
				SePuedeSubirN[0] = true;
			}
		}
		else
		{
			IfDeChecarNoSubir2Niveles(NumeroNivel,YaSeUsoNumero);
		}
	}

	public void IfDeChecarNoSubir2Niveles(int _NumeroNivel, int _YaSeUsoNumero)
	{
		if(NumMinions >= _NumeroNivel && YaSeUso[_YaSeUsoNumero] == false && YaSeUso[_YaSeUsoNumero - 1] == true)
		{
			SePuedeSubirN[_YaSeUsoNumero] = true;
		}
	}

	public void SubirLvl()
	{	
		Pasador3 =  Convert.ToDouble(MineralTotalT.text);
		XNivel(NumeroNivel);
		CostoNivel = PasadorActualizarPrecioNivel;

		if(Pasador3 >= CostoNivel)
		{
			if(YaSeUso[0] == false)
			{
				if(NumMinions >= 50 && YaSeUsoNumero == 0)
				{
					YaSeUsoNumero = 1;
					SubirNivelFuncion(0);
				}
				
			}
			else 
			{
				IfSubirLvl(NumeroNivel, YaSeUsoNumero, YaSeUsoNumero);
			}
		}
	}

	public void IfSubirLvl(int _NumeroNivel, int _YaSeUsoNumeroF, int _PermisoNivel)
	{
		if(NumMinions >= _NumeroNivel && YaSeUso[_YaSeUsoNumeroF - 1] == true && YaSeUsoNumero == _YaSeUsoNumeroF && SePuedeSubirN[_PermisoNivel] == true)
		{
			YaSeUsoNumero = _YaSeUsoNumeroF + 1;
			SubirNivelFuncion(_YaSeUsoNumeroF);
		}
	}
	//Calcular de precio para subir de nivel
	public void XNivel(int N)
	{
		PasadorActualizarPrecioNivel = 0;
		for(int i = N-50; i < N; i++)
		{
			if(EsElPrimero && NumMinions < 20 && i < 20)
			{
				if(i == 0)
				{
					Pasador = 1;
				}
				else
				{
					NumMinions = Convert.ToDouble(NumMinionsT.text);
					Pasador = i * 3.6;
					Pasador = Math.Ceiling(Pasador);
				}
				PasadorActualizarPrecioNivel += Pasador;
			}
			else
			{
				Pasador2 = Math.Pow(1.07,i);
				Pasador = CostoComprarMGuardar * Pasador2;
				Pasador = Math.Ceiling(Pasador);
				PasadorActualizarPrecioNivel += Pasador;
			}
		}
		EfectoBajarCostoNivel = Convert.ToDouble(EfectoBajarCostoNivelT.text);
		PasadorActualizarPrecioNivel *= (100 - EfectoBajarCostoNivel) / 100;
		PasadorActualizarPrecioNivel = Math.Ceiling(PasadorActualizarPrecioNivel);
		UniversalPonerLetra(PasadorActualizarPrecioNivel, CostoSubirNivelT);
	}

	public void SubirNivelFuncion(int _PermisoNivel)
	{
		//Agrandar tamaño de arreglos
		Array.Resize(ref SePuedeSubirN, SePuedeSubirN.Length + 1);
		Array.Resize(ref NivelMinion, NivelMinion.Length + 1);
		Array.Resize(ref YaSeUso, YaSeUso.Length + 1);
		//Restar el precio al dinero total
		Pasador3 -= CostoNivel;
		MineralTotalT.text = Pasador3.ToString();
		UniversalPonerLetra(Pasador3, MineralTotalQueSeMostraraT);
		//Modificando los permisos
		SePuedeSubirN[_PermisoNivel] = false;
		YaSeUso[_PermisoNivel] = true;
		//Mofidicando el nivel y sus valores
		Nivel++;
		PonerNivelT.text = Nivel.ToString();
		NivelMinion[Nivel - 1] = NivelMinion[Nivel - 2] * 4;
		NumeroNivel += 50;
		XNivel(NumeroNivel);
		ChecarNoSubir2Niveles();
		//Calcular el MPS de este minion
		MultiplicadorTotem = Convert.ToDouble(MultiplicadorTotemT.text);
		SacarMPS();
		UniversalPonerLetra(SumaMPS, MPST);
		//Calcular el MPS total
		Pasador = Convert.ToDouble(MPSTPrincipal.text);
		Pasador = Pasador + SumaMPS;
		SumaMPS = NivelMinion[Nivel-2] * NumMinions * CuantoMinaMinion;	
		SumaMPS = SumaMPS + (SumaMPS * MultiplicadorTotem);
		if(MineralReiniciar != 0)
		{
			SumaMPS = (SumaMPS * (MineralReiniciar / 10) + SumaMPS);	
		}
		Pasador = Pasador - SumaMPS;
		MPSTPrincipal.text = Pasador.ToString();
		UniversalPonerLetra(Pasador, MPSTPrincipalQueSeMostraraT);
	}

	public void PonerCantidadMinions()
	{
    	NumMinions = 0;
    	NumMinionsT.text = "0";
	}
	//////////Funciones aparte de las capacidades del minion//////////
    public void TotemMps()
	{
		Pasador3 = Convert.ToDouble(MPSTPrincipal.text);
		SacarMPS();
		Pasador3 += SumaMPS;
		MPSTPrincipal.text = Pasador3.ToString();
		UniversalPonerLetra(SumaMPS, MPST);
		UniversalPonerLetra(Pasador3, MPSTPrincipalQueSeMostraraT);
		XFuncion(1);
		XNivel(NumeroNivel);
	}

	public void PonerA0MPSPrincipal()
	{
		MPSTPrincipal.text = "0";
    	MPSTPrincipalQueSeMostraraT.text = "0";
	} 

	public void Reiniciar()
    {
    	NivelJuego = Convert.ToDouble(NivelJuegoT.text);
    	if(NivelJuego >= 1)
    	{
	    	X1();
	    	Nivel = 1;

	    	PonerCantidadMinions();
			MultiplicadorTotem = Convert.ToDouble(MultiplicadorTotemT.text);

	    	MPST.text = "0";
	    	CostoComprarM = CostoComprarMGuardar;

	    	if(EsElPrimero)
			{
				CostoComprarMT.text = "1";
			}
			else
			{
				CostoComprarMT.text = CostoComprarM.ToString();
			}
	    	MineralReiniciar = Convert.ToDouble(MineralReiniciarT.text);
	    	PonerNivelT.text = Nivel.ToString();
	    	XNivel(50);
	    	NumeroNivel = 50;
	    	YaSeUsoNumero = 0;
	    	for(int i = 0; i < SePuedeSubirN.Length; i++)
	    	{
	    		SePuedeSubirN[i] = false;
	    		YaSeUso[i] = false;
	    	}
	    }
    }

    public void Reiniciar0()
    {
    	NivelJuego = Convert.ToDouble(NivelJuegoT.text);
    	if(NivelJuego >= 1)
    	{
    		VecesReiniciadas++;
    		VecesReiniciadasT.text = VecesReiniciadas.ToString();
    		MPSTPrincipal.text = "0";
    		MPSTPrincipalQueSeMostraraT.text = "0";
    		MineralTotalQueSeMostraraT.text = "1";
    	}
    	else
    	{
    		Debug.Log("Debes llegar al nivel 100 primero");
    	}
    }
}
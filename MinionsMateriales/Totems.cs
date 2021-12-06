using UnityEngine;
using UnityEngine.UI;
using System;

public class Totems : MonoBehaviour
{
    public Minion PasadorLetra;
    public Text NombreT;
    public Text NivelT;
    public Text DescripcionT;
    public Text EfectoT;
    public Text EfectoTQueSeMostraraT;
    public Text CostoT;
    public Text MineralQueTienesT;
    public Text MineralQueTienesTMuestra;
    public double Costo;
    private double Pasador;
    public double Efecto = 0;
    public double EfectoBajarCostoDeNivelTotem = 0;
    public double Mineral;
    public int Opcion;
	public string Descripcion;
	public string Nombre;
	public Sprite Imagen;

	public Image ImagenTotem;

    private int Nivel = 0;

    public void Start()
    {
    	NivelT.text = Nivel.ToString();
    	CostoT.text = Costo.ToString();
    	DescripcionT.text = Descripcion;
    	ImagenTotem.sprite = Imagen;
    	EfectoT.text = "0";
        EfectoTQueSeMostraraT.text = "0";
    	NombreT.text = Nombre;
    }
    public void Escoger1Totem()
    {
        Opcion = 1;
    }
    public void Escoger2Totem()
    {
        Opcion = 2;
    }
    public void Escoger3Totem()
    {
        Opcion = 3;
    }
    public void Escoger4Totem()
    {
        Opcion = 4;
    }
    public void Escoger5Totem()
    {
        Opcion = 5;
    }
    public void Escoger6Totem()
    {
        Opcion = 6;
    }
    public void Escoger7Totem()
    {
        Opcion = 7;
    }
    public void Escoger8Totem()
    {
        Opcion = 8;
    }
    public void Escoger9Totem()
    {
        Opcion = 9;
    }
    public void Escoger10Totem()
    {
        Opcion = 10;
    }

    public void EscogerFuncion()
    {
        SubirNivelTotemBajarCosto(Opcion);
    }

    public void SubirNivelTotemBajarCosto(int AplicarEfecto)
    {
        Mineral = Convert.ToDouble(MineralQueTienesT.text);
        if(Mineral >= Costo)
        {
            Nivel++;
            NivelT.text = Nivel.ToString();
            //Aqui debo poner que cobrara el costo que sera una piedra especial para conseguir los totems
            Mineral -= Costo;
            MineralQueTienesT.text = Mineral.ToString();
            PasadorLetra.UniversalPonerLetra(Mineral, MineralQueTienesTMuestra);

            switch(AplicarEfecto)
            {
                case 1: EfectoBajarCosto(); GeneradorCostoN2();
                        break;
                case 2: EfectoBajarCosto(); GeneradorCostoN2();
                        break;
                case 3: SubirNivel(); GeneradorCostoLineal();
                        break;
                case 4: EfectoBajarCosto(); GeneradorCostoN2();
                        break;
                case 5: EfectoBajarCosto(); GeneradorCostoN2();
                        break;
                case 6: SubirNivel(); GeneradorCostoLineal();
                        break;
                case 7: EfectoBajarCosto(); GeneradorCostoN2();
                        break;
                case 8: EfectoBajarCosto(); GeneradorCostoN2();
                        break;
                case 9: SubirNivel(); GeneradorCostoLineal();
                        break;
                case 10: EfectoBajarCosto(); GeneradorCostoN2();
                        break;
            }
        }
    }
    
    public void EfectoBajarCosto()
    {
        EfectoBajarCostoDeNivelTotem++;
        EfectoTQueSeMostraraT.text = EfectoBajarCostoDeNivelTotem.ToString();
    }
    public void GeneradorCostoN2()
    {
        Costo = Math.Pow(2,Nivel);
        PasadorLetra.UniversalPonerLetra(Costo, CostoT);
    }

    public void SubirNivel()
    {
        Pasador = Efecto * Nivel;
        EfectoT.text = Pasador.ToString();
        PasadorLetra.UniversalPonerLetra(Pasador, EfectoTQueSeMostraraT);
    }

    public void GeneradorCostoLineal()
    {
        Costo *= 1.4;
        Costo = Math.Round(Costo);
        PasadorLetra.UniversalPonerLetra(Costo, CostoT);
    }

    public void ActualizarParaNivel()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualzarMenu : MonoBehaviour
{
    public GameObject Minions;
    public GameObject Habilidades;
    public GameObject Inventario;
    public GameObject Totems;
	public GameObject SuperTotems;
    public GameObject Stats;    
    public GameObject CombinarGemas;

    public void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void Start()
    {
        Habilidades.SetActive(false);
        Inventario.SetActive(false);
        Totems.SetActive(false);
        SuperTotems.SetActive(false);
        Stats.SetActive(false);
        CombinarGemas.SetActive(false);
    }

    public void TocarMinion()
    {
    	Minions.SetActive(true);
    	Habilidades.SetActive(false);
    	Inventario.SetActive(false);
    	Totems.SetActive(false);
    	SuperTotems.SetActive(false);
    	Stats.SetActive(false);
        CombinarGemas.SetActive(false);
    }

    public void TocarHabilidades()
    {
    	Habilidades.SetActive(true);
    	Inventario.SetActive(false);
    	Totems.SetActive(false);
    	SuperTotems.SetActive(false);
    	Stats.SetActive(false);
        CombinarGemas.SetActive(false);
    }

    public void TocarInventario()
    {
    	Habilidades.SetActive(false);
    	Inventario.SetActive(true);
    	Totems.SetActive(false);
    	SuperTotems.SetActive(false);
    	Stats.SetActive(false);
        CombinarGemas.SetActive(false);
    }

    public void TocarTotems()
    {
    	Habilidades.SetActive(false);
    	Inventario.SetActive(false);
    	Totems.SetActive(true);
    	SuperTotems.SetActive(false);
    	Stats.SetActive(false);
        CombinarGemas.SetActive(false);
    }

    public void TocarSuperTotems()
    {
    	Habilidades.SetActive(false);
    	Inventario.SetActive(false);
    	Totems.SetActive(false);
    	SuperTotems.SetActive(true);
    	Stats.SetActive(false);
        CombinarGemas.SetActive(false);
    }

    public void TocarStats()
    {
    	Habilidades.SetActive(false);
    	Inventario.SetActive(false);
    	Totems.SetActive(false);
    	SuperTotems.SetActive(false);
    	Stats.SetActive(true);
        CombinarGemas.SetActive(false);
    }

    public void TocarCombinarGemas()
    {
        Habilidades.SetActive(false);
        Inventario.SetActive(true);
        Totems.SetActive(false);
        SuperTotems.SetActive(false);
        Stats.SetActive(false);
        CombinarGemas.SetActive(true);
    }
}

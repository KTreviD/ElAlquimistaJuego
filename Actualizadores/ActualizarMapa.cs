using System;
using UnityEngine;
using UnityEngine.UI;

public class ActualizarMapa : MonoBehaviour
{
	public GameObject CasitaNivel1;
	public GameObject CasitaNivel2;
	public GameObject CasitaNivel3;
	public GameObject Principal1;
	public GameObject Principal2;

	public Text PuntosGanadosT;

	private int PuntosGanados;

	public void Start()
	{	
		CasitaNivel2.SetActive(false);
		CasitaNivel3.SetActive(false);
		Principal2.SetActive(false);
	}
    public void Update()
	{
		PuntosGanados = Convert.ToInt32(PuntosGanadosT.text);

		if(PuntosGanados >= 10)
		{
			CasitaNivel1.SetActive(false);
			CasitaNivel2.SetActive(true);
		}
		if(PuntosGanados >= 50)
		{
			CasitaNivel2.SetActive(false);
			CasitaNivel3.SetActive(true);
			Principal1.SetActive(false);
			Principal2.SetActive(true);
		}
	} 
}

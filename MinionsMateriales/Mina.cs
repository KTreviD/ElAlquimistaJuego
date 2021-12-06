using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : MonoBehaviour
{
    public double[] NivelMina = new double[10];
   	public int NivelMinaActual;
   	
    void Start()
    {
   		NivelMinaActual = 0;
		NivelMina[0] = .25;
		NivelMina[1] = .75;
		NivelMina[2] = 2.5;
		NivelMina[3] = 9;
		NivelMina[4] = 30;
		NivelMina[5] = 100;
		NivelMina[6] = 325;
		NivelMina[7] = 1000;
		NivelMina[8] = 3500;
		NivelMina[9] = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

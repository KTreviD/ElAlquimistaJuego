using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualizarMoverMineral : MonoBehaviour
{
    public float GirarX;
	public float GirarY;
    public float GirarZ;
    private float Pasador;
    private float Pasador2;
    private float Constante;
    public Material EsteColor;
    private bool Encendedor = false;
    private float j = 0;
    private int a = 0;
    private int b = 255;
    private int c = 255;
    private int d = 255;
    private int e = 255;
    private int f = 255;
    private int Red = 255;
    private int Blue = 255;
    private int Green = 0;

    public void Start()
    {
        Constante = 0.0004f;
    }
    public void Update()
    {
        EsteColor.color = new Color(Red / 255f,Green / 255f,Blue / 255f,1);
        if(a <= 255)
        {
            Blue--;
            a++;
            if(a == 255)
            {
                b = 0;
                a = 256;
            }
        }
        if(b <= 255)
        {
            Green++;
            b++;
            if(b == 255)
            {
                c = 0;
                b = 256;
            }
        }
        if(c <= 255)
        {
            Red--;
            c++;
            if(c == 255)
            {
                d = 0;
                c = 256;
            }
        }
        if(d <= 255)
        {
            Blue++;
            d++;
            if(d == 255)
            {
                e = 0;
                d = 256;
            }
        }
        if(e <= 255)
        {
            Green--;
            e++;
            if(e == 255)
            {
                f = 0;
                e = 256;
            }
        }
        if(f <= 255)
        {
            Red++;
            f++;
            if(f == 255)
            {
                a = 0;
                f = 256;
            }
        }
    	transform.Rotate(GirarX, GirarY, GirarZ);

        j++;
        Pasador2 = Constante * j;
        Pasador = transform.position.y;
        if(Pasador >= 12 && Encendedor == false)
        {
            j = -j;
            Pasador = 12;
            Encendedor = true;
        }
        if(Pasador <= 6 && Encendedor == true)
        {
            j = -j;
            Encendedor = false;
        }
        Pasador += Pasador2;
        transform.position = new Vector3(transform.position.x, Pasador, transform.position.z); 
    }
}

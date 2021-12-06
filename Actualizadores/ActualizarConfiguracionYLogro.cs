using UnityEngine;

public class ActualizarConfiguracionYLogro : MonoBehaviour
{
    public GameObject Opcion1;
    public bool Opcion1B;
    public bool Opcion2B;
    public GameObject Opcion2;

    public void Start()
    {
        Opcion1.SetActive(false);
        Opcion2.SetActive(false);
        Opcion2B = false;
        Opcion1B = false;
    }

    public void Configuracion()
    {
        if(Opcion1B)
        {
            Opcion1.SetActive(false);
            Opcion1B = false;
        }
        else
        {
            Opcion2.SetActive(false);
            Opcion2B = false;
            Opcion1.SetActive(true);
            Opcion1B = true;
        }
    }

    public void Logos()
    {
        if(Opcion2B)
        {
            Opcion2.SetActive(false);
            Opcion2B = false;
        }
        else
        {
            Opcion1.SetActive(false);
            Opcion1B = false;
            Opcion2.SetActive(true);
            Opcion2B = true;
        }
    }
}

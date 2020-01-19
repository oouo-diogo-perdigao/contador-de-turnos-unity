using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controlador : MonoBehaviour {
    public static Controlador singleton;
    public InputField turno;
    public InputField tolerancia;
    public AudioClip somTurno;
    public AudioClip somTolerancia;

    float ultimoTurno = 0f;
    float ultimaTolerancia = 0f;

    void Start()
    {
        singleton = this;
    }

    public void SomTurno()
    {
        AudioSource.PlayClipAtPoint(somTurno, new Vector3(0f, 0f, 0f));
    }
    public void SomTolerancia()
    {
        AudioSource.PlayClipAtPoint(somTolerancia, new Vector3(0f, 0f, 0f));
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Piscar : MonoBehaviour {
    public Color turnoOff = new Color(0f,1f,0f,1f);
    public Color toleranciaOff = new Color(1f, 0f, 0f, 1f);
    //public 
    float intervaloPisca = 0.2f;
    int quantidadePiscadas = 10;

    Color corOrignal;
    Image fundo;

    void Start()
    {
        fundo = GetComponent<Image>();
        corOrignal = fundo.color;
    }

    public void PiscarTurno()
    {
        StartCoroutine(turno());
    }

    public void PiscarTolerancia()
    {
        StartCoroutine(tolerancia());
    }

    IEnumerator turno()
    {
        for (int i = 0; i < quantidadePiscadas; i++)
        {
            fundo.color = turnoOff;
            yield return new WaitForSeconds(intervaloPisca);
            fundo.color = corOrignal;
            yield return new WaitForSeconds(intervaloPisca);
        }
        StopCoroutine("turno");
    }

    IEnumerator tolerancia()
    {
        for (int i = 0; i < quantidadePiscadas; i++)
        {
            fundo.color = toleranciaOff;
            yield return new WaitForSeconds(intervaloPisca);
            fundo.color = corOrignal;
            yield return new WaitForSeconds(intervaloPisca);
        }
        StopCoroutine("turno");
    }

    /*IEnumerator turno()
    {
        StartCoroutine("DoSomething");
        yield return new WaitForSeconds(1);
        StopCoroutine("DoSomething");
    }

    IEnumerator DoSomething()
    {
        while (true)
        {

            print("DoSomething Loop");
            yield return null;
        }
    }*/
}

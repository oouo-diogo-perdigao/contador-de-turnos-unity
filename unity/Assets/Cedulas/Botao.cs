using UnityEngine;
using System.Collections;

public class Botao : MonoBehaviour {

    public GameObject conteudo;

    public void Ativar()
    {
        Debug.Log("Ativar");
        conteudo.SetActive(true);
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("asd");
        }
    }

}

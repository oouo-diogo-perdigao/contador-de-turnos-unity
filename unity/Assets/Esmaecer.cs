using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Esmaecer : MonoBehaviour {
    bool vai = true;
    public GameObject [] destruir;
    public Image logo;
    public Image fundo;
    public float logotela = 3f;
    // Use this for initialization
    void Awake()
    {
        logo.color = new Color(1f, 1f, 1f, 0f);
        InvokeRepeating("ilumina", 0.5f, 0.02f);
    }

    void ilumina()
    {
        if (vai)
        {
            if (logo.color.a <= 1)
            {
                logo.color = new Color(1f, 1f, 1f, logo.color.a + 0.01f);
            }
            else
            {
                logo.color = new Color(1f, 1f, 1f, 1f);
                vai = false;
            }
        }
        else
        {
            if (logotela<=0)
            {
                if (logo.color.a >= 0)
                {
                    logo.color = new Color(1f, 1f, 1f, logo.color.a - 0.02f);
                    fundo.color = logo.color;
                }
                else
                {
                    foreach (GameObject item in destruir)
                    {
                        Destroy(item);
                    }
                }
            }
            else
            {
                logotela -= Time.deltaTime;
            }
        }
    }
}

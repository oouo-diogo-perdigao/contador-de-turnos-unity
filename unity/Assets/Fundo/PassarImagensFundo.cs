using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PassarImagensFundo : MonoBehaviour
{
    public Sprite[] fundos;
    Image fundo;
    public float velocidade = 0.01f;
    public float offsetxMax = 0.6f;

    int indice = 0;
    float offsetx = 0f;
    bool indo = true;
    Material material;

	// Use this for initialization
	void Start () {
        fundo = GetComponent<Image>();
        material = fundo.material;
	}
	
	// Update is called once per frame
	void Update () {
        offsetx += (indo ? 1f : -1f) * velocidade * Time.deltaTime;
        indo = trocar();
        material.mainTextureOffset = new Vector2(offsetx, 0f);
        //Debug.Log(velocidade + " " + offsetx);
	}

    bool trocar()
    {
        if (indo && offsetx > offsetxMax)
        {
            fundo.sprite = fundos[indice + 1 < fundos.Length ? ++indice : indice = 0];
            return false;
        }
        else if (!indo && offsetx <= 0)
        {
            fundo.sprite = fundos[indice + 1 < fundos.Length ? ++indice : indice = 0];
            return true;
        }
        else {
            return indo;
        }
    }
}

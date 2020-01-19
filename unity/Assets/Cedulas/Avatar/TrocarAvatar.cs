using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TrocarAvatar : MonoBehaviour {
    private static int cont = 0;
    private static List<TrocarAvatar> presentes = new List<TrocarAvatar>();

    public Sprite[] avatares;

    Image avatar;
    private int meuAvatar = 0;
	// Use this for initialization
	void Start () {
        avatar = GetComponent<Image>();
        presentes.Add(this);
        meuAvatar = AvatarLiberado();
        avatar.sprite = avatares[meuAvatar];
	}
	
    int AvatarLiberado()
    {
        for (int i = 0; i < avatares.Length; i++)
        {
            if (!verificarAvatar(i))
            {
                return i;
            }
        }
        return avatares.Length - 1;
    }

    /// <summary>
    /// Retorna se o avatar existe
    /// </summary>
    /// <param name="numero">nemero de avatar</param>
    /// <returns>Se existe</returns>
    bool verificarAvatar(int numero)
    {
        bool exist = false;
        for (int j = 0; j < presentes.Count && !exist; j++)
        {
            if (presentes[j].meuAvatar == numero && presentes[j] != this)
            {
                exist = true;
            }
        }
        return exist;
    }

    public void Direita()
    {
        bool trocado = false;
        while (!trocado)
        {
            if (meuAvatar+1 < avatares.Length)
            {
                meuAvatar++;
                if (!verificarAvatar(meuAvatar))
                {
                    trocado = true;
                }
            }
            else
            {
                meuAvatar = 0;
                if (!verificarAvatar(meuAvatar))
                {
                    trocado = true;
                }
            }
        }
        avatar.sprite = avatares[meuAvatar];
    }

    public void Esquerda()
    {
        bool trocado = false;
        while (!trocado)
        {
            if (meuAvatar - 1 < avatares.Length)
            {
                meuAvatar--;
                if (!verificarAvatar(meuAvatar))
                {
                    trocado = true;

                }
            }
            else
            {
                meuAvatar = 0;
            }
        }
        avatar.sprite = avatares[meuAvatar];
    }
}

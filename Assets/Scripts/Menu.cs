using System.Collections;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject jogo;

    public TextMeshProUGUI textoInicial;

    bool iniciado;
    float letterAnimOpacity = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        

    }

    //IEnumerator LetterAnim()
    //{
    //    float tempo = 0f;
    //    float duracao = 2f;
    //    bool voltando = false;

    //    while (!iniciado)
    //    {
    //        tempo += Time.deltaTime / duracao;
    //        float t = Mathf.SmoothStep(0f, 1f, tempo);

    //        if (!voltando)
    //        {
    //            float opacity = Mathf.Lerp(0f, 1f, t);
    //            Color c = textoInicial.color;
    //            c.a = opacity;
    //            textoInicial.color = c;

    //            if (tempo >= 1f)
    //            {
    //                tempo = 0f;
    //                voltando = true;
    //                yield return new WaitForSeconds(1f);
    //            }
    //        }
    //        else
    //        {
    //            float opacity = Mathf.Lerp(1f, 0f, t);
    //            Color c = textoInicial.color;
    //            c.a = opacity;
    //            textoInicial.color = c;

    //            if (tempo >= 1f)
    //            {
    //                tempo = 0f;
    //                voltando = false;
    //            }
    //        }

            
    //    }

    //}

    void StartGame()
    {

    }



    

}

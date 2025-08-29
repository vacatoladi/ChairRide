using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject jogo;

    public TextMeshProUGUI textoInicial;

    bool iniciado;

    private void Update()
    {
        bool isTouching = Input.touchCount > 0 &&
                         Input.GetTouch(0).phase != TouchPhase.Ended &&
                         Input.GetTouch(0).phase != TouchPhase.Canceled;

        if (isTouching)
        {
            
            iniciado = true;

        }

        if (!iniciado)
        {
            //LetterAnim();
        }
    }

    void LetterAnim()
    {
        float a = 0;
        textoInicial.color = new Color(0f, 0f, 0f, 0.5f);
    }

    void StartGame()
    {

    }



    

}

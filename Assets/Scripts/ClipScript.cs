using UnityEngine;

public class ClipScript : MonoBehaviour
{
    float duracao = 2f;
    float tempo = 0f;
    bool voltando = false;
    Quaternion rotacaoInicial;


    void Start()
    {
        rotacaoInicial = transform.rotation;
    }

    void Update()
    {
        tempo += Time.deltaTime / duracao;

        float t = Mathf.SmoothStep(0f, 1f, tempo);

        if (!voltando)
        {
            float angulo = Mathf.Lerp(0f, 360f, t);
            transform.rotation = rotacaoInicial * Quaternion.Euler(0f, angulo, 0f);

            if (tempo >= 1f)
            {
                tempo = 0f;
                voltando = true;
            }
        }
        else
        {
            float angulo = Mathf.Lerp(360f, 0f, t);
            transform.rotation = rotacaoInicial * Quaternion.Euler(0f, angulo, 0f);

            if (tempo >= 1f)
            {
                tempo = 0f;
                voltando = false;
            }
        }
    }

}

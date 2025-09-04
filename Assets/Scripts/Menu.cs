using System.Collections;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    
    public GameObject game;
    public GameObject jogo;

    public TextMeshProUGUI textoInicial;

    public bool restarted;
    bool iniciado;
    Coroutine c;
    float letterAnimOpacity = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        

    }

    public void GameTime(float f)
    {
        Time.timeScale = f;
    }

    public void StartGame()
    {
        game = Instantiate(jogo);
    }

    public void RestartGame()
    {
        if (c != null) { c = null; }
        c = StartCoroutine(Reiniciate());
        Destroy(game);
        
        //game = Instantiate(jogo);
    }

    IEnumerator Reiniciate()
    {
        Destroy(game);
        restarted = true;
        yield return new WaitForSeconds(1f);
        game = Instantiate(jogo);
        restarted = false;
    }



}

using System.Collections;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] ButtonPressed bP;

    int metersHighScore = 0;

    public GameObject menuInGame;
    public GameObject menuGameOver;

    public TextMeshProUGUI clipsCollectedOnGame;
    public TextMeshProUGUI metersWalkedOnGame;

    public TextMeshProUGUI metersHighScoreGameOverText;
    public TextMeshProUGUI metersWalkedGameOverText;
    public GameObject newHighScoreGameOver;

    public TextMeshProUGUI[] posClips;

    public TextMeshProUGUI[] graphicsText;

    public GameObject game;
    public GameObject jogo;

    public TextMeshProUGUI textoInicial;

    public bool restarted;
    bool iniciado;
    Coroutine c;

    int graphics;

    public void GameTime(float f)
    {
        Time.timeScale = f;
    }

    public void StartGame()
    {
        game = Instantiate(jogo);
        SpawnControll sC = game.GetComponentInChildren<SpawnControll>();
        sC.menu = this;
        restarted = false;
        bP.FindPlayer();
    }

    public void CancelGame()
    {
        Destroy(game);
        restarted = true;
    }

    public void RestartGame()
    {
        if (c != null) { c = null; }
        c = StartCoroutine(Reiniciate());
    }


    IEnumerator Reiniciate()
    {
        Destroy(game);
        restarted = true;
        yield return new WaitForSeconds(1f);
        StartGame();
    }

    public void ChangeGraphics()
    {
        string s = "";
        switch (graphics)
        {
            case 0:
                graphics = 1;
                s = "Mid";
                break;
            case 1:
                graphics = 2;
                s = "High";
                break;
            case 2:
                graphics = 0;
                s = "Low";
                break;
        }

        foreach (TextMeshProUGUI t in graphicsText)
        {
            t.text = s;
        }
    }


    public void Deactivate(int iM, int iC)
    {
        if(iM > metersHighScore)
        {
            metersHighScore = iM;
            newHighScoreGameOver.SetActive(true);
        }
        metersHighScoreGameOverText.text = metersHighScore.ToString()+"m";
        metersWalkedGameOverText.text = iM.ToString() + "m";

        menuInGame.SetActive(false);
        menuGameOver.SetActive(true);
        restarted = true;
    }
    public void RefreshInGameUI(float f, int i)
    {
        metersWalkedOnGame.text = ((int)f).ToString() + "m";
        clipsCollectedOnGame.text = i.ToString();
    }
}

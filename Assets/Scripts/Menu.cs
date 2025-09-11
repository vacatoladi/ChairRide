using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//using System.Linq;

public class Menu : MonoBehaviour
{
    [SerializeField] ButtonPressed bP;

    int dailyMissionChanges = 1;
    int metersHighScore = 0;
    int coins = 0;

    public MissionsHandler missionsHandler;

    public MissionDataScript missionData;
    int[] excludeItens = new int[3];

    public TextMeshProUGUI[] missionsTextMm = new TextMeshProUGUI[3];
    public TextMeshProUGUI[] missionsTextPm = new TextMeshProUGUI[3];
    public TextMeshProUGUI[] missionsTextDm = new TextMeshProUGUI[3];

    public Button[] collectMissionButton = new Button[3];
    public GameObject[] completedMissionMarker = new GameObject[3];
    int[] missionsCoinsToEarn = new int[3];

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

    bool isFirstTimePlaying = true;

    public void GameTime(float f)
    {
        Time.timeScale = f;
    }

    public void StartGame()
    {
        if (isFirstTimePlaying)
        {
            
        }
        game = Instantiate(jogo);
        SpawnControll sC = game.GetComponentInChildren<SpawnControll>();
        PlayerScripts pS = game.GetComponentInChildren<PlayerScripts>();
        pS.missionsHandler = missionsHandler;
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

    void Change(int i)
    {
        int selectedNum;
        do
        {
            selectedNum = Random.Range(0, missionData.Missions.Length);
        } while (selectedNum == excludeItens[0]|| selectedNum == excludeItens[1] || selectedNum == excludeItens[2]);
        excludeItens[i] = selectedNum;
        missionsTextMm[i].text = missionsTextPm[i].text = missionsTextDm[i].text = missionData.Missions[selectedNum].Mission;
        missionsCoinsToEarn[i] = missionData.Missions[i].Value;
    }

    public void BeatMission(int i)
    {
        int index = System.Array.IndexOf(excludeItens, i);

        collectMissionButton[index].interactable = true;
    }

    public void ReceiveMissionReward(int i)
    {
        coins += missionsCoinsToEarn[i];
        missionsCoinsToEarn[i] = 0;
        Change(i);
    }

    public void DailyChangeMission(int i)
    {
        if(dailyMissionChanges >= 1)
        {
            dailyMissionChanges--;
            Change(i);
        }
    }

}

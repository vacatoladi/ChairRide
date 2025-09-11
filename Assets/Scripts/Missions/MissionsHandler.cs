using UnityEngine;

public class MissionsHandler : MonoBehaviour
{
    public Menu menu;

    public int[] activeMissionsIds = new int[3];

    bool[] activeMissions = new bool[5];

    //variaveis de miss�es por partida (v�o zerar logo depois de acabar a partida)
    int metersPerRoundMission;
    int coinsPerRoundMission;
    int obstaclesPerRoundMission;
    int boostPerRoundMission;

    //variaveis de miss�es continuas (ser�o salvas sempre que ouver uma altera��o e se manter�o mesmo saindo do jogo)
    int metersContinuousMission;
    int coinsContinuousMission;
    int obstaclesContinuousMission;
    int boostContinuousMission;

    //variaveis de miss�es OnRun (se manter�o salvas enquanto o player estiver no jogo, se ele sair o jogo apaga)
    int roundsPlayedOnRun;


    public void Checker()
    {
        if (activeMissions[0])
        {
            Mission01();
        }
        if (activeMissions[1])
        {
            Mission02();
        }
        if (activeMissions[2])
        {
            Mission03();
        }
        if (activeMissions[3])
        {
            Mission04();
        }
        if (activeMissions[4])
        {
            Mission05();
        }
    }

    // Percorra 500 metros em uma �nica partida.
    void Mission01()
    {
        if(metersPerRoundMission >= 500)
        {

        }
    }

    //Colete 1000 moedas no total.
    void Mission02()
    {
        if(coinsContinuousMission >= 1000)
        {

        }
    }

    //Jogue 3 partidas seguidas, independentemente da dist�ncia.
    void Mission03()
    {
        if(roundsPlayedOnRun >= 3)
        {

        }
    }

    //Passe por 10 obst�culos sem encostar em nenhum em uma partida.
    void Mission04()
    {
        if(obstaclesPerRoundMission >= 10)
        {

        }
    }

    //Pegue um boost duas vezes na partida.
    void Mission05()
    {
        if(boostPerRoundMission >= 1000)
        {

        }
    }
}

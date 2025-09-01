using UnityEngine;

public class InicialMenu : MonoBehaviour
{

    public GameObject mainMenu;


    public void StartGame()
    {
        mainMenu.SetActive(true);
        Destroy(this.gameObject);
    }
}

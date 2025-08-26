using UnityEngine;

public class PlayerScripts : MonoBehaviour
{

    public bool started = false;
    bool startedRN = true;

    public int clips;

    public float speed = 10;
    public float inicialSpeed;

    // quanto menor, maior o acrescimokkkk
    public float speedIncrease = 10f;

    void Start()
    {

    }

    void Update()
    {
        if (started)
        {
            OnGame();
        }
    }

    void OnGame()
    {
        if (startedRN)
        {
            startedRN = false;

            speed = inicialSpeed;
        }

        speed += Time.deltaTime / speedIncrease;
    }

    void GameOver()
    {
        started = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Clip"))
        {
            clips++;
            Destroy(other.gameObject);
        }
    }
}

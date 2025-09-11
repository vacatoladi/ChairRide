using UnityEngine;
using UnityEngine.UI;


public class PlayerScripts : MonoBehaviour
{

    public bool isTouching;

    public Menu menu;
    public MissionsHandler missionsHandler;

    public GameObject jogo;

    public bool started = true;
    bool startedRN = true;
    bool boosted = false;

    int healthPoints = 1;
    // moedas recebidas na partida
    public int clips;
    public float meters;

    public float thrust = 20f;       // For�a para subir
    public float maxVelocity = 14f;  // Velocidade m�xima para cima
    private Rigidbody2D rb;



    //CENARIO
    public float speed;
    public float inicialSpeed = 5f;
    // quanto menor, maior o acrescimokkkk
    public float speedIncrease = 10f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    

    void Update()
    {
        if (started)
        {
            OnGame();
        }

        if (isTouching)
        {
            // Se estiver tocando, aplica for�a para subir
            if (rb.linearVelocity.y < maxVelocity)
            {
                rb.AddForce(Vector2.up * thrust, ForceMode2D.Force);
            }
        }
    }

    void OnGame()
    {
        if (startedRN)
        {
            startedRN = false;

            speed = inicialSpeed;
        }
        if (speed < 10f)
        {
            speed += Time.deltaTime / speedIncrease;
        }
        else if (speed < 15f)
        {
            speed += Time.deltaTime / speedIncrease / 2;
        }
        else if (speed < 20f)
        {
            speed += Time.deltaTime / speedIncrease / 3.5f;
        }


        meters += Time.deltaTime * speed / 2;

        menu.RefreshInGameUI(meters, clips);
    }

    public void Damage()
    {
        if (!boosted)
        {
            healthPoints--;
        }
        else
        {
            boosted = false;
        }

        if (healthPoints <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        started = false;
        isTouching = false;
        menu.Deactivate((int)meters, clips);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Clip"))
        {
            clips++;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Zap"))
        {
            Damage();
        }
    }
}

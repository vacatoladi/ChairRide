using UnityEngine;

public class PlayerScripts : MonoBehaviour
{

    public GameObject Jogo;

    public bool started = true;
    bool startedRN = true;
    bool boosted = false;

    int healthPoints = 1;
    // moedas recebidas na partida
    public int clips;

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

        bool isTouching = Input.touchCount > 0 &&
                         Input.GetTouch(0).phase != TouchPhase.Ended &&
                         Input.GetTouch(0).phase != TouchPhase.Canceled;

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

        speed += Time.deltaTime / speedIncrease;
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

        if (healthPoints == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        started = false;

        Destroy(Jogo, 5f);
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

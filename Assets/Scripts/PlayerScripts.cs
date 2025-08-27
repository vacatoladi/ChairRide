using UnityEngine;

public class PlayerScripts : MonoBehaviour
{


    public bool started = false;
    bool startedRN = true;

    // moedas recebidas na partida
    public int clips;

    public float thrust = 20f;       // For�a para subir
    public float maxVelocity = 14f;  // Velocidade m�xima para cima
    private Rigidbody2D rb;


    //CENARIO
    public float speed = 10f;
    public float inicialSpeed;
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

        //Touch toque = Input.GetTouch(0);

        //switch (toque.phase)
        //{
        //    case TouchPhase.Began:

        //        break;

        //    case TouchPhase.Ended:

        //        break;
        //}

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

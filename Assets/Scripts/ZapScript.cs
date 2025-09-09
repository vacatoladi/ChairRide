using UnityEngine;

public class ZapScript : MonoBehaviour
{
    // variaveis do timer para decidir em que momento essa anima��o come�a
    public float timerUntilStartAnim;
    float time = 0f;

    // variaveis para anima��o
    Animator animator;
    public float velocidade = 1f;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0f;
    }
    
    void Update()
    {
      
        if (time >= timerUntilStartAnim)
        {
            animator.speed = velocidade;
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}

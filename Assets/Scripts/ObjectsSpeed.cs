using UnityEngine;

public class ObjectsSpeed : MonoBehaviour
{
    public Menu menu;

    public PlayerScripts pS;
    float lifeTime = 5;
    [SerializeField] float v;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (!menu.restarted)
        {
            v = -pS.speed;
            transform.position += transform.right * -pS.speed * Time.deltaTime;
        }
        else
        {
            Destroy (gameObject);
        }
    }
}

using System.Collections;
using UnityEngine;

public class SpawnControll : MonoBehaviour
{

    public GameObject[] prefabs;

    public PlayerScripts pS;

    public bool stillSpawning;

    Coroutine spawn;

    void Start()
    {
        StartSpawn();
    }

    void StartSpawn()
    {
        if (spawn != null) { spawn = null; }
        spawn = StartCoroutine(Spawn());

    }

    IEnumerator Spawn()
    {
        stillSpawning = true;
        while (stillSpawning)
        {
            yield return new WaitForSeconds(3f);
            int numero = Random.Range(0, prefabs.Length);
            GameObject novo = Instantiate(prefabs[numero], transform.position, Quaternion.identity);
            ObjectsSpeed oS = novo.GetComponent<ObjectsSpeed>();
            oS.pS = pS;
        }
    }



}

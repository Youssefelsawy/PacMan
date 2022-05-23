using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private Enemy gamer;
    public GameObject[] PowerUps;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("powerUps", 3, 5);
        gamer = GameObject.Find("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void powerUps()
    {
        float xpos = Random.Range(-9.5f, 9.5f);
        float zpos = Random.Range(-9.5f, 9.5f);
        int index = Random.Range(0,2);
        if (!gamer.hit)
        {
            Instantiate(PowerUps[index], new Vector3(xpos, 0.53f, zpos), PowerUps[index].transform.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public bool hit;
    private PlayerControl Player;
    public GameObject player;
    public GameObject gameOver;
    public GameObject scoreBar;
    public GameObject restartButton;
    //private Vector3 speed = new Vector3(10, 0, 10);
    public Transform moveDestination;
    private NavMeshAgent navMeshAgent;


    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    private void Update()
    {
        navMeshAgent.destination = moveDestination.position;
        if (Player.WrongPowerUp)
        {
            navMeshAgent.speed = 10;
        }
        else
        {
            navMeshAgent.speed = 5;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            hit = true;
            gameOver.SetActive(true);
            scoreBar.SetActive(true);
            restartButton.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

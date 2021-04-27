using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    public float playerHeight;
    public float speed;
    public Transform[] spawnPoints;
    public Transform center;
    public GameObject obstaclePrefab;
    public float timeBetweenSpawns;
    public Text playerHeightText;
    private float counter;
    private int maxWidth;

    // Start is called before the first frame update
    void Start()
    {
        maxWidth = spawnPoints.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //Atribui valor a variável de altura do jogador.
        playerHeight = transform.position.y;
        playerHeightText.text = "Altura alcançada: " + Math.Round(playerHeight, 1) + " metros.";
        SpawnObstacle();
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, speed * Time.fixedDeltaTime, 0);
    }

    void SpawnObstacle() {
        if(counter < timeBetweenSpawns) {
            counter += Time.deltaTime;
        }
        else {
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPoints[SortSpawnPoint()].position, Quaternion.identity, center);
            counter = 0;
        }
    }

    /// <summary>
    /// Randomiza uma posiçao entre o vetor de transforms.
    /// </summary>
    /// <returns>Returns a random integer between 0 and the number of positions inside the spawn points array.</returns>
    int SortSpawnPoint() {
        int _ret = UnityEngine.Random.Range(0, maxWidth);
        return _ret;
    }
}

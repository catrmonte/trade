using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rig;

    private float startTime;
    private float timeTaken;

    private int score;
    public int maxCollectables = 9;

    private bool isPlaying;

    public GameObject playButton;
    public TextMeshProUGUI curScoreText;
    public TextMeshProUGUI curTimeText;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isPlaying)
            return;

        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;

        rig.velocity = new Vector3(x, rig.velocity.y, z);

        timeTaken = Time.time - startTime;

        if (timeTaken > 10)
        {
            End();
        }

        curTimeText.text = (10 - timeTaken).ToString("F2");

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);

            score += 10;

            curScoreText.text = score.ToString();

            pointSpawner.instance.SpawnOrb();
        }
    }

    public void Begin()
    {
        startTime = Time.time;
        isPlaying = true;

        playButton.SetActive(false);
    }

    void End()
    {
        timeTaken = Time.time - startTime;
        isPlaying = false;

        playButton.SetActive(true);
        Leaderboard.instance.SetLeaderboardEntry(-(score+1000));
    }
}

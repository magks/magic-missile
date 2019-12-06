using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBoss : MonoBehaviour
{
    public Transform enemyLocation;
    public ActiveBoxTuner activeAreaTuner;
    public PlayerShoot shoot;
    public PlayerMovement move;
    GameObject playerCam;
    GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        activeAreaTuner.enabled = false;
    }
    void Start()
    {
        shoot.enabled = false;
        move.enabled = false;
        playerCam = Camera.main.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(focusBoss());
    }

    // Update is called once per frame
    IEnumerator focusBoss()
    {
        Vector3 bossPos = playerCam.transform.position;
        Vector3 originalPos = playerCam.transform.position;
        bossPos.y += 25;
        playerCam.transform.position = bossPos;

        float moveDistance = Vector3.Distance(bossPos, originalPos);
        float elapsedMove = 0;
        float moveTime = 1.5f;
        float stayTime = 3f;
        while(stayTime > 0)
        {
            stayTime -= Time.deltaTime;
            yield return null;
        }
        while(playerCam.transform.position != originalPos)
        {
            elapsedMove += Time.deltaTime;
            float timeFraction = elapsedMove / moveTime;
            playerCam.transform.position = Vector3.Lerp(bossPos, originalPos, timeFraction);
            yield return null;
        }
        activeAreaTuner.enabled = true;
        shoot.enabled = true;
        move.enabled = true;
    }
}

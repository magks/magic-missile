using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject playerObj;
    [SerializeField]
    GameObject[] barObjects;
    Player playerStatus;
    int hp_state;
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = playerObj.GetComponent<Player>();
        hp_state = 3;
        barObjects[hp_state].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(hp_state != playerStatus.Health)
        {
            barObjects[hp_state].SetActive(false);
            hp_state = playerStatus.Health;
            barObjects[hp_state].SetActive(true);
        }
    }
}

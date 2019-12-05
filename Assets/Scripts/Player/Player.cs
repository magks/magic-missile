using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHP;
    public int Health
    {
        get { return _curHealth; }
        set
        {
            if (value > 3)
            {
                _curHealth = 3;
            }
            else if(value < 0)
            {
                _curHealth = 0;
            }
            else
            {
                _curHealth = value;
            }
        }
    }
    private int _curHealth;

    // Start is called before the first frame update
    void Start()
    {
        _curHealth = maxHP;
    }

    void Die()
    {
        //SceneManager.LoadScene()
        Camera.main.transform.SetParent(null, true);
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
    }

    // Update is called once per frame
    void Update()
    {
        print(_curHealth);
       if(_curHealth==0)
        {
            Die();
        }
    }
}

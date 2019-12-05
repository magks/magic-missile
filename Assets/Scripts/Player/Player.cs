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
    [SerializeField]
    private GameObject deathScreen;
    [SerializeField]
    private GameObject playerSprite;

    private PlayerAudio audioplayer;
    private int _curHealth;
    bool dead;
    // Start is called before the first frame update
    void Start()
    {
        audioplayer = GetComponent<PlayerAudio>();
        _curHealth = maxHP;
        dead = false;
    }

    IEnumerator FadeToBlack()
    {
        SpriteRenderer screen = deathScreen.GetComponent<SpriteRenderer>();
        SpriteRenderer sprite = playerSprite.GetComponent<SpriteRenderer>();
        Color scrnColor = screen.color;
        Color playColor = sprite.color;
        float opacity = 0;
        float fadeSeconds = 4;
        float timeLeft = 0;
        while (opacity != 1)
        {
            yield return null;
            timeLeft += Time.deltaTime;
            opacity = Mathf.Min(1, timeLeft / fadeSeconds);
            scrnColor.a = opacity;
            playColor.a = 1 - opacity;
            screen.color = scrnColor;
            sprite.color = playColor;
        }
        SceneManager.LoadScene("DeathScreen");
    }

    void Die()
    {
        //SceneManager.LoadScene()
        audioplayer.DeathSound();
        Camera.main.transform.SetParent(null, true);
        dead = true;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Shoot>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        StartCoroutine(FadeToBlack());
        deathScreen.transform.SetParent(null, true);
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
    }

    // Update is called once per frame
    void Update()
    {
       if(_curHealth==0 && !dead)
        {
            Die();
        }
    }
}

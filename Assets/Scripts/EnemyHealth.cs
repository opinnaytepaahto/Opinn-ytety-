using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public float maxHealth = 50f;
    public float currentHealth = 0f;

    private float timer = 3f;

    private bool firstDestroy = true;

    public GameObject healthBar;
    public GameObject scoreText;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;

        // InvokeRepeating("decreaseHealth", 1f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (currentHealth <= 0)
        {
            if (firstDestroy)
            {
                GameObject.Find("Spaceman").GetComponent<PlayerController>().score += 10;
                scoreText.GetComponent<Text>().text = "Score: " + GameObject.Find("Spaceman").GetComponent<PlayerController>().score;

                transform.GetChild(1).GetComponent<AudioSource>().Play();

                GetComponent<Rigidbody2D>().isKinematic = true;
                Destroy(transform.GetChild(0).gameObject);
                Destroy(GetComponent<BoxCollider2D>());

                firstDestroy = false;
            }

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Destroy(gameObject);
                Destroy(this);
            }
        }
	}

    public void decreaseHealth(float amount)
    {
        currentHealth -= amount;

        float tempHealth = currentHealth / maxHealth;
        setHealthBar(tempHealth);
    }

    public void setHealthBar(float health)
    {
        healthBar.transform.localScale = new Vector2(Mathf.Clamp(health, 0f, 1f), healthBar.transform.localScale.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public MyGameManager MyGameManager;

    SpriteRenderer mySprite;
    int score = 1;

    private void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }

    public void SetColor(float hue)
    {
        mySprite.color = Color.HSVToRGB(hue/360, 0.85f, 0.95f);
    }

    public void SetScore(int score)
    {
        this.score = score;
    }

    public int GetScore()
    {
        return score;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                MyGameManager.IncreaseScore(score);
                Destroy(gameObject);
                break;
        }
    }
}

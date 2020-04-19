using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyGameManager : MonoBehaviour
{
    [Header("general")]
    public Camera mainCamera;
    public PlayerMovement snakeHead;
    public List<Transform> snakeBody;

    [Header("Pickups Settings")]
    public GameObject[] pickUps;

    int pickupNumber;
    int GlobalScore = 0;
    float screenHight;
    float screenWidth;

    PickUpController currentPickup;
    Vector3 headLastPosition;
    //Coroutine infinitLoop;
    void Start()
    {
        screenHight = mainCamera.orthographicSize;
        screenWidth = mainCamera.aspect * screenHight;
        pickupNumber = pickUps.Length;
        GenerateRandomPickUp();
        //infinitLoop = StartCoroutine("timer");
    }

    private void FixedUpdate()
    {
        if (snakeHead.transform.position != headLastPosition)
        {
            snakeBody[snakeBody.Count - 1].transform.position = headLastPosition;
            snakeBody.Insert(0, snakeBody[snakeBody.Count - 1]);
            snakeBody.RemoveAt(snakeBody.Count - 1);
        }
    }

    //private void OnDestroy()
    //{
    //    StopCoroutine(infinitLoop);
    //}

    public Vector3 GetRandomPosition()
    {
        float randomx = UnityEngine.Random.Range(-screenWidth + 0.3f, screenWidth - 0.3f);
        float randomy = UnityEngine.Random.Range(-screenHight + 0.3f, screenHight - 0.3f);
        return new Vector3(randomx, randomy, 0);
    }

    public float GetRandomColor()
    {
        return UnityEngine.Random.Range(0, 360);
    }

    public void GenerateRandomPickUp()
    {
        var randomPickup = pickUps[UnityEngine.Random.Range(0, pickupNumber)];
        var randomPosition = GetRandomPosition();
        var randomColor = GetRandomColor();
        currentPickup = Instantiate(randomPickup, randomPosition,
            Quaternion.identity).GetComponent<PickUpController>();
        currentPickup.SetColor(randomColor);
        currentPickup.MyGameManager = this;
    }

    public void IncreaseScore(int amount)
    {
        GlobalScore += amount;
        GenerateRandomPickUp();
    }

    //IEnumerator timer()
    //{
    //    var delay = new WaitForSeconds(4f);
    //    while (true)
    //    {
    //        yield return delay;
    //        GenerateRandomPickUp();
    //    }
    //}
}

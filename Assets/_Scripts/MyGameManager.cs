using UnityEngine;
using System.Collections;

public class MyGameManager : MonoBehaviour
{
    [Header("general")]
    public Camera mainCamera;

    [Header("Pickups Settings")]
    public GameObject[] pickUps;

    int pickupNumber;
    int GlobalScore = 0;
    float screenHight;
    float screenWidth;

    PickUpController currentPickup;
    //Coroutine infinitLoop;
    void Start()
    {
        screenHight = mainCamera.orthographicSize;
        screenWidth = mainCamera.aspect * screenHight;
        pickupNumber = pickUps.Length;
        GenerateRandomPickUp();
        //infinitLoop = StartCoroutine("timer");
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

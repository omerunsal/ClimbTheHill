using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public List<GameObject> carList = new List<GameObject>();
    public List<Vector3> bounceAngleList = new List<Vector3>();
    public List<Transform> bouncePositionList = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawnCars());
    }

    IEnumerator StartSpawnCars()
    {
        for (int i = 0; i < 5; i++)
        {
            

            int randomIndexForCar = Random.Range(0, 3);
            int randomIndexForAngle = Random.Range(0, 3);
            int randomIndexForPosition = Random.Range(0, 3);

            Instantiate(carList[randomIndexForCar], bouncePositionList[randomIndexForPosition].position,
                Quaternion.Euler(bounceAngleList[randomIndexForAngle])
            );
            yield return new WaitForSeconds(2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    int randomNum_1;
    int randomNum_2;

    [SerializeField]
    public Transform boardParent;

    Transform Tile1;
    Transform Tile2;

    [SerializeField]
    public GameObject powerUp_prefab;

    List<Transform> TileList = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        randomNum_1 = Random.Range(1,47);
        randomNum_2 = Random.Range(1,47);


        Tile1 = boardParent.GetChild(randomNum_1);
        Tile2 = boardParent.GetChild(randomNum_2);

        TileList.Add(Tile1);
        TileList.Add(Tile2);

        for (int i = 0; i < 2; i++)
        {

            Instantiate(powerUp_prefab, TileList[i].position, TileList[i].rotation, this.transform);
            this.transform.GetChild(i).gameObject.SetActive(true);
            Debug.Log("Instantiation code");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    int randomNum_1;
    int randomNum_2;

    [SerializeField]
    public Transform boardParent; //reference to the parent of the tiles

    Transform Tile1;
    Transform Tile2;

    [SerializeField]
    public GameObject powerUp_prefab;

    List<Transform> TileList = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        //finds a random number from the list of tiles (excluding the first and last. Lists start at 0 so the tiles would be 0-48).
        randomNum_1 = Random.Range(1,47); 
        randomNum_2 = Random.Range(1,47);


        //Sets a reference to the randmo tile we found using random.range
        Tile1 = boardParent.GetChild(randomNum_1); 
        Tile2 = boardParent.GetChild(randomNum_2);

        //Added it to a list so I can loop through it using a for loop.
        TileList.Add(Tile1); 
        TileList.Add(Tile2);

        for (int i = 0; i < 2; i++) // you can say i<TileList.Count instead of 2.
        {
            //Using the list infor to get position
            //I parented it to the object this script is attached to so I would be able to set the object active as I deactivated it in the scene.
            //That step (and the one setting the children active) wouldn't be necessary if you use an actual power up prefab.
            Instantiate(powerUp_prefab, TileList[i].position, TileList[i].rotation, this.transform);


            this.transform.GetChild(i).gameObject.SetActive(true);
            Debug.Log("Instantiation code"); //checking
            Debug.Log(i);
        }
    }

    private void Update()
    {

    }
}

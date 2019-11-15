using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClass : MonoBehaviour
{

    public GameObject bladeMaster;
    public GameObject Ranger;
    public GameObject Gunslinger;
    public Transform objectToMove;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

    }

    public void spawnBlademaster()
    {
        Debug.Log("Spawning bladeMaster");
        Instantiate(bladeMaster, new Vector3(0, 1, 0), Quaternion.identity);

    }

    public void spawnGunslinger()
    {
        Debug.Log("Spawning gunslinger");
        Instantiate(Gunslinger, new Vector3(0, 1, 0), Quaternion.identity);

    }

    public void spawnRanger()
    {
        Debug.Log("Spawning ranger");
        Instantiate(Ranger, new Vector3(0, 1, 0), Quaternion.identity);

    }

}

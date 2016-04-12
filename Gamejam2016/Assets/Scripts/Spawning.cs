using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {


    [SerializeField]
    GameObject[] stageCollection;

    Transform spawnLocation;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Relatie");

        if (other.gameObject.tag == "SpawnTrigger")
        {
            spawnLocation = other.gameObject.transform.parent.Find("Spawnlocation");

            GameObject obj = Instantiate(stageCollection[Random.Range(0, stageCollection.Length)], spawnLocation.position, Quaternion.identity) as GameObject;

            obj.name = "SpawnedStage";

            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "DeleteObject")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}

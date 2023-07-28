using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDoor : MonoBehaviour
{
    public GameObject environmentBuildings;
    public GameObject exteriorBlack;
    public GameObject interiorBackground;
    public GameObject interiorForeground;

    [Header("Objects and NPCs")]
    public GameObject[] buildingObjects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Seems like this object is colliding with the environment colliders and trying to read a null parent throws and error
        // Just putting this verification to avoid getting scared by null reference errors xD
        if (collision.transform.parent != null) 
        {
            if (collision.transform.parent.CompareTag("Player"))
            {
                environmentBuildings.SetActive(false);
                exteriorBlack.SetActive(true);
                interiorBackground.SetActive(true);
                interiorForeground.SetActive(true);
            }
            foreach (GameObject obj in buildingObjects)
            {
                obj.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent != null)
        {
            if (collision.transform.parent.CompareTag("Player"))
            {
                environmentBuildings.SetActive(true);
                exteriorBlack.SetActive(false);
                interiorBackground.SetActive(false);
                interiorForeground.SetActive(false);
            }
            foreach (GameObject obj in buildingObjects)
            {
                obj.SetActive(true);
            }
        }
    }


}

using UnityEngine;
using UnityEngine.InputSystem;

public class spawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    private int playerCount = 0;
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.transform.position = spawnPoints[playerCount].transform.position;
        playerCount++;
        playerInput.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
    }
}

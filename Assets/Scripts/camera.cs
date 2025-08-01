using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private Transform player;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

}


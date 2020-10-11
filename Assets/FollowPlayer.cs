using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    private void Start() {
        offset = player.position - transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position - offset;
    }
}

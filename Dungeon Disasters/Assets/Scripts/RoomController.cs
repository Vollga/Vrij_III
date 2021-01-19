using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject tileGroup;
    public bool _isStartRoom;
    // Start is called before the first frame update

    private void Awake()
    {
        if (!_isStartRoom)
        {
            tileGroup.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tileGroup.SetActive(true);
            print("Enabled Room");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tileGroup.SetActive(false);
            print("Disabled Room");
        }
    }
}

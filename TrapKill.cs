using UnityEngine;

public class TrapKill : MonoBehaviour
{
    public GameObject Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (Player)
        {
            //GameObject.Destroy(Player);
            //Player.SetActive(false);
            Debug.Log("You Dead");
        }


        else if (other.gameObject.tag == "untagged")
        {
            Debug.Log("nada");
        }
    }

}

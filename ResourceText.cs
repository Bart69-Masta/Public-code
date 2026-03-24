using TMPro;
using UnityEngine;

public class ResourceText : MonoBehaviour
{
    // The current resource amount
    public int GoldAmount = 0;
    public int GoldGain = 1;

    // Reference to the UI Text component that shows the amount
    public TextMeshProUGUI GoldText;

    void Start()
    {
        UpdateResourceUI();
    }

    void Update()
    {
        UpdateResourceUI();
    }

    public void GoldGains()
    {
        AddGold(GoldGain);
        Debug.Log("Goldgains");
    }

    // Method to add to the resource amount
    public void AddGold(int amount)
    {
        GoldAmount += GoldGain;
        Debug.Log("addgold");
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger on object: " + other.gameObject.name);

        if (other.gameObject.tag == "Gold")
        {
            Debug.Log("Gain Some gold");
            GoldGains();
        }

        else if (other.gameObject.tag == "untagged")
        {
            Debug.Log("nafda");
        }
    }

    // Method to update the UI text
    void UpdateResourceUI()
    {
        GoldText.text = "Gold: " + GoldAmount.ToString();
        Debug.Log("UI GOLD GAINED");
    }

}

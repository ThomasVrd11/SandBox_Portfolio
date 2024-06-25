using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public string interactMessage = "Press G to interact";
    public GameObject messagePrefab;
    private GameObject messageInstance;
    private Text messageText;
    private bool isPlayerNearby = false;
    private bool messageDisplayed = false;

    void Start()
    {
        if (messagePrefab != null)
        {
            messageInstance = Instantiate(messagePrefab, transform.position + Vector3.up * 2, Quaternion.identity, transform);
            messageText = messageInstance.GetComponentInChildren<Text>();
            messageText.text = "";
            messageInstance.SetActive(false);
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(DisplayMessage(interactMessage, 3f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (!messageDisplayed)
            {
                StartCoroutine(DisplayMessage(interactMessage, 3f));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
    // * Nico jv me tuer
    private IEnumerator DisplayMessage(string message, float delay)
    {
        if (messageText != null)
        {
            messageText.text = message;
            messageInstance.SetActive(true);
            messageDisplayed = true;
            yield return new WaitForSeconds(delay);
            messageInstance.SetActive(false);
            messageDisplayed = false;
        }
    }
}

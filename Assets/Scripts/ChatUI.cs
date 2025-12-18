using UnityEngine;
using Unity.Netcode;
using TMPro;
using System;
using UnityEngine.UI;
public class ChatUI : MonoBehaviour
{
    [Header("References")]
    public TMP_InputField inputField;
    public Transform content;
    public GameObject messagePrefab;

    [Header("Network")]
    public ChatNetwork chatNetwork; // Assign in inspector
    public string playerName = "Player";

    public void OnSendButton()
    {
        if (string.IsNullOrWhiteSpace(inputField.text)) return;

        // Send the message over the network
        chatNetwork.SendMessageFromClient(inputField.text, playerName);

        // Clear input
        inputField.text = "";
        inputField.ActivateInputField();
    }

    public void ReceiveMessage(string sender, string message, DateTime timestamp, Color color)
    {
        GameObject msg = Instantiate(messagePrefab, content);
        TMP_Text text = msg.GetComponent<TMP_Text>();
        text.text = $"{sender}: {message}\n<size=75%><color=#888>{timestamp:HH:mm}</color></size>";

        Image bg = msg.GetComponentInChildren<Image>();
        bg.color = color;

        Canvas.ForceUpdateCanvases();
    }
}

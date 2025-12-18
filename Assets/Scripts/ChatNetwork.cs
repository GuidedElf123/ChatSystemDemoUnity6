using Unity.Netcode;
using UnityEngine;
using System;
using System.Collections.Generic;

public class ChatNetwork : NetworkBehaviour
{
    public ChatUI chatUI;

    private Dictionary<string, Color> playerColors = new Dictionary<string, Color>();

    public void SendMessageFromClient(string message, string playerName)
    {
        if (string.IsNullOrWhiteSpace(message)) return;

        SendMessageServerRpc(playerName, message, DateTime.UtcNow.Ticks);
    }

    [ServerRpc(RequireOwnership = false)]
    void SendMessageServerRpc(string sender, string message, long ticks)
    {
        // Assign random color if first message from this player
        Color color;
        if (!playerColors.ContainsKey(sender))
        {
            color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 0.5f);
            playerColors[sender] = color;
        }
        else
        {
            color = playerColors[sender];
        }

        // Send color along with message
        SendMessageClientRpc(sender, message, ticks, color);
    }

    [ClientRpc]
    void SendMessageClientRpc(string sender, string message, long ticks, Color color)
    {
        DateTime time = new DateTime(ticks, DateTimeKind.Utc);
        chatUI.ReceiveMessage(sender, message, time, color);
    }
}

using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SyncVar]
    [SerializeField]
    private string diplayName = "Missing Name";

    [SyncVar]
    [SerializeField]
    Color color;

    [Server]
    public void setColor()
    {
        color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }


    [Server]
    public void SetDiplayName(string _newDisplayName)
    {
        diplayName = _newDisplayName;
    }
}

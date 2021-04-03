using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SyncVar(hook =nameof(HandleDisplayNameUpdate))]
    [SerializeField]
    private string diplayName = "Missing Name";

    [SyncVar(hook =nameof(HandleDisplayColourUpdate))]
    [SerializeField]
    Color color = Color.black;

   
    [SerializeField]
    private TMP_Text displayNameText = null;
    [SerializeField]
    private Renderer displayColoutRenderer = null;

    #region client

    private void HandleDisplayNameUpdate(string oldName,string newName)
    {
        displayNameText.text = newName;
    }

    private void HandleDisplayColourUpdate(Color oldColour, Color newColor)
    {
        displayColoutRenderer.material.SetColor("_BaseColor", newColor);
    }

    [ContextMenu("Set My Name")]
    public void SeyMyName()
    {
        CmdSetDisplayName("My new Name"); 
    }

    [ClientRpc]
    public void RpcSetNewName(string _newDisplayName)
    {
        Debug.Log(_newDisplayName);
    }

    #endregion

    #region Server

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


    [Command]
    private void CmdSetDisplayName(string _newDisplayName)
    {
        RpcSetNewName(_newDisplayName);

        SetDiplayName(_newDisplayName);
    }


    #endregion


}

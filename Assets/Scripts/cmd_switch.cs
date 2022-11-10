using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class cmd_switch : MonoBehaviour
{


    public SendLogs sendLogs;

#pragma warning disable CS0618 // Type or member is obsolete
    public def_network def_Network;
#pragma warning restore CS0618 // Type or member is obsolete
    //public Camera camera;
    public GameObject ui_cam;
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void input_module(string input)
    {
        switch (input)
        {
            case "help":
                sendLogs.SendLog("help -> Shows you list of commands.", false);
                sendLogs.SendLog("kill -> Kills the player.", false);
                sendLogs.SendLog("leave -> Stops host OR stops Client.", false);
                break;
            case "kill":
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    ui_cam.SetActive(true);
                    GameObject.Destroy(player);
                    sendLogs.SendLog(player.name + " has been killed.", false);
                }
                else
                {
                    sendLogs.SendLog("No player found.", false);
                    return;
                }
                break;
            case "leave":
                if(def_Network.amIhost)
                {
                    ui_cam.SetActive(true);
                    def_Network.stop_host();
                    sendLogs.SendLog("Manual host stop requested...", false);
                }
                else
                {
                    ui_cam.SetActive(true);
                    def_Network.stop_client();
                    sendLogs.SendLog("Manual client stop requested...", false);
                }
                break;
          

            default:
                sendLogs.SendLog("Invalid command! Write \"help\" for another commands.", false);
                break;
        }
    }
}

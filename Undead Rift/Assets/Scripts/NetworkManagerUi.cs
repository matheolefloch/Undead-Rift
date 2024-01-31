using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUi : MonoBehaviour
{
   
   [SerializeField] private Button ServerBT;
   [SerializeField] private Button HostBT;
   [SerializeField] private Button ClientBT;

   private void Awake() {
      ServerBT.onClick.AddListener(() => {
         NetworkManager.Singleton.StartServer();
      });
      HostBT.onClick.AddListener(() => {
         NetworkManager.Singleton.StartHost();
      });
      ClientBT.onClick.AddListener(() => {
         NetworkManager.Singleton.StartClient();
      });
       
   }

}

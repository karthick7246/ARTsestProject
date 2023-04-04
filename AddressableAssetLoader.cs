using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableAssetLoader : MonoBehaviour
{
  
    public AssetReference AssetReference,Idle,Walk;
    
   
    // Start is called before the first frame update
    void Start()
    {

       

        AssetReference.LoadAssetAsync<GameObject>().Completed += (asyncOperationHandle) =>
        {
            if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                print("test");
                Instantiate(asyncOperationHandle.Result);
            }
            else
            {
                Debug.Log("dhu");
            }
        };

       


    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  
        {
            print("Tab");
            Idle.LoadAssetAsync<AnimatorController >().Completed += (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    print(Idle.SubObjectName);
                    GameObject Player = GameObject.FindGameObjectWithTag("Player");
                    Animator  ani = Player.GetComponent<Animator>();
                    ani.runtimeAnimatorController = asyncOperationHandle.Result  as RuntimeAnimatorController;
                    //Instantiate(asyncOperationHandle.Result);

                }
                else
                {
                    Debug.Log("Er");
                }
            };
        }

        if (Input.GetMouseButtonDown(1))
        {
            print("Tab");
            Walk.LoadAssetAsync<AnimatorController>().Completed += (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                  //  print(Idle.SubObjectName);
                    GameObject Player = GameObject.FindGameObjectWithTag("Player");
                    Animator ani = Player.GetComponent<Animator>();
                    ani.runtimeAnimatorController = asyncOperationHandle.Result as RuntimeAnimatorController;
                    //Instantiate(asyncOperationHandle.Result);

                }
                else
                {
                    Debug.Log("ER");
                }
            };
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private WeaponController weaponController;
    public Transform mainCamera;
    private Animator animator;
    private PhotonView photonView;
    private Transform cameraTargetDummy;
    private float camaeraLookUpDownOffset;

    

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        // GetComponent<HUDManagerController>().hudManager.SetCharacterName("Murat");
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine) {
            mainCamera = Camera.main.transform;

            cameraTargetDummy = new GameObject("Camera Target Dummy").transform;
            cameraTargetDummy.SetParent(transform);

            cameraTargetDummy.localPosition = new Vector3(0, 2, 0);
        }
    }

    // Update is called once per frame
    void Update() {
        if (photonView.IsMine) {
            float hor = Input.GetAxis("Horizontal"); // A(-) ve D(+) tuslari
            float ver = Input.GetAxis("Vertical"); // S(-) ve W(+) tuslari
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;
            float fire = Input.GetAxis("Fire1");

            animator.SetFloat("horizontal", hor);
            animator.SetFloat("vertical", ver);
            transform.rotation *= Quaternion.Euler(new Vector3(0, mouseX * rotationSpeed, 0));
            if (mainCamera) {
                camaeraLookUpDownOffset += -mouseY;
                mainCamera.transform.rotation = Quaternion.LookRotation(cameraTargetDummy.position - mainCamera.transform.position, cameraTargetDummy.transform.up) * Quaternion.Euler(new Vector3(camaeraLookUpDownOffset * rotationSpeed, 0, 0));
                // mainCamera.transform.rotation *= Quaternion.Euler(new Vector3(-mouseY * rotationSpeed, 0, 0));
                mainCamera.transform.position = transform.position + (-transform.forward * 3f) + (transform.up * 2f);
            }

            if (fire>0) {
                weaponController.Fire();
                photonView.RPC("FireOnNetwork", RpcTarget.Others, photonView.ViewID);
            }
        }
    }


    public void UpdateUserNameOnOtherPlayers(string aUserName) {
        StartCoroutine(WaitUntilPhotonViewIsAssigned(aUserName));
    }

    private IEnumerator WaitUntilPhotonViewIsAssigned(string aUserName) {
        while (photonView==null) {
            yield return null;
        }
        photonView.RPC("UpdateUserNameOnNetwork", RpcTarget.OthersBuffered, aUserName, photonView.ViewID);
    }

    [PunRPC]
    public void UpdateUserNameOnNetwork(string aUserName, int aPlayerId) {
        PlayerController[] players = GameObject.FindObjectsOfType<PlayerController>();
        for (int i=0; i<players.Length; i++) {
            if (players[i].GetComponent<PhotonView>().ViewID == aPlayerId) {
                players[i].GetComponent<HUDManagerController>().hudManager.SetCharacterName(aUserName);
            }
        }
    }

    [PunRPC]
    public void FireOnNetwork(int aPlayerId) {
        PlayerController[] players = GameObject.FindObjectsOfType<PlayerController>();
        for (int i=0; i<players.Length; i++) {
            if (players[i].GetComponent<PhotonView>().ViewID == aPlayerId) {
                players[i].weaponController.Fire();
            }
        }
    }
}

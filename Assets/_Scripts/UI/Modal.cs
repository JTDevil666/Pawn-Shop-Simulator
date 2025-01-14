using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract partial class Modal : MonoBehaviour, IModal
{
    [Header("Base Modal")]
    [SerializeField] private Button CloseButton;

    public void Close()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        Singleton<FirstPersonController>.Instance.Unfreeze();
        Singleton<PlayerController>.Instance.openModal = null;
    }

    void Awake() {
        CloseButton.onClick.AddListener(() => {
            Close();
        });
    }

    void Update() {
        if(gameObject.activeSelf) {
            Draw();

            if(Input.GetKeyDown(KeyCode.Escape)) {
                Close();
            }
        }
    }

    public abstract void Draw();

    public void Open()
    {
        Cursor.lockState = CursorLockMode.Confined;
        gameObject.SetActive(true);
        Singleton<FirstPersonController>.Instance.Freeze();
        Singleton<PlayerController>.Instance.openModal = this;
    }
}

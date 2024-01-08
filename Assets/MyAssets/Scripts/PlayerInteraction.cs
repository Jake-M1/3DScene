using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject player;
    public Text colorChangeText;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
    private PlayerInput _playerInput;
#endif
    private StarterAssetsInputs _input;
    private bool inColorSwapTriggerBox = false;
    private PlayerShoot playerShoot;
    private Material curMat;

    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        _playerInput = GetComponent<PlayerInput>();
#endif
        playerShoot = player.GetComponent<PlayerShoot>();

        colorChangeText.enabled = false;
    }

    void Update()
    {
        if (inColorSwapTriggerBox && _input.interact)
        {
            _input.InteractInput(false);
            playerShoot.ColorChange(curMat);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ColorSwap"))
        {
            inColorSwapTriggerBox = true;
            _input.InteractInput(false);
            colorChangeText.enabled = true;
            curMat = other.gameObject.GetComponent<MeshRenderer>().material;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ColorSwap"))
        {
            inColorSwapTriggerBox = false;
            _input.InteractInput(false);
            colorChangeText.enabled = false;
        }
    }
}

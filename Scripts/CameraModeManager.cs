using UnityEngine;
using Cinemachine;
using System.Collections.Generic;

public class CameraModeManager : MonoBehaviour
{
    public Camera fpsCamera; // Caméra à la première personne
    public GameObject fpsController; // Contrôleur de la souris pour le mode FPS
    public List<CinemachineVirtualCamera> virtualCams; // Liste des caméras virtuelles (cinématique)
    public KeyCode switchKey = KeyCode.Tab; // Touche pour changer de mode caméra

    private bool isFirstPerson = false; // Indique si on est en vue à la première personne

    void Update()
    {
        // Si la touche définie est pressée, on change de mode de caméra
        if (Input.GetKeyDown(switchKey))
        {
            ToggleCameraMode();
        }
    }

    // Méthode pour basculer entre la vue à la 1re personne et les caméras cinématiques
    void ToggleCameraMode()
    {
        isFirstPerson = !isFirstPerson;

        if (isFirstPerson)
        {
            // Désactiver toutes les caméras virtuelles
            foreach (var vcam in virtualCams)
                vcam.Priority = 0;

            // Activer la caméra FPS
            fpsCamera.enabled = true;
            fpsController.SetActive(true); // Activer le contrôle souris
            Cursor.lockState = CursorLockMode.Locked; // Verrouiller le curseur
            Cursor.visible = false;
        }
        else
        {
            // Réactiver les caméras cinématiques
            foreach (var vcam in virtualCams)
                vcam.Priority = 10;

            // Désactiver la caméra FPS
            fpsCamera.enabled = false;
            fpsController.SetActive(false); // Désactiver le contrôle souris
            Cursor.lockState = CursorLockMode.None; // Libérer le curseur
            Cursor.visible = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationParCollision : MonoBehaviour
{
    public GameObject objetDeclencheur;
    public GameObject Door;
    public float ouvertureDoorX = 2.0f;

    public Color couleurActive = Color.green;
    public float enfoncementY = -0.1f;

    private Renderer rend;
    private Color couleurOriginale;
    private Vector3 positionInitiale;

    private void Start()
    {
        // Récupérer le composant Renderer de l'objet déclencheur
        rend = objetDeclencheur.GetComponentInChildren<Renderer>();

        if (rend != null)
        {
            couleurOriginale = rend.material.color;
        }

        positionInitiale = objetDeclencheur.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Si l'objet qui entre en collision est le joueur, activer l'objet déclencheur
            if (objetDeclencheur != null)
            {
                objetDeclencheur.SetActive(true);
                Debug.Log("Activation");

                if (rend != null)
                {
                    rend.material.color = couleurActive;
                }

                Vector3 newPosition = objetDeclencheur.transform.position;
                newPosition.y += enfoncementY;
                objetDeclencheur.transform.position = newPosition;

                if (Door != null)
                {
                    Vector3 nouvellePositionPorte = Door.transform.position;
                    nouvellePositionPorte.x += ouvertureDoorX;
                    Door.transform.position = nouvellePositionPorte;
                }
            }
        }
    }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // Si l'objet qui sort de la zone de collision est le joueur, restaurer la position initiale de l'objet déclencheur
                objetDeclencheur.transform.position = positionInitiale;

                if (rend != null)
                {
                    rend.material.color = couleurOriginale;
                }

                if (Door != null)
                {
                    Vector3 nouvellePositionPorte = Door.transform.position;
                    nouvellePositionPorte.x -= ouvertureDoorX;
                    Door.transform.position = nouvellePositionPorte;

                }
            }
        }
    }






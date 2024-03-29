using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DéplacementPersonnage : MonoBehaviour
{
    public float vitesseDeplacement = 15f; // Vitesse de déplacement de l'objet

    void Update()
    {
        // Déplacement horizontal
        float deplacementHorizontal = Input.GetAxis("Horizontal");

        // Déplacement vertical
        float deplacementVertical = Input.GetAxis("Vertical");

        // Calcul du vecteur de déplacement
        Vector3 deplacement = new Vector3(deplacementHorizontal, 0f, deplacementVertical) * vitesseDeplacement * Time.deltaTime;

        // Appliquer le déplacement à l'objet
        transform.Translate(deplacement);
    }
}

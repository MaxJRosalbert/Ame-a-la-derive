using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeplacementSjelSimple : MonoBehaviour
{
    public Vector3 deplacement;
    private Vector3 directionJoueur;

    public Transform orientation;
    public Transform joueur;
    public Transform objetJoueur;

    public LayerMask layerMask;

    public float gravite;
    private float axeV;
    private float axeH;
    public float vitesseDeplacement;
    private float vitesseRotation;
    private float vitesseBoost;
    private float forceSaut;
    private float adoucissementVitesseVirage;
    private float adoucissementVirage = 0.1f;
    private float distanceDuSol;
    private float distanceVerif = 0.1f;

    public bool curseurLock;
    public bool auSol = false;
    public bool peutBouger = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        Vector3 directionRegard = joueur.position - new Vector3(transform.position.x, joueur.position.y, transform.position.z);
        orientation.forward = directionRegard.normalized;

        if (peutBouger)
        {
            axeH = Input.GetAxisRaw("Horizontal");
            axeV = Input.GetAxisRaw("Vertical");
        }
        else
        {
            axeH = 0f;
            axeV = 0f;
        }

        Vector3 directionMouvement = orientation.forward * axeV + orientation.right * axeH;
        vitesseRotation = 7f;
        objetJoueur.forward = Vector3.Slerp(objetJoueur.forward, directionMouvement.normalized, Time.deltaTime * vitesseRotation);
        directionJoueur = objetJoueur.forward;

        gravite = GetComponent<Rigidbody>().velocity.y;

        distanceDuSol = (GetComponent<CapsuleCollider>().height / 2) + distanceVerif;

        vitesseDeplacement = 10f;

        deplacement = (new Vector3(axeH, 0f, axeV).normalized) * vitesseDeplacement + new Vector3(0f, gravite, 0f);


        if (deplacement.magnitude >= 0.1f)
        {
            float angleDeplacement = Mathf.Atan2(deplacement.x, deplacement.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angleDeplacement, ref adoucissementVitesseVirage, adoucissementVirage);
            GetComponent<Rigidbody>().AddForce(deplacement, ForceMode.Acceleration);

            RaycastHit info;
            if (Physics.Raycast(transform.position, -transform.up, out info, distanceDuSol))
            {
                transform.rotation = Quaternion.FromToRotation(Vector3.up, info.normal) * Quaternion.Euler(transform.rotation.x, angle, transform.rotation.z);
            }
            else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, angle, transform.rotation.z);
            }
        }

        RaycastHit solTouche;
        if (Physics.Raycast(transform.position, -transform.up, out solTouche, distanceDuSol))
        {
            auSol = true;
            gravite = -12f;
        }
        else
        {
            auSol = false;
        }

        if (peutBouger)
        {
            if (Input.GetKeyDown(KeyCode.J) && auSol)
            {
                gravite = 4f;
                forceSaut = 6f;
                GetComponent<Rigidbody>().AddForce(Vector3.up * (gravite += forceSaut), ForceMode.Impulse);
            }
        }

        if (!auSol && gravite <= 0f)
        {
            gravite = gravite / 0.99f;
        }

        if (!auSol && gravite > 0f)
        {
            gravite = gravite / 2f;
        }

        if (gravite <= -25f)
        {
            gravite = -25f;
        }

        if (gravite >= 12f)
        {
            gravite = 12f;
        }
    }

    public void OnTriggerEnter(Collider collisionsObjets)
    {
        if (collisionsObjets.gameObject.tag == "ressort")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = Vector3.up * 12f;
        }

        if (collisionsObjets.gameObject.tag == "zoneFin")
        {
            peutBouger = false;
            //GetComponent<GestionChrono>().ChronoPause();
            Invoke("ChargementSceneSelecNiv", 3f);
        }

        if (collisionsObjets.gameObject.tag == "boost")
        {
            vitesseBoost = 100f;
            GetComponent<Rigidbody>().AddForce(Vector3.forward * vitesseBoost, ForceMode.Impulse);
            Invoke("AnnulGlissade", 0.1f);
        }
    }

    void OnCollisionEnter(Collision infoCollision)
    {
        // Si le terrain est touché alors active l'animation de l'objet et détruit le
        if (infoCollision.gameObject.tag == "ennemi")
        {
            Invoke("PertePointsVie", 0f);
            print("vie verdu");
        }

    }

    public void ChargementSceneSelecNiv()
    {
        SceneManager.LoadScene("Choix-Niveaux");
    }
}

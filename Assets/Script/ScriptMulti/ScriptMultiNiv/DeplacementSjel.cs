using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeplacementSjel : MonoBehaviour
{
    private Vector3 deplacement;
    private Vector3 directionJoueur;
    private Vector3 forceDashAppliqueeDelai;
    private Vector3 forceGlissadeAppliqueeDelai;
    private Vector3 forceAttaqueAppliqueeDelai;

    public Transform orientation;
    public Transform joueur;
    public Transform objetJoueur;

    public LayerMask layerMask;

    public float gravite;
    public float vitesseAttaque;
    private float axeV;
    private float axeH;
    private float vitesseDeplacement;
    private float vitesseRotation;
    private float vitesseBoost;
    private float forceSaut;
    private float forceChute;
    private float forceGlissade;
    private float forceDash;
    private float forceDashHaut;
    private float adoucissementVitesseVirage;
    private float adoucissementVirage = 0.1f;
    private float distanceDuSol;
    private float distanceVerif = 0.1f;

    public bool curseurLock;
    public bool auSol = false;
    public bool chute = false;
    public bool dash = false;
    public bool glissade = false;
    public bool peutGlisser = true;
    public bool peutBouger = true;

    private int maxDash = 1;
    private int dashRestants = 0;
    private int maxGlissade = 1;
    private int glissadeRestants = 0;
    private int maxChute = 1;
    private int chuteRestants = 0;

    public GameObject objetMarque;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        glissadeRestants = maxGlissade;
    }
    private void FixedUpdate()
    {
        MarqueEnnemiProche();
        MarqueRessortProche();
        //MarqueRailProche();
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
        directionJoueur = objetJoueur.forward;
        objetJoueur.forward = Vector3.Slerp(objetJoueur.forward, directionMouvement.normalized, Time.deltaTime * vitesseRotation);

        gravite = GetComponent<Rigidbody>().velocity.y;

        distanceDuSol = (GetComponent<CapsuleCollider>().height / 2) + distanceVerif;

        vitesseDeplacement = 15f;

        deplacement = (new Vector3(axeH, 0f, axeV).normalized) * vitesseDeplacement + new Vector3(0f, gravite, 0f);


        if (deplacement.magnitude >= 0.1f)
        {
            float angleDeplacement = Mathf.Atan2(deplacement.x, deplacement.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angleDeplacement, ref adoucissementVitesseVirage, adoucissementVirage);
            GetComponent<Rigidbody>().AddForce(deplacement, ForceMode.Acceleration);

            RaycastHit infoAngle;
            if (Physics.Raycast(transform.position, -transform.up, out infoAngle, distanceDuSol))
            {
                transform.rotation = Quaternion.FromToRotation(Vector3.up, infoAngle.normal) * Quaternion.Euler(transform.rotation.x, angle, transform.rotation.z);
            }
            else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, angle, transform.rotation.z);
            }
        }

        directionJoueur = objetJoueur.forward;

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
            if (!Input.GetKeyDown(KeyCode.J) && auSol)
            {
                dashRestants = maxDash;
            }

            if (!Input.GetKeyDown(KeyCode.K) && auSol)
            {
                chuteRestants = maxChute;
            }

            if (Input.GetKeyDown(KeyCode.J) && auSol)
            {
                gravite = 4f;
                forceSaut = 15f;
                GetComponent<Rigidbody>().AddForce(Vector3.up * (gravite += forceSaut), ForceMode.Impulse);
            }
            else if (Input.GetKeyDown(KeyCode.J) && !auSol && dashRestants > 0)
            {
                dashRestants -= 1;
                forceDash = 20f;
                dash = true;

                if (objetMarque != null)
                {
                    var direction = (objetMarque.transform.position - transform.position).normalized;
                    forceAttaqueAppliqueeDelai = direction * vitesseAttaque;
                    Invoke("forceAttaqueDelai", 0.025f);
                }
                else
                {
                    Vector3 forceDashAppliquee = directionJoueur * forceDash + orientation.up * forceDashHaut;
                    forceDashAppliqueeDelai = forceDashAppliquee;
                    Invoke("forceDashDelai", 0.025f);
                }
            }

            if (auSol && Input.GetKeyDown(KeyCode.K) && peutGlisser == true)
            {
                if (deplacement.magnitude >= 0.1f)
                {
                    glissadeRestants -= 1;
                    forceGlissade = 10f;
                    Vector3 forceGlissadeAppliquee = directionJoueur * forceGlissade + orientation.up * forceDashHaut;
                    forceGlissadeAppliqueeDelai = forceGlissadeAppliquee;
                    gravite = -5f;
                    peutGlisser = false;
                    Invoke("forceGlissadeDelai", 0.025f);
                    Invoke("AnnulGlissade", 4f);

                    glissade = true;
                }
            }

            if (!auSol && Input.GetKeyDown(KeyCode.K) && chuteRestants > 0)
            {
                chuteRestants -= 1;
                forceChute = 40f;
                GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                GetComponent<Rigidbody>().AddForce(Vector3.down * (gravite += forceChute), ForceMode.Impulse);

                chute = true;
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

        if (deplacement.magnitude <= 0.1f || !auSol)
        {
            Invoke("AnnulGlissade", 0.1f);
        }

        if (auSol)
        {
            Invoke("AnnulChute", 0.1f);
            Invoke("AnnulDash", 0.1f);
        }
    }

    public void MarqueEnnemiProche()
    {
        GameObject[] ennemis = GameObject.FindGameObjectsWithTag("ennemi");
        Vector3 currentPosition = transform.position;
        Vector3 difference;
        GameObject cible = null;
        float distanceEntreJoueurCible;
        float magnitude;
        float distance = 75f;

        foreach (GameObject ennemi in ennemis)
        {
            difference = ennemi.transform.position - currentPosition;
            magnitude = difference.sqrMagnitude;

            distanceEntreJoueurCible = Vector3.Distance(currentPosition, difference);

            if (distanceEntreJoueurCible < distance)
            {
                if (magnitude < distance)
                {
                    cible = ennemi;
                    distance = magnitude;
                }
            }
            else if (distanceEntreJoueurCible >= distance)
            {
                cible = null;
                objetMarque = null;
            }
        }

        if (cible != null)
        {
            if (objetMarque == null || (objetMarque.GetInstanceID() != cible.GetInstanceID()))
            {
                objetMarque = cible;
            }
        }
    }
    public void MarqueRessortProche()
    {
        GameObject[] ressorts = GameObject.FindGameObjectsWithTag("ressort");
        Vector3 currentPosition = transform.position;
        Vector3 difference;
        GameObject cible = null;
        float distanceEntreJoueurCible;
        float magnitude;
        float distance = 75f;

        foreach (GameObject ressort in ressorts)
        {
            difference = ressort.transform.position - currentPosition;
            magnitude = difference.sqrMagnitude;

            distanceEntreJoueurCible = Vector3.Distance(currentPosition, difference);

            if (distanceEntreJoueurCible < distance)
            {
                if (magnitude < distance)
                {
                    cible = ressort;
                    distance = magnitude;
                }
            }
            else if (distanceEntreJoueurCible >= distance)
            {
                cible = null;
                objetMarque = null;
            }
        }

        if (cible != null)
        {
            if (objetMarque == null || (objetMarque.GetInstanceID() != cible.GetInstanceID()))
            {
                objetMarque = cible;
            }
        }
    }

    /*public void MarqueRailProche()
    {
        GameObject[] rails = GameObject.FindGameObjectsWithTag("rail");
        Vector3 currentPosition = transform.position;
        Vector3 difference;
        GameObject cible = null;
        float distanceEntreJoueurCible;
        float magnitude;
        float distance = 85f;

        foreach (GameObject rail in rails)
        {
            difference = rail.transform.position - currentPosition;
            magnitude = difference.sqrMagnitude;

            distanceEntreJoueurCible = Vector3.Distance(currentPosition, difference);

            if (distanceEntreJoueurCible < distance)
            {
                if (magnitude < distance)
                {
                    cible = rail;
                    distance = magnitude;
                }
            }
            else if (distanceEntreJoueurCible >= distance)
            {
                cible = null;
                objetMarque = null;
            }
        }

        if (cible != null)
        {
            if (objetMarque == null || (objetMarque.GetInstanceID() != cible.GetInstanceID()))
            {
                objetMarque = cible;
            }
        }
    }*/

    public void forceDashDelai()
    {
        GetComponent<Rigidbody>().AddForce(forceDashAppliqueeDelai, ForceMode.VelocityChange);
    }
    public void forceGlissadeDelai()
    {
        GetComponent<Rigidbody>().AddForce(forceGlissadeAppliqueeDelai, ForceMode.VelocityChange);
    }
    public void forceAttaqueDelai()
    {
        GetComponent<Rigidbody>().AddForce(forceAttaqueAppliqueeDelai, ForceMode.Impulse);
    }

    public void AnnulChute()
    {
        chute = false;
    }

    public void AnnulDash()
    {
        dash = false;
    }

    public void AnnulGlissade()
    {
        glissade = false;
        peutGlisser = true;
        glissadeRestants = maxGlissade;
    }

    public void OnTriggerEnter(Collider collisionsObjets)
    {
        if (collisionsObjets.gameObject.tag == "ennemi")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = Vector3.up * 8f;
        }

        if (collisionsObjets.gameObject.tag == "ressort")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = Vector3.up * 12f;

            if (chute)
            {
                GetComponent<Rigidbody>().velocity = Vector3.up * 17f;
            }
        }

        if (collisionsObjets.gameObject.tag == "zoneFin")
        {
            peutBouger = false;
            //GetComponent<GestionChrono>().ChronoPause();
            Invoke("ChargementSceneSelecNiv", 5f);
        }

        /*if (collisionsObjets.gameObject.tag == "railBase")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            dash = false;
            glissade = false;
        }*/

        if (collisionsObjets.gameObject.tag == "boost")
        {
            vitesseBoost = 100f;
            GetComponent<Rigidbody>().AddForce(Vector3.forward * vitesseBoost, ForceMode.Impulse);
            Invoke("AnnulGlissade", 0.1f);
        }
    }

    public void ChargementSceneSelecNiv()
    {
        SceneManager.LoadScene("Choix-Niveaux");
    }
}

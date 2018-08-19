using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
//public struct PlayerHeight
//{
//    public float stand;
//    public float crouch;

//    public PlayerHeight(float stand, float crouch)
//    {
//        this.stand = stand;
//        this.crouch = crouch;
//    }
//}

public enum SurfaceInteraction
{
    Grounded,
    Sliding,
    Floating
}

public class ControlPlayer : MonoBehaviour
{
    public static ControlPlayer Instance;
    CanvasManagerInGame canvasmanageringame = CanvasManagerInGame.Instance;

    bool Pausado = false;

    //public PlayerHeight height = new PlayerHeight(2F, 1F);
    public float velocidad;
    public float salto;
    public float correr;
    public float andar;
    public float agachar;
    public float flotar;
    public float controlAereo = 0.25f;
    public float sensibilidad = 5.0f;
    public float smoothing = 2.0f;
    [Range(0F, 90F)]
    public float slopeAngle = 45F;
    AudioSource audioSource;
    public AudioClip JumpSound;
    public AudioClip FallSound;
    public AudioClip StepSound;
    public AudioClip RunSound;

    bool isWalking;
    bool isRunning;
    Camera camara;
    CapsuleCollider collider;
    Rigidbody cuerpo;
    bool agacharse;
    Vector2 mouseLook;
    Vector2 smoothV;
    float andaraudiovelocidad = 0.4f;
    float correraudiovelocidad = 0.2f;

    float andaraudiotiempo = 0.0f;
    float correraudiotiempo = 0.0f;

    public Vector3 MovementAxis { get { return new Vector3(Input.GetAxisRaw("Horizontal"), 0F, Input.GetAxisRaw("Vertical")); } }
    public Vector2 LookAxis { get { return new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * sensibilidad * smoothing; } }

    public SurfaceInteraction SurfaceInteraction { get; protected set; }
    public ContactPoint Surface { get; protected set; }
    public Dictionary<Collider, Collision> Collisions { get; protected set; }

    public bool IsJumping { get; private set; }

    void Awake()
    {
        Collisions = new Dictionary<Collider, Collision>();
        SurfaceInteraction = SurfaceInteraction.Floating;

        cuerpo = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        camara = GetComponentInChildren<Camera>();
        audioSource = GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.Locked;

        this.Instanciar();
    }

    void Update()
    {
        if (velocidad > 4)
        {
            PlayFootsteps();
        }
        else
        {
            andaraudiotiempo = 0.0f;
            correraudiotiempo = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Pausado == false)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Pausado = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Pausado == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Pausado = false;
        }


    }

    void PlayFootsteps()
    {
        if (isWalking == true)
        {
            if (audioSource.clip != StepSound)
            {
                audioSource.Stop();
                audioSource.clip = StepSound;
            }

            if (andaraudiotiempo > andaraudiovelocidad)
            {
                audioSource.Stop();
                audioSource.Play();
                andaraudiotiempo = 0.0f;
            }
        }
        else if (isRunning == true)
        {
            if (audioSource.clip != RunSound)
            {
                audioSource.Stop();
                audioSource.clip = RunSound;
            }
            if (correraudiotiempo > correraudiovelocidad)
            {
                audioSource.Stop();
                audioSource.Play();
                correraudiotiempo = 0.0f;
            }
        }
        else
        {
            audioSource.Stop();
        }

        andaraudiotiempo += Time.deltaTime;
        correraudiotiempo += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (IsJumping)
        {
            SurfaceInteraction = SurfaceInteraction.Floating;
            IsJumping = false;
        }
        else ProcessCollisions();

        Look();
        Movement();
    }

    void Look()
    {
            smoothV = Vector2.Lerp(smoothV, LookAxis, 1F / smoothing);

            mouseLook += smoothV;
            mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

            camara.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up) * Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
    }

    void Movement()
    {
        switch (SurfaceInteraction)
        {
            case SurfaceInteraction.Grounded: OnGround(); break;
            case SurfaceInteraction.Sliding: OnSlide(); break;
            case SurfaceInteraction.Floating: OnAir(); break;
        }
    }

    void OnGround()
    {
        cuerpo.useGravity = false;

        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //    collider.height = height.crouch;
        //else if (Input.GetKeyUp(KeyCode.LeftControl))
        //    collider.height = height.stand;

        //if (Input.GetKey(KeyCode.LeftControl))
        //{
        //    velocidad = agachar;
        //}
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRunning = true;
                isWalking = false;
                velocidad = correr;
            }
            else
            {
                isRunning = false;
                isWalking = true;
                velocidad = andar;
            }
        }
        else
        {
            isWalking = false;
            isRunning = false;
        }


        Vector3 direction = camara.transform.forward; direction.y = 0F;

        Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, direction);

        Vector3 floor = rotation * MovementAxis;

        Vector3 plane = Vector3.ProjectOnPlane(floor, Surface.normal).normalized;

        float angle = Vector3.Angle(Vector3.up, Surface.normal);

        float p = Mathf.InverseLerp(180F, 0F, angle);

        cuerpo.velocity = plane * velocidad * p;

        if (Input.GetKey(KeyCode.Space))
        {
            audioSource.PlayOneShot(JumpSound);
            cuerpo.velocity += Vector3.up * salto;
            IsJumping = true;
        }
    }

    void OnSlide()
    {
        cuerpo.useGravity = true;
        //collider.height = height.stand;
        velocidad = correr; //deslizarse
    }

    void OnAir()
    {
        cuerpo.useGravity = !IsJumping;

        Vector3 direction = camara.transform.forward; direction.y = 0F;
        Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, direction);

        Vector3 bodyVelocity = cuerpo.velocity; bodyVelocity.y = 0F;
        Vector3 velocity = rotation * MovementAxis * controlAereo * Time.deltaTime;
        Vector3 newVelocity = bodyVelocity + velocity;

        if (newVelocity.magnitude > flotar)
            newVelocity = newVelocity.normalized * flotar;

        newVelocity.y = cuerpo.velocity.y;
        cuerpo.velocity = newVelocity;
    }

    protected void ProcessCollisions()
    {
        SurfaceInteraction newInteraction = SurfaceInteraction;

        var nulos = Collisions.Where(c => c.Key == null).ToArray();
        foreach (var nulo in nulos)
            Collisions.Remove(nulo.Key);

        if (Collisions.Count > 0)
        {
            float minAngle = float.MaxValue;

            foreach (Collision collision in Collisions.Values)
            {
                foreach (ContactPoint contact in collision.contacts)
                {
                    float angle = Vector3.Angle(contact.normal, Vector3.up);
                    if (angle < minAngle)
                    {
                        minAngle = angle;
                        Surface = contact;
                    }
                }
            }

            if (minAngle >= 90F)
                newInteraction = SurfaceInteraction.Floating;
            else if (minAngle > slopeAngle)
                newInteraction = SurfaceInteraction.Sliding;
            else
                newInteraction = SurfaceInteraction.Grounded;
        }
        else newInteraction = SurfaceInteraction.Floating;

        if (newInteraction != SurfaceInteraction)
            SurfaceInteraction = newInteraction;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(FallSound);
        if (!Collisions.ContainsKey(collision.collider))
            Collisions.Add(collision.collider, collision);
    }

    protected void OnCollisionStay(Collision collision)
    {
        if (Collisions.ContainsKey(collision.collider))
            Collisions[collision.collider] = collision;
    }

    protected void OnCollisionExit(Collision collision)
    {
        if (Collisions.ContainsKey(collision.collider))
            Collisions.Remove(collision.collider);
    }

    public void Instanciar()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if(this != Instance)
        {
            Destroy(this.gameObject);
        }
    }
}
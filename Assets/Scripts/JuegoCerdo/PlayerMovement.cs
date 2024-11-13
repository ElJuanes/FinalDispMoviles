using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveDirection = Vector2.right;
    private PlayerControls inputActions;
    public ParticleSystem particulas;
    public AudioSource audioSource;
    GameManager gameManager;
    private float originalMoveSpeed;

    // Variables para el efecto Grow
    private Vector3 originalScale;
    private Vector3 growScale = new Vector3(0.6f, 0.6f, 1); // Aumentar 0.5 en cada eje
    private float growDuration = 15f;
    private bool isGrowing = false;

    // Variables para el efecto Speed
    private float speedMultiplier = 1.5f; // Cuánto se aumenta la velocidad
    private float speedDuration = 10f; // Duración del efecto Speed
    private bool isSpeeding = false;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        originalScale = transform.localScale; // Guardar la escala original
        originalMoveSpeed = moveSpeed;
        Debug.Log("Velocidad actual..."+ moveSpeed);
    }

    private void Awake()
    {
        inputActions = new PlayerControls();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Tap.performed += OnTap;
    }

    private void OnDisable()
    {
        inputActions.Player.Tap.performed -= OnTap;
        inputActions.Disable();
    }

    private void OnTap(InputAction.CallbackContext context)
    {
        moveDirection = moveDirection == Vector2.right ? Vector2.left : Vector2.right;
    }

    private void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Si está en crecimiento, aumentar la escala
        if (isGrowing)
        {
            transform.localScale = growScale;
        }
    }

    public void ApplyGrowEffect()
    {
        isGrowing = true;
        Invoke("EndGrowEffect", growDuration); // Terminar el efecto después de 15 segundos
    }

    private void EndGrowEffect()
    {
        transform.localScale = originalScale; // Restablecer la escala
        isGrowing = false;
    }

    public void ApplySpeedEffect()
    {
        if (!isSpeeding) // Solo aplicar el efecto si no está activo
        {
            moveSpeed *= speedMultiplier;
            isSpeeding = true;
            Debug.Log("Velocidad actual pre buff" + moveSpeed);
            Invoke("EndSpeedEffect", speedDuration); 
        }
    }

    private void EndSpeedEffect()
    {
        moveSpeed /= speedMultiplier; // Restablecer la velocidad original
        Debug.Log("Velocidad actual post buff" + moveSpeed);
        isSpeeding = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("zanahoria"))
        {
            PlayCollectSound();
            particulas.Play();
            gameManager.Punto();
        }
    }
    public void PlayCollectSound()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
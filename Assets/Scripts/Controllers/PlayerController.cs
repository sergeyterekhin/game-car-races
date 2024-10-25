using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class SoundEffectsCar
{
    public AudioClip die;
    public AudioClip drive;
}

[System.Serializable]
public class ParticlesEffectsCar
{
    public ParticleSystem crash;
    public ParticleSystem smokeEngine;
}

public class PlayerController : MonoBehaviour, ICanGrapBonus, IDamageable
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private bool godMode;
    [SerializeField] private SoundEffectsCar sound;
    [SerializeField] private ParticlesEffectsCar effects;

    private Animator animationPlayer;
    private List<Coroutine> ActiveBonusesTimer;
    private Rigidbody2D rb;
    private AudioSource soundSourse;

    public void Die() {
        effects.crash.Play();
        animationPlayer.SetBool("isDied", true);
        effects.smokeEngine.Play();

        soundSourse.loop = false;
        soundSourse.clip = sound.die;
        soundSourse.Play();

        rb.bodyType = RigidbodyType2D.Static;
    }

    private void initializePlayer()
    {
        this.transform.position = new Vector3(this.transform.position.x, -6f);
        rb.bodyType = RigidbodyType2D.Dynamic;
        soundSourse.loop = true;
        effects.smokeEngine.Clear();
        effects.smokeEngine.Stop();
        soundSourse.clip = sound.drive;
        soundSourse.Play();
        animationPlayer.SetBool("isDied",false);
    }

    public void Damage(float value)
    {
        if (GameStore.getInstance().stateMainPlayer!=GameState.Life) return;
        health -= value;
        if (this.health <= 0f) EventManager.onGameOver();
    }

    public void SetBonus(IEnumerator action)
    {
        Coroutine newCoroutine = StartCoroutine(action);
        ActiveBonusesTimer.Add(newCoroutine);
    }

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.animationPlayer = this.GetComponent<Animator>();
        this.soundSourse = this.GetComponent<AudioSource>();
        this.ActiveBonusesTimer = new();
        this.initializePlayer();
        EventManager.GameOver += Die;
        EventManager.RestartGame += initializePlayer;
    }

    void FixedUpdate()
    {
        switch (GameStore.getInstance().stateMainPlayer)
        {
            case GameState.Life:
                if (Input.GetAxisRaw("Space") != 0f) rb.AddForce(new Vector2(0, Input.GetAxisRaw("Space") * speed * 10f));
                else rb.AddForce(new Vector2(0, -1 * speed * 10f));
            break;

            case GameState.Died:
                if (Input.GetAxisRaw("Space") != 0f && GameManager.CanRestartGame) EventManager.onRestartGame();
            break;
        }
    }
}

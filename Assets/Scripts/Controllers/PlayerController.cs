using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour, ICanGrapBonus, IDamageable
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private bool godMode;
    private Animator animationPlayer;
    private List<Coroutine> ActiveBonusesTimer;
    private Rigidbody2D rb;

    public void Die() {
        animationPlayer.SetBool("isDied", true);
        
        ParticleSystem smokeEffect = gameObject.GetComponentsInChildren<ParticleSystem>().FirstOrDefault(psEl=>psEl.name=="effectDie");
        smokeEffect?.Play();
        
        rb.bodyType = RigidbodyType2D.Static;
        EventManager.OnPlayerDie();
    }

    public void Damage(float value)
    {
        health -= value;
        if (this.health <= 0f) Die();
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
        this.ActiveBonusesTimer = new();
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Space") != 0f) rb.AddForce(new Vector2(0, Input.GetAxisRaw("Space") * speed * 10f));
        else rb.AddForce(new Vector2(0, -1 * speed * 10f));
    }
}

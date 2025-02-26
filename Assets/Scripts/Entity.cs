﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StateFactory;

public class Entity : MonoBehaviour
{
    [Header("Movement Info")]
    public float moveSpeed = 0.2f;
    public float jumpForce = 18;
  
    private float dashUsageTimer;

    public float maxHP = 1;
    public float currentHP = 1;

    protected int soundID = 0;

    [Header("Collision Info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;

    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;

    [SerializeField] private LayerMask whatIsGround;

    public Animator Anim { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public SpriteRenderer SR { get; private set; }
    public StateMachine StateMachine { get; private set; } = new StateMachine();
    // Start is called before the first frame update
    public Dictionary<EnumBirdStates, State> states = new Dictionary<EnumBirdStates, State>();
    private EntitySound EntitySound { get; set; }
    int facingDir = 1;

    private void Awake()
    {
        // StateMachine = new PlayerStateMachine();

        Anim = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        SR = GetComponentInChildren<SpriteRenderer>();
        EntitySound = GetComponent<EntitySound>();

        if(EntitySound!=null)
        {
            soundID = UnityEngine.Random.Range(0, EntitySound.audioClips.Count - 1);
        }

        foreach (EnumBirdStates state in Enum.GetValues(typeof(EnumBirdStates)))
        {
            states[state] = StateFactory.CreateState(this, state);
        }
    }
    void Start()
    {
        StateMachine.ChangeState(states[EnumBirdStates.BirdFly]);

    }

    // Update is called once per frame
    void Update()
    {


        if (StateMachine.CurrentState != null)
        {
            StateMachine.CurrentState.Update();
        }

        dashUsageTimer -= Time.deltaTime;

        if (dashUsageTimer < 0)
        {

        }

    }

    void FixedUpdate()
    {
        if (StateMachine.CurrentState != null)
        {
            StateMachine.CurrentState.FixedUpdate();
        }

    }

    public void SetVelocity(float vx, float vy)
    {
        Rb.linearVelocity = new Vector2(vx, vy);
    }

    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));

    }

   

    
    public void Hit(Vector2 hitPosition)
    {
        if (StateMachine.CurrentState != this.states[EnumBirdStates.BirdDeath] &&
            StateMachine.CurrentState != this.states[EnumBirdStates.BirdDamaged] )
        {
            StateMachine.ChangeState(this.states[EnumBirdStates.BirdDamaged]);
        }
    }

    public void Damage(float damageValue)
    {
        this.currentHP -= damageValue;
        if(this.currentHP < 0)
        {
            StateMachine.ChangeState(this.states[EnumBirdStates.BirdDeath]);
        }
    }

    public void Destruct()
    {
        this.gameObject.SetActive(false);
        Destroy(gameObject);
        BirdSpanwer.BIRD_COUNT--;
    }

    public void PlaySound(string name=null)
    {
        if (EntitySound != null)
        {
            switch(name)
            {
            case "falling":
                    EntitySound.PlayFallingSound();
                    break;
            default:
                    EntitySound.PlaySound(soundID);
                    break;
            }
        }
    }

    


}







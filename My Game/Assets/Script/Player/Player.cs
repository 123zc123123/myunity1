using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player :Entity,ISave
{
    public DataBase dataBase;
    //���һЩë��������ҽ�
    [SerializeField]private Transform groundTransform2;

    //״̬��
    public PlayerStateMachine stateMachine;

    public PlayerSkillManager skillManager;

    //�Ƿ���Գ��
    public bool canDash;
    //��Ծ
    public bool canJump;
    //�Ƿ������ˣ����������޵�
    public bool canHurt;
    //�޵�ʱ��
    public float hurtTime;
    public float jumpForce=3;

    //���ﵱǰ״̬��״̬�ϼ�
    public PlayerIdleState idleState;
    public PlayerMoveState moveState;
    public PlayerJumpState jumpState;
    public PlayerFallState fallState;
    public PlayerPrimaryAttackState attackState;
    public PlayerGroundState groundState;
    public PlayerAirState airState;
    public PlayerWallClimbState wallClimbState;
    public PlayerDushState dushState;
    public PlayerDeadState deadState;
    public PlayerDefenseState defenseState;
    public PlaySkillState skillState;
    public PlayerDictionState dictionState;
    public PlayerFloatState floatState;
    public PlayerHurtState hurtState;

    //��������鼼��ʱ�����ʹ�á�
    public PlayerSkillController skillController;
    public CloneAndSwordGroup cloneAndSwordGroup;
    public LightGroup lightGroup;
    public IceAndFireGroup iceAndFireGroup;
    public WindGroup windGroup;

    //��¡����
    public CloneSkill cloneSkill;
    public CloneSwitchPosition cloneSwitchPosition;

    //�缼��
    public MinWindSkill minWindSkill;
    public MidWindSkill midWindSkill;
    public MaxWindSkill maxWindSkill;

    //�������뱾���Ƿ�ͬ����
    public float cloneDir;

    public PlayerAttribute playerAttribute;
    //����ٶ�
    public float dashSpeed;
    //����
    public int attackCount;
    //���ڼ�¼���ι���֮��ļ�������������������ù���������
    public float attackTime;
    //���ڿ��ƺ�ʱ�����ͷŹ����ͼ��ܡ�
    public bool canAttack;
    //���ĳЩ���ܵ��ͷ�
    public bool canDefense;
    //��ǰ�ͷŵļ���
    public PlayerSkill currentSkill;


    //�浵��
    public SaveLoder saveLoder;
    protected override void Start()
    {
        base.Start();
        stateMachine = new PlayerStateMachine();
        SetStartState();
        SetStartSkill();
        playerAttribute = GetComponent<PlayerAttribute>();
        saveLoder = null;

        canHurt = true;
        canDash = true;
        canDefense = true;
        canAttack = true;
        attackCount = 0;
        canJump = true;
        cloneDir = 1;
        
    }

    private void SetStartSkill()
    {
        InitObject();

        cloneAndSwordGroup.AddSkillInGroup(cloneSkill, KeyCode.Q, KeyCode.None);
        cloneAndSwordGroup.AddSkillInGroup(cloneSwitchPosition, KeyCode.Q, KeyCode.W);

        windGroup.AddSkillInGroup(maxWindSkill, KeyCode.E, KeyCode.S);
        windGroup.AddSkillInGroup(midWindSkill, KeyCode.E, KeyCode.None);
        windGroup.AddSkillInGroup(minWindSkill, KeyCode.E, KeyCode.W);

    }

    //��ʼ������
    private void InitObject()
    {
        windGroup = new WindGroup(this, "WindGroup");
        cloneAndSwordGroup = new CloneAndSwordGroup(this, "CloneAndSwordGroup");
        lightGroup = new LightGroup(this, "LightGroup");
        iceAndFireGroup = new IceAndFireGroup(this, "IceAndFireGroup");
        skillController = new PlayerSkillController();
        skillController.SetStartSkillGroup(cloneAndSwordGroup,windGroup);

        cloneSkill = new CloneSkill(this, SkillType.GroundAndAir, skillManager, cloneAndSwordGroup);
        cloneSwitchPosition = new CloneSwitchPosition(this, SkillType.GroundAndAir, skillManager, cloneAndSwordGroup);

        maxWindSkill = new MaxWindSkill(this, SkillType.GroundAndAir, skillManager, windGroup);
        minWindSkill = new MinWindSkill(this, SkillType.GroundAndAir, skillManager, windGroup);
        midWindSkill = new MidWindSkill(this, SkillType.GroundAndAir, skillManager, windGroup);
    }

    protected override void Update()
    {
        base.Update();
        if (PuaseManager.instance.isPause)
            return;
        if (playerAttribute.currentHp.GetValue() <= 0&&stateMachine.currentState!=deadState)
        {
            stateMachine.ChangeState(deadState);
            isDead = true;
        }
        stateMachine.currentState.UpdateState();
        //��������˾Ͳ�ִ�к�������
        if (isDead)
            return;
        attackTime += Time.deltaTime;
        InputAndTriggerDete();
        //�˴��߼���ʱ��ˣ�������Ҫ����
        if (Input.GetKeyDown(KeyCode.LeftShift)&&canDash==true) 
        {
            stateMachine.ChangeState(dushState);
        }

        //��������
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            skillController.UnlockSkillGroup(windGroup);


        }
        if (Input.GetKeyDown(KeyCode.B))
        {

            skillController.SwitchCurrentSkillGroup("Skill1", windGroup, dataBase.keyControllerPair["Skill1"]);

            skillController.SwitchCurrentSkillGroup("Skill2", cloneAndSwordGroup, dataBase.keyControllerPair["Skill2"]);
        }

        //�޵�״̬
        if (stateMachine.currentState != hurtState && canHurt == false) 
        {
            hurtTime += Time.deltaTime;
            if (hurtTime > 0.5f) 
            {
                canHurt = true;
            }
        }
    }
    //������벢ִ����ش���
    private void InputAndTriggerDete()
    {
       
        //������ʱ���boolֵ����ס
        if (attackTime > 1f)
        {
            canAttack = true;
        }

        if (stateMachine.currentState != dictionState)
        {
            //UseSkill(dataBase.keyControllerPair["Skill1"],skillController.skill1CurrentSkillGroup);
            //UseSkill(dataBase.keyControllerPair["Skill2"], skillController.skill2CurrentSkillGroup);
            //UseSkill(dataBase.keyControllerPair["Skill3"], skillController.skill3CurrentSkillGroup);

            UseSkill(KeyCode.Q, skillController.skill1CurrentSkillGroup);
            UseSkill(KeyCode.Mouse2, skillController.skill3CurrentSkillGroup);
            UseSkill(KeyCode.E, skillController.skill2CurrentSkillGroup);

        }
        //�����ͷž����л����ܣ�Ҳ���ڼ�����Ч�����ڼ�����Ч��ֱ��ʧЧΪֹ��
        skillController.SkillUpdate();
    }

    //�ͷż��ܣ������жϼ����Ƿ�󶨰�����δ��ֱ�ӽ�����,Ȼ���жϼ����Ƿ���ڣ�������ھ��ͷţ��ͷŽ����󷵻أ���������ھ�ִ������ļ��ܡ�
    private void UseSkill(KeyCode _keyCode,PlayerSkillGroup _thisSkillGroup)
    {
        //�ڼ���״̬�£���Ҫ���м��ܵ��ͷţ������Ǽ��ܵĳ������ͷż��ܽ������˳�����״̬�������ͷ���һ�����ܡ����ߵ�ǰ�����Թ������ͷż���
        if (stateMachine.currentState == skillState||!canAttack)
            return;
        canAttack = false;
  
        //�ͷż���
        if (Input.GetKeyDown(_keyCode)&&_thisSkillGroup!=null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (_thisSkillGroup.HaveSkill(_keyCode, KeyCode.W))
                {
                    stateMachine.ChangeState(skillState);
                    currentSkill= _thisSkillGroup.SkillTrigger(_keyCode, KeyCode.W);
                    return;
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (_thisSkillGroup.HaveSkill(_keyCode, KeyCode.S))
                {
                    stateMachine.ChangeState(skillState);
                    currentSkill = _thisSkillGroup.SkillTrigger(_keyCode, KeyCode.S);
                    return;
                }
            }
            if (_thisSkillGroup.HaveSkill(_keyCode, KeyCode.None))
            {
                stateMachine.ChangeState(skillState);
                currentSkill = _thisSkillGroup.SkillTrigger(_keyCode, KeyCode.None);
                return;
            }
            
        }
        canAttack = true;
    }


    //��ʼ��
    private void SetStartState()
    {
        idleState = new PlayerIdleState("idle", "Idle", this);
        moveState = new PlayerMoveState("move", "Move", this);
        jumpState = new PlayerJumpState("jump", "Jump", this);
        fallState = new PlayerFallState("fall", "Fall", this);
        attackState = new PlayerPrimaryAttackState("attack", "Attack", this, "AttackCount");
        airState = new PlayerAirState("air", "Air", this);
        groundState = new PlayerGroundState("ground", "Ground", this);
        wallClimbState = new PlayerWallClimbState("wallClimb", "WallClimb", this);
        dushState = new PlayerDushState("dash", "Dash", this);
        deadState = new PlayerDeadState("dead", "Dead", this);
        defenseState = new PlayerDefenseState("defense", "Defense", this);
        skillState = new PlaySkillState("skill", "Skill", this);
        dictionState = new PlayerDictionState("diction", "Idle", this);
        floatState = new PlayerFloatState("float", "Jump", this);
        hurtState = new PlayerHurtState("hurt", "Hurt", this);

        stateMachine.SetStartState(idleState);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawLine(groundTransform2.position, new Vector3(groundTransform2.position.x, groundTransform2.position.y - groundDeteLength));
    }
    public override bool DeteGround()
    {
        bool isGround;
        isGround = Physics2D.Raycast(groundTransform.position, Vector2.down, groundDeteLength, whatIsGround) || Physics2D.Raycast(groundTransform2.position, Vector2.down, groundDeteLength, whatIsGround);
        return isGround;
    }
    //����״̬
    public override void SetDeadState()
    {
        base.SetDeadState();
        stateMachine.ChangeState(deadState);
    }
    //״̬���ı�־λ
    public  void DeteTrigger()
    {
        stateMachine.currentState.SetTrigger();
    }
    //�ڴ浵�㸴��
    public void ReviveOnLoder() 
    {
        transform.position = saveLoder.transform.position;
        playerAttribute.currentHp.SetValue(playerAttribute.maxHp.GetValue());
        HPUIManager.instance.IncreaseHP(0, true);
        stateMachine.ChangeState(idleState);
    }
    #region �浵�Ͷ���
    public void Save(ref SaveStruct _saveDate)
    {
        if(saveLoder!=null)
            _saveDate.saveLoader = saveLoder.index;

        foreach (var kvp in dataBase.keyControllerPair)
        {
            _saveDate.dataBaseDict[kvp.Key] = (int)kvp.Value;
        }

        foreach (PlayerSkillGroup playerSkillGroup in skillController.canUseSkillGroups) 
        {
            if (playerSkillGroup == null)
                break;
            if (_saveDate.unlockPlayerSkillGroup.Contains(playerSkillGroup.name)==false)
                _saveDate.unlockPlayerSkillGroup.Add(playerSkillGroup.name);

        }

        _saveDate.sceneName = SceneManager.GetActiveScene().name;

        if (skillController.skill1CurrentSkillGroup != null)
            _saveDate.keyCodeAndSkill[0] = skillController.skill1CurrentSkillGroup.name;
        else
            _saveDate.keyCodeAndSkill[0] = string.Empty;
        if (skillController.skill2CurrentSkillGroup != null)
            _saveDate.keyCodeAndSkill[1] = skillController.skill2CurrentSkillGroup.name;
        else
            _saveDate.keyCodeAndSkill[1] = string.Empty;
        if (skillController.skill3CurrentSkillGroup != null)
            _saveDate.keyCodeAndSkill[2] = skillController.skill3CurrentSkillGroup.name;
        else
            _saveDate.keyCodeAndSkill[2] = string.Empty;
    }

    public void Load(SaveStruct _loadDate)
    {
       
        //�ѽ���������
        if (_loadDate.unlockPlayerSkillGroup.Count>0) 
        {
            foreach (string skillGroupName in _loadDate.unlockPlayerSkillGroup)
            {
                if (skillGroupName == windGroup.name)
                {
                    skillController.UnlockSkillGroup(windGroup);
                }
                if (skillGroupName == lightGroup.name)
                {
                    skillController.UnlockSkillGroup(lightGroup);
                }
                if (skillGroupName == iceAndFireGroup.name)
                {
                    skillController.UnlockSkillGroup(iceAndFireGroup);
                }
            } 
        }

        //������õİ������ܰ�
        if (_loadDate.keyCodeAndSkill .Count>0)
        {
            foreach (var keyCodeAndSkill in _loadDate.keyCodeAndSkill)
            {
                if (keyCodeAndSkill.Value == string.Empty)
                    return;
                if (keyCodeAndSkill.Key == 0)
                {
                    //SetSkillGroup(keyCodeAndSkill, "Skill1", dataBase.keyControllerPair["Skill1"]);
                }
                if (keyCodeAndSkill.Key == 1)
                {
                   // SetSkillGroup(keyCodeAndSkill, "Skill2", dataBase.keyControllerPair["Skill2"]);
                }
                if (keyCodeAndSkill.Key == 2)
                {
                   // SetSkillGroup(keyCodeAndSkill, "Skill3", dataBase.keyControllerPair["Skill3"]);
                }
            }
        }
    }

    private void SetSkillGroup(KeyValuePair<int, string> keyCodeAndSkill,string _skillIndex,KeyCode _skillKeyCode)
    {
        if (keyCodeAndSkill.Value == windGroup.name)
        {
            skillController.SwitchCurrentSkillGroup(_skillIndex, windGroup, _skillKeyCode);
        }
        if (keyCodeAndSkill.Value == lightGroup.name)
        {
            skillController.SwitchCurrentSkillGroup(_skillIndex, lightGroup, _skillKeyCode);
        }
        if (keyCodeAndSkill.Value == iceAndFireGroup.name)
        {
            skillController.SwitchCurrentSkillGroup(_skillIndex, iceAndFireGroup, _skillKeyCode);
        }
        if (keyCodeAndSkill.Value == cloneAndSwordGroup.name)
        {
            skillController.SwitchCurrentSkillGroup(_skillIndex, cloneAndSwordGroup, _skillKeyCode);
        }
    }

#endregion
}

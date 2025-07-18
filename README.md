# RPG-LYHC-Studdy
熊猫未来的类银河城RPG学习笔记


# 一、导入资产

![资产图片](..//RPG-LYHC-Study/Assets/Player_Graphics.png)





# 二、有限状态机（FSM）
## （一）创建有限状态机
1. 新建三个脚本 **EntityState 脚本** 和 **StateMachine 脚本** 和 **Player 脚本**
    - **StateMachine 状态机脚本** 用来管理状态的切换

    - **EntityState 实体状态脚本** 充当每个状态的父类

    - **Player 脚本** 用来引用运行状态机和状态

2. 修改 **EntityState 脚本**
    - 删除继承，清空类里的内容
    
    - 创建一个受保护的状态机 **stateMachine** ，用来应用访问状态机
    ```
    // 作为所有状态的父类
    public class EntityState  // 不用继承任何类
    {
        protected StateMachine stateMachine;  // 声明一个状态机，用来访问
    }
    ```

3. 在 **EntityState 脚本** 中新增一个构造函数，为这个类设置默认变量。当创建这个类的新实例时会自动调用
    ```
    // 作为所有状态的父类
    public class EntityState  // 不用继承任何类
    {
        protected StateMachine stateMachine;  // 声明一个状态机，用来访问


        // 构造函数，为这个类设置默认变量。当创建这个类的新实例时会自动调用
        public EntityState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    }
    ```

4. 在 **EntityState 脚本** 中添加 **Enter() 方法** 和 **Update() 方法** 和 **Exit() 方法**
    - **Enter() 方法** 在每次进入状态并更改状态时都会调用，初始化状态的一些默认内容
    
    - **Update() 方法** 用来执行运行状态的逻辑

    - **Exit() 方法** 在每次退出状态并更改为新状态时调用
    ```
    // virtual 允许在子脚本上重写这个方法
    // void 可以不用返回任何内容，只会执行方法内部的功能
    public virtual void Enter()
    {
        // 每次进入状态并更改状态时都会调用，初始化状态的一些默认内容

    }


    public virtual void Update()
    {
        // 执行运行状态的逻辑
    }


    public virtual void Exit()
    {
        // 每次退出状态并更改为新状态时调用
    }
    ```

5. 在 **Player 脚本** 中，写 **运行状态的更新的方法** 。连接到当前状态，并使用当前状态的 Update() 方法来运行状态的逻辑
    ```
    void Update()
    {
        // 连接到当前的状态，并使用当前状态的 Update() 方法来运行状态的逻辑
        // statemachine.currentState.Update();
    }
    ```

6. 在 **StateMachine 脚本** 中清理继承和其他代码
    ```
    public class StateMachine 
    {
        
    }
    ```

7. 在 **StateMachine 脚本** 中创建一个当前状态变量
    ```
    // 引用当前活动的状态，封装并保护它。刚创建时是没有指定状态的
    public EntityState currentState {  get; private set; }
    ```

8. 在 **StateMachine 脚本** 中初始化开始状态并进入开始状态
    ```
    // 初始化开始状态
    public void Initialize(EntityState startState)
    {
        // 分配开始状态
        currentState = startState;

        // 进入状态
        currentState.Enter();
    }
    ```

9. 在 **StateMachine 脚本** 中写改变状态并加入新状态的方法
    ```
    // 改变状态
    public void ChangeState(EntityState newState)
    {
        // 退出当前状态
        currentState.Exit();

        // 分配新状态
        currentState = newState;

        // 进入新状态
        currentState.Enter();
    }
    ```

10. 在 **EntityState 脚本** 中设置默认变量，并测试 **Enter() 方法 Update() 方法 Exit() 方法**
    ```
    protected string stateName;  // 状态名


    // 构造函数，为这个类设置默认变量（状态机，状态名）。当创建这个类的新实例时会自动调用
    public EntityState(StateMachine stateMachine ,string stateName)
    {
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }
    ```
    ```
    public virtual void Enter()
    {
        // 每次进入状态并更改状态时都会调用，初始化状态的一些默认内容
        Debug.Log("I enter " + stateName);
    }


    public virtual void Update()
    {
        // 执行运行状态的逻辑
        Debug.Log("I run update of " + stateName);
    }


    public virtual void Exit()
    {
        // 每次退出状态并更改为新状态时调用
        Debug.Log("I exit " + stateName);
    }
    ```

11. 在 **Player 脚本** 中清理代码
    ```
    public class Player : MonoBehaviour
    {
        
    }
    ```

12. 在 **Player 脚本** 中
    - 先声明一个 **状态机变量**，作为 Player 的状态机，并在 **Awake() 方法** 中 **分配状态机实例**
    - 在声明一个 **状态变量** ，作为 idle 空闲状态，并在 **Awake() 方法** 中 **分配状态实例** ，要传入 **Player 的状态机实例** ，和这个 **状态名**
    ```
    public class Player : MonoBehaviour
    {
        // 声明一个私有状态机变量
        private StateMachine stateMachine;

        // 声明一个 idle 状态
        private EntityState idleState;


        private void Awake()
        {
            // 分配一个新状态机实例
            stateMachine = new StateMachine();

            // 分配一个 Idle State 新状态实例，要传入状态机实例，和状态名
            idleState = new EntityState(stateMachine, "Idle State");
        }
    }
    ```

13. 在 **Player 脚本** 中
    - 在**Start() 方法** 中 **初始化状态机** 
    - 在**Update() 方法** 中 **执行当前状态**
    ```
    private void Start()
    {
        // 初始化状态机，初始状态为 idleState
        stateMachine.Initialize(idleState);
    }


    private void Update()
    {
        // 执行当前状态的 Update() 更新方法
        stateMachine.currentState.Update();
    }
    ```

14. 在 **Unity** 中新建一个空对象 **Player** ，把 **Player 脚本** 挂载上去，进行测试




## （二）添加新状态完善状态机基本结构
1. 把 **EntityState 类** 设为 **抽象类**
    ```
    // abstract 只是作为抽象类蓝图，无法直接使用，如果要使用就只能继承 EntityState 类后再使用
    public abstract class EntityState  // 不用继承任何类
    {
        ......
    }
    ```

2.  在 **Unity** 中新建一个脚本 **Player_IdleState 脚本** ，然后清空代码，修改继承为 **EntityState 类** ，在创建 **构造函数**
    ```
    public class Player_IdleState : EntityState  // 继承 EntityState 类
    {
        // 创建构造函数
        public Player_IdleState(StateMachine stateMachine, string stateName) : base(stateMachine, stateName)
        {

        }
    }
    ```

3.  在 **Player 脚本** 中修改 **idleState 空闲状态变量** 和 **其分配** ，最后进行测试
    ```
    // 声明一个 idle 状态
    private Player_IdleState idleState;
    ```
    ```
    private void Awake()
    {
        // 分配一个新状态机实例
        stateMachine = new StateMachine();

        // 分配一个 Idle State 新状态实例，要传入状态机实例，和状态名
        idleState = new Player_IdleState(stateMachine, "idle");
    }
    ```

4.  在 **Unity** 中新建一个脚本 **Player_MoveState 脚本**
    - 清空代码
    - 修改继承为 **EntityState 类**
    - 创建 **构造函数**
    ```
    public class Player_MoveState : EntityState  // 继承自 EntityState 类
    {
        // 生成构造函数
        public Player_MoveState(StateMachine stateMachine, string stateName) : base(stateMachine, stateName)
        {

        }
    }
    ```

5.  在 **Player 脚本** 中
    - 声明一个 **move 状态变量**
    - 分配一个 **MoveState 新状态实例**
    ```
    // 声明一个 move 状态
    private Player_MoveState moveState;
    ```
    ```
    // 分配一个 Move State 新状态实例
    moveState = new Player_MoveState(stateMachine, "move");
    ```

6.  在 **EntityState 脚本** 中创建 **player 变量**，并在 **构造函数** 中 **分配 player** ，用来访问状态内的 Player
    ```
    protected Player player;  // 声明一个玩家变量
    ```
    ```
    // 构造函数，为这个类设置默认变量（玩家，状态机，状态名）。当创建这个类的新实例时会自动调用
    public EntityState(Player player, StateMachine stateMachine, string stateName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }
    ```

7.  修改 **Player_IdleState 脚本** 和 **Player_MoveState 脚本** 的 **构造函数** 和 **Player 脚本** 的 **状态** 和 **状态分配**
    ```
    // 创建构造函数
    public Player_IdleState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {

    }
    ```
    ```
    public class Player_MoveState : EntityState  // 继承自 EntityState 类
    {
        // 生成构造函数
        public Player_MoveState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
        {
        }
    }
    ```
    ```
    // 声明一个 idle 状态
    public Player_IdleState idleState {  get; private set; }
    // 声明一个 move 状态
    public Player_MoveState moveState {  get; private set; }


    private void Awake()
    {
        // 分配一个新状态机实例
        stateMachine = new StateMachine();

        // 分配一个 Idle State 新状态实例，要传入状态机实例，和状态名
        idleState = new Player_IdleState(this, stateMachine, "idle");
        // 分配一个 Move State 新状态实例
        moveState = new Player_MoveState(this, stateMachine, "move");
    }
    ```

8. 在 **Player_IdleState 脚本** 中添加 **切换到移动状态的方法**
    ```
    public override void Update()
    {
        base.Update();

        // 按下 F 键，切换为移动状态
        if (Input.GetKeyDown(KeyCode.F))
            stateMachine.ChangeState(player.moveState);
    }
    ```

9. 在 **Player_MoveState 脚本** 中添加 **切换到空闲状态的方法**
    ```
    public override void Update()
    {
        base.Update();


        // 按下 G 键，切换到空闲状态
        if (Input.GetKeyDown(KeyCode.G))
            stateMachine.ChangeState(player.idleState);
    }
    ```
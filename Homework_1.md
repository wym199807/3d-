## Unity-基础概念
### 1.解释游戏对象(GameObjects)和资源(Assets)的区别与联系。
* 区别
    *  游戏对象(GameObjects)： 游戏中的每一个对象都是一个游戏对象。他们本身不会做任何事情，我们赋予他们各自的属性之后，就成为了我们在游戏中看到的角色或环境等。
可以将游戏对象比喻成一个空容器，再向其加入其中的组件和赋予其的属性后，它变得与其他游戏对象不同。例如玩家、环境、对手、摄像机、灯光等虚拟父类。
    *  资源(Assets): 资源有很多，比如对象、材质、场景、声音、预设、贴图、脚本和动作资源。这些资源可以在项目打开时，被导入到游戏里。可以被游戏对象使用，也可以被实例化为游戏对象。
* 联系 <br/>
     资源是可以被多个对象使用的，本身也可以进行实例化。对比起对象，资源更像是集成的可扩展的模板包。


### 2.编写一个代码，使用 debug 语句来验证 MonoBehaviour 基本行为或事件触发的条件。

* 基本行为包括 Awake() Start() Update() FixedUpdate() LateUpdate()
* 常用事件包括 OnGUI() OnDisable() OnEnable()

代码截图和控制台截图如下：

![image](https://github.com/wym199807/3d-/blob/master/Homework1-1.jpg?raw=true)

![image](https://github.com/wym199807/3d-/blob/master/Homework1-2.jpg?raw=true)

### 3.查找脚本手册，了解 GameObject，Transform，Component 对象。

* 分别翻译官方对三个对象的描述(Description)
    * GameObject
        * GameObjects are the fundamental objects in Unity that represent characters, props and scenery.
        * 游戏对象是在 Unity 中代表任务，道具和场景的基础对象
    * Transform
        * The Transform component determines the Position, Rotation, and Scale of each object in the scene.
        * 变化组件决定了场景中游戏对象的位置，大小和旋转关系。
    * Component
        * Components are the nuts & bolts of objects and behaviors in a game.
        * 组件是游戏对象和其对应行为之间的枢纽.
* 描述下图中 table 对象(实体)的属性、table 的 Transform 的属性、 table 的部件。

   ![image](https://github.com/wym199807/3d-/blob/master/Homework1-3.jpg?raw=true)
    * table 对象(实体)的属性
        * layer : Default
        * tag : Untagged
    * table 的 Transform 的属性
        * Position: (0, 0, 0)
        * Rotation: (0, 0, 0)
        * Scale : (1, 1, 1)
    * table 的部件
        * Transform
        * Mesh Renderer
        * Box Collider
    * table 的子对象
        * chair

* 用 UML 图描述 三者的关系(请使用 UMLet 14.1.1 stand-alone版本出图)。
  
   ![image](https://github.com/wym199807/3d-/blob/master/Homework1-4.jpg?raw=true)

### 4.整理相关学习资料，编写简单代码验证以下技术的实现：
* 查找对象

```csharp
//Finds a GameObject by name and returns it.
GameObject.Find("Name");
//Return a list of active GameObjects tagged tag.
//Return empty array if no GameObject was found.
GameObject.FindGameObjectsWithTag("TagName");
//Return one active GameObject tagged tag.
//Returns null if no GameObject was found.
GameObject.FindWithTag("TagName");
//Return the first active loaded object of Type type.
GameObject.FindObjectOfType("TypeName");
//Return a list of all active loaded objects of Type type.
GameObject.FindObjectsOfType("TypeName");
```

* 添加子对象

```csharp
GameObject.CreatePrimitive(PrimitiveType);
```

* 遍历对象树

```csharp
foreach(Transform child in transform) {
   //do something here
}
```

* 清除所有子对象

```csharp
foreach(Transform child in transform) {
   Destroy(child.gameObject);
}
```

### 5.预设与克隆
* 预设(Prefabs)有什么好处？与对象克隆 (clone or copy or Instantiate of Unity Object) 关系？
    * 预设是一个非常容易复用的类模板，可以迅速方便创建大量相同属性的对象、操作简单，代码量少，减少出错概率。修改的复杂度降低，一旦需要修改所有相同属性的对象，只需要修改预设即可，所有通过预设实例化的对象都会做出相应变化。而克隆只是复制一个一模一样的对象，这个对象独立于原来的对象，在修改的过程中不会影响原有的对象，这样不方便整体改动。
* 制作 table 预制，写一段代码将 table 预制资源实例化成游戏对象。

```csharp
public class NewBehaviourScript : MonoBehaviour {
    private string prePath = "prefabs/table";
    // Use this for initialization
    void Start () {
        GameObject Table =
            Instantiate(Resource.Load(prePath), new Vector(4, 0, 0), Quaternion.identity) as GameObject;
    }
}
```

### 6.尝试解释组合模式(Composite Pattern / 一种设计模式)并使用 BroadcastMessage() 方法向子对象发送消息。
* 组合模式（Composite Pattern），又叫部分整体模式，是用于把一组相似的对象当作一个单一的对象。组合模式依据树形结构来组合对象，用来表示部分以及整体层次。这种类型的设计模式属于结构型模式，它创建了对象组的树形结构。这种模式创建了一个包含自己对象组的类。该类提供了修改相同对象组的方式。组合模式是将对象组合成树形结构以表示“部分-整体”的层次结构，它使得用户对单个对象和组合对象的使用具有一致性。
经典案例：系统目录结构，网站导航结构等。组合模式的使用，使得Unity离散引擎灵活、易于扩展；Component强组合于GameObject,使得内存空间管理富有效率，提高了性能。

* 父类对象：

```csharp
public class ParentBehaviourScript : MonoBehaviour {
   // Use this for initialization
   void Start () {
       this.BroadcastMessage("Test");
   }
}
```

* 子类对象：

```csharp
public class ChildBehaviourScript : MonoBehaviour {
    void Test() {
        Debug.Log("Child Received");
    }
}
```

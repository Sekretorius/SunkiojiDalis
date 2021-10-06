using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;
using System.Diagnostics;
using Newtonsoft.Json;
using SunkiojiDalis.Hubs;
using SunkiojiDalis.Network;
using SunkiojiDalis;
using SunkiojiDalis.Character;
using SunkiojiDalis.Managers;

namespace SunkiojiDalis.Engine
{
    public class ServerEngine
    {
        private static ServerEngine instance;
        public static ServerEngine Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new ServerEngine();
                }
                return instance;
            }
            set { if(instance == null) instance = value; }
        }

        private static NetworkManager networkManager;
        public static NetworkManager NetworkManager 
        {
            get
            {
                if(networkManager == null)
                {
                    NetworkManager = new NetworkManager();
                }
                return networkManager;
            }
            set { if(networkManager == null) networkManager = value; }
        }

        public float UpdateTime { get; private set; } = 0;
        
        private readonly object ObjectProccessLock = new object();

        private List<IObject> waitingObjects = new List<IObject>();
        private Dictionary<string, IObject> instantiadedObjects = new Dictionary<string, IObject>();

        private int updateDelay = 300;
        private Stopwatch stopWatch;

        public void Initialize()
        {
            Task.Run(() => 
            {
                Console.WriteLine("SERVER ENGINE STARTING");
                UpdateTask();
            });

            networkManager = new NetworkManager();
            networkManager.SetHubContext(Program.IHubContext);

            NpcCreator npcCreator = new NpcCreator();
            NPC friendly = npcCreator.FactoryMethod(NpcType.Friendly);
            NPC enemy = npcCreator.FactoryMethod(NpcType.Enemy);
            
            friendly.SetMoveAlgorithm(new Stand());
            enemy.SetMoveAlgorithm(new Walk());
        }

        //creates instance only on server
        public void CreateServerObject(IObject newObject)
        {
            lock (ObjectProccessLock)
            {
                waitingObjects.Add(newObject);
            }
        }

        //creates instance on server and client
        public void CreateNetworkObject(INetworkObject newObject)
        {
            lock (ObjectProccessLock)
            {
                newObject.NetworkManager = networkManager;

                waitingObjects.Add(newObject);
            }
        }

        public async void UpdateTask()
        {
            while (true)
            {
                stopWatch = Stopwatch.StartNew();
                lock (ObjectProccessLock)
                {
                    //start
                    if(waitingObjects.Count > 0)
                    {
                        List<IObject> newObjects = new List<IObject>(waitingObjects);
                        waitingObjects.Clear();
                        
                        foreach (IObject newObject in newObjects)
                        {
                            newObject.GUID = Guid.NewGuid().ToString();
                            newObject.Init();
                            instantiadedObjects.Add(newObject.GUID, newObject);

                            if(newObject is NetworkObject)
                            {
                                NetworkManager.AddNewNetworkObject((NetworkObject)newObject);
                            }
                        }
                    }

                    //update
                    foreach (IObject updatingObject in instantiadedObjects.Values)
                    {
                        if(updatingObject.IsDestroyed)
                        {
                            //to do: remove destroyed objects
                            updatingObject.Destroy();
                        }
                        else
                        {
                            updatingObject.Update();
                        }
                    }
                }

                await Task.Delay(updateDelay);
                stopWatch.Stop();
                UpdateTime = (float)stopWatch.ElapsedMilliseconds / 1_000;
            }
        }

        public void InvokeObjectsMethod(string objectGuid, string method, object[] parameters)
        {
            if(instantiadedObjects.ContainsKey(objectGuid))
            {
                try
                {
                    IObject instantiadedObject = instantiadedObjects[objectGuid];
                    Type type = instantiadedObject.GetType();
                    MethodInfo methodInfo = type.GetMethod(method);
                    if(methodInfo == null) return;
                    methodInfo.Invoke(instantiadedObject, parameters);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    public interface IObject
    {
        string GUID { get; set; }
        bool IsDestroyed { get; set; }
        void Init();
        void Update();
        void Destroy();
    }

    public abstract class ServerObject : IObject
    {
        protected string guid = string.Empty;
        public virtual string GUID { get => guid; set => guid = value; }
        public ServerObject()
        {
            ServerEngine.Instance.CreateServerObject(this);
        }
        public virtual bool IsDestroyed { get; set; }
        public virtual void Init(){}
        public virtual void Update(){}
        public virtual void Destroy(){}
    }

    public enum ServerObjectType
    {
        None,
        Character,
        NPC,
        EnemyNpc,
        FriendlyNpc
    }
}
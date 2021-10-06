using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SunkiojiDalis.Engine;
using SunkiojiDalis.Hubs;


namespace SunkiojiDalis.Network
{
	public class NetworkManager : ServerObject
	{
        private readonly object ServerRequestProccessLock = new object();
        private readonly object ClientRequestProccessLock = new object();
        private readonly object ProccessNetworkObjectLock = new object();
        
        private const string ClientRequestHandlerMethod = "ClientRequestHandler";

        private IHubContext<ChatHub> GameHub;

        private List<NetworkObject> networkObjects = new List<NetworkObject>();
        private Dictionary<string, List<NetworkRequest>> networkRequestQueue = new Dictionary<string, List<NetworkRequest>>();
        private List<NetworkRequest> clientsRequestQueue = new List<NetworkRequest>();

        public NetworkManager() : base()
        {

        }
        
        public override bool IsDestroyed { get; set; }
        
        public void SetHubContext(IHubContext<ChatHub> Hub)
        {
            GameHub = Hub;
        }

        public override void Init() 
        { 
            Console.WriteLine("NETWORK MANAGER STARTING");
        }

        public override void Update() 
        {
            //proccess server requests
            if(networkRequestQueue.Values.Count != 0)
            {
                lock(ClientRequestProccessLock)
                {
                    List<Task> messageTasks = new List<Task>();
                    foreach(string requestMethod in networkRequestQueue.Keys)
                    {
                        messageTasks.Add(Task.Run(async () => { await SyncDataWithClients(networkRequestQueue[requestMethod]); }));
                    }
                    Task sendMessagesTask = Task.WhenAll(messageTasks);
                    sendMessagesTask.Wait(); 
                    
                    networkRequestQueue.Clear();
                }
            }

            //proccess client requests
            if(clientsRequestQueue.Count != 0)
            {
                lock(ServerRequestProccessLock)
                {
                    foreach(NetworkRequest clientsRequest in clientsRequestQueue)
                    {
                        ServerEngine.Instance.InvokeObjectsMethod(clientsRequest.RequestObjectGuid, clientsRequest.RequestMethod, new object[] { clientsRequest.RequestData });
                    }
                    clientsRequestQueue.Clear();
                }
            }
        }

        public void AddNewNetworkObject(NetworkObject networkObject){
            lock(ProccessNetworkObjectLock)
            {
                networkObjects.Add(networkObject);
                AddRequest(new NetworkRequest(
                    networkObject.GUID,
                    nameof(MainNetworkRequests.CreateClientObject),
                    JsonConvert.SerializeObject(networkObject.OnClientSideCreation())
                ));
            }
        }

        public void AddRequest(NetworkRequest request)
        {
            lock(ServerRequestProccessLock)
            {
                if(!networkRequestQueue.ContainsKey(request.RequestMethod))
                {
                    networkRequestQueue.Add(request.RequestMethod, new List<NetworkRequest>());
                }
                networkRequestQueue[request.RequestMethod].Add(request);
            }
        }

        public async Task SyncDataWithClient(List<NetworkRequest> requests)
        {
            //need better handling of client player
            //need to get iclientproxy to send request to wanted player

            //then need to separe requests in groups of send type
            //and lastly proccess them in update
            throw new NotImplementedException();
        }

        public async Task SyncDataWithClients(List<NetworkRequest> requests)
        {
            if (GameHub == null || requests == null || requests.Count == 0) return;
            string requestData = JsonConvert.SerializeObject(requests);
            await GameHub.Clients.All.SendAsync(ClientRequestHandlerMethod, requestData);
        }

        public void HandleClientRequest(string incommingData)
        {
            if(string.IsNullOrEmpty(incommingData)) return;
            try
            {
                lock(ClientRequestProccessLock)
                {
                    List<NetworkRequest> clientsRequests = JsonConvert.DeserializeObject<List<NetworkRequest>>(incommingData);
                    clientsRequestQueue.AddRange(clientsRequests);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private List<NetworkRequest> FormAllObjectCreateRequest()
        {
            lock(ProccessNetworkObjectLock)
            {
                List<NetworkRequest> createRequests = new List<NetworkRequest>();
                foreach (NetworkObject networkObject in networkObjects)
                {
                    createRequests.Add(new NetworkRequest(
                        networkObject.GUID,
                        nameof(MainNetworkRequests.CreateClientObject),
                        JsonConvert.SerializeObject(networkObject.OnClientSideCreation())
                    ));
                }
                return createRequests;
            }
        }

        public async Task OnNewClientConnected(IClientProxy client)
        {
            List<NetworkRequest> requestForms = FormAllObjectCreateRequest();
            if(requestForms.Count > 0)
            {
                string requestData = JsonConvert.SerializeObject(requestForms);
                await client.SendAsync(ClientRequestHandlerMethod, requestData);
            }
        }

        public override void Destroy() 
        { 
        
        }
    }

#region NetworkObjects

	public interface INetworkObject : IObject
	{
        NetworkManager NetworkManager { get; set; }
        Dictionary<string, string> OnClientSideCreation();
	}


    public abstract class NetworkObject : INetworkObject
    {
        [JsonIgnore] protected string guid = string.Empty;

        [JsonIgnore] public NetworkManager NetworkManager { get; set; }
        [JsonIgnore] public virtual string GUID { get => guid; set => guid = value; }
        [JsonIgnore] public virtual bool IsDestroyed { get; set; }
        
        public NetworkObject()
        {
            ServerEngine.Instance.CreateNetworkObject(this);
        }

        public virtual void Init() { }
        public virtual void Update() { }
        public virtual void Destroy() { }

//        protected void SyncDataWithClient(string method, int clientId, string json)
//        {
            //needs different player handling
//        }

        protected void SyncDataWithClients(string method, string dataJson)
        {
            NetworkManager.AddRequest(new NetworkRequest(guid, method, dataJson));
        }

        public virtual Dictionary<string, string> OnClientSideCreation()
        {
            return new Dictionary<string, string>();
        }
    }

#endregion

#region NetworkRequests

    public class NetworkRequest
    {
        public string RequestObjectGuid { get; set; }
        public string RequestMethod { get; set; }
        public string RequestData { get; set; }

        public NetworkRequest(string requestObjectGuid, string requestMethod, string dataJson)
        {
            RequestObjectGuid = requestObjectGuid;
            RequestMethod = requestMethod;
            RequestData = dataJson;
        }
    }

#endregion

#region MainRequests
    public enum MainNetworkRequests
    {
        CreateClientObject,
    }
#endregion
}

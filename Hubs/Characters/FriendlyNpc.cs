using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SignalRWebPack.Engine;

namespace SignalRWebPack.Characters
{
    public class FriendlyNpc : NPC
    {
        public FriendlyNpc(
            string name = null, 
            float health = 0, 
            string sprite = null, 
            string areaId = "", 
            Vector2D position = null, 
            int width = 0, 
            int height = 0, 
            int frameX = 0, 
            int frameY = 0, 
            int speed = 0,
            bool moving = false) : base(name, health, sprite, areaId, position, width, height, frameX, frameY, speed, moving){}

        public override void Update()
        {
            //MoveAlgorithm.Move(ref x, ref y, speed);
            //SyncDataWithClients("SyncPosition", $"{{\"x\":\"{x}\", \"y\":\"{y}\"}}");
        }

        public override void Shout(){}
        public override void SetAttackAlgorithm(AttackAlgorithm attackAlgorithm){}
        //public override void SetMoveAlgorithm(MoveAlgorithm moveAlgorithm){}
        public override AttackAlgorithm GetAttackAlgorithm(){ return null; }
        public override MoveAlgorithm GetMoveAlgorithm(){ return null; }
        public override void Move(){}
        public override void Attack(){}
        public override void Die(){}

        public override Dictionary<string, string> OnClientSideCreation()
        {
            Dictionary<string, string> friendlyNpcData = base.OnClientSideCreation();
            friendlyNpcData["objectType"] = nameof(ServerObjectType.FriendlyNpc);
            
            return friendlyNpcData;
        }
    }
}
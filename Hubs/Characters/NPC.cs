using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SignalRWebPack.States;

namespace SignalRWebPack.Characters
{
    public abstract class NPC : Character
    {
        State currentState;
        public NPC(
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
            bool moving = false) : base(name, health, sprite, position, width, height, frameX, frameY, areaId, speed, moving){currentState = new IdleState();}
        
        public abstract void Shout();
        public string getName() {
            return this.name;
        }

        public void StateChange(){
            Console.WriteLine("Initializing state change: ");
            if(this.currentState is IdleState){
                this.currentState = new PatrolState();
            }
            else if(this.currentState is PatrolState){
                this.currentState = new AttackState();
            }
            else if(this.currentState is AttackState){
                this.currentState = new RetreatState();
            }
            else if(this.currentState is RetreatState && health == 0){
                this.currentState = new HealState();
            }
            else if(this.currentState is HealState ){
                this.currentState = new PatrolState();
            }
            currentState.Handle(this);         
        }
    }

    public enum NpcType
    {
        Friendly,
        Enemy,
        Animal
    }
}

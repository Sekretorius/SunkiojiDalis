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
            //Console.WriteLine("Initializing state change for "+ name);
            if(this.currentState is IdleState && (name.Equals("animal") || name.Equals("fast_enemy")|| name.Equals("normal_enemy") || name.Equals("slow_enemy"))){
                this.currentState = new PatrolState();
                Console.WriteLine(name + " changed to patrol");
            }
            else if(this.currentState is PatrolState){
                this.currentState = new AttackState();
                Console.WriteLine(name + " changed to attack");
            }
            else if(this.currentState is AttackState){
                this.currentState = new RetreatState();
                Console.WriteLine(name + " changed to retreat");
            }
            else if(this.currentState is RetreatState && health < 10){
                this.currentState = new HealState();
                Console.WriteLine(name + " changed to heal");
            }
            else if(this.currentState is HealState && health >= 200){
                this.currentState = new PatrolState();
                Console.WriteLine(name + " changed to patrol");
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

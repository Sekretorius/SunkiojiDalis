using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Hubs;

namespace SignalRWebPack.Proxies
{
    public class Proxycheck : Ourproxy
    {
        Player playerdata;
        private int worldx;
        private int worldy;
        private int x;
        private int y;

        Trueproxy trueproxy;

        public Proxycheck(Player playerdatas, int worldxs, int worldys,int xs, int ys){
            playerdata = playerdatas;
            worldx = worldxs;
            worldy = worldys;
            x = xs;
            y = ys;
        }

        public void check(){
             if(worldx !=2 && worldy !=2){
                trueproxy = new Trueproxy(playerdata, worldx, worldy, x, y);
                trueproxy.check();
            }
            else{
                Console.WriteLine("Negalima persokti");
            }
        }
    }
}
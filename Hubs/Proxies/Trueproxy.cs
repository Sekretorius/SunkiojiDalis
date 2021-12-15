using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Hubs;

namespace SignalRWebPack.Proxies
{

    public class Trueproxy : Ourproxy
    {
        Player playerdata;
        private int worldx;
        private int worldy;
        private int x;
        private int y;

        public Trueproxy(Player playerdatas, int worldxs, int worldys,int xs, int ys){
            playerdata = playerdatas;
            worldx = worldxs;
            worldy = worldys;
            x = xs;
            y = ys;
        }

        public void check(){
            Console.WriteLine("Persokau i kita area, kuri yra autorizuota");
             World.Instance.MoveToArea(playerdata, worldx, worldy, x, y);
        }
    }
}
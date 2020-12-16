using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeRepo
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> RoomList;
        public Badge()
        {
            RoomList = new List<string>();
        }
        public Badge(int  idNum, List<string> roomList)
        {
            BadgeID = idNum;
            RoomList = roomList;
        }
    }
}

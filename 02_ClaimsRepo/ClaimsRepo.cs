using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsRepo
{
    public class ClaimsRepo
    {
        public ClaimsRepo()
        {
            _claimsQueue = new Queue<Claims>();
        }
        Queue<Claims> _claimsQueue = new Queue<Claims>();

        public bool AddClaim(Claims newClaim)
        {
            if (_claimsQueue.Contains(newClaim))
            {
                return false;
            }
            else
            {
                _claimsQueue.Enqueue(newClaim);
                return true;
            }
        }
        public Queue<Claims> GetClaimsQueue()
        {
            return _claimsQueue;
        }
        public void RemoveClaim()//no parameters since it is a queue it will always remove first item in queue
        {
            
            _claimsQueue.Dequeue();
        }
       
        
    }
}

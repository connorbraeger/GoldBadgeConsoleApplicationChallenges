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

        public void AddClaim(Claims newClaim)
        {

            _claimsQueue.Enqueue(newClaim);
        }
        public Queue<Claims> GetClaimsQueue()
        {
            return _claimsQueue;
        }
        public void RemoveClaim()
        {
            _claimsQueue.Dequeue();
        }
       
        public Claims GetByClaimID(int idNum)
        {
            foreach (Claims claim in _claimsQueue)
            {
                if (claim.ClaimNumber == idNum)
                {
                    return claim;
                }
            }return null;
            

            
        }
    }
}

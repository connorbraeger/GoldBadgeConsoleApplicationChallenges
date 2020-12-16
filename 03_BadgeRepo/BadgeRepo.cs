using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeRepo
{
    public class BadgeRepo
    {
        private Dictionary<int, Badge> _badgeDictionary;
        public BadgeRepo()
        {
            _badgeDictionary = new Dictionary<int, Badge>();
        }
        public bool AddBadge(Badge newBadge)
        {
            if (_badgeDictionary.ContainsKey(newBadge.BadgeID))
            {
                return false;
            }
            else
            {
                _badgeDictionary.Add(newBadge.BadgeID, newBadge);
                return true;
            }
        }
        public Dictionary<int, Badge> GetBadgeDictionary()
        {
            return _badgeDictionary;
        }
        public bool UpdateBadge(Badge badge)
        {
            if (!_badgeDictionary.ContainsKey(badge.BadgeID))
            {
                return false;
            }
            else
            {
                _badgeDictionary[badge.BadgeID] = badge;
                return true;
            }
        }
        public bool deleteBadge(Badge badge)
        {
            if (!_badgeDictionary.ContainsKey(badge.BadgeID))
            {
                return false;
            }
            else
            {
                _badgeDictionary.Remove(badge.BadgeID);
                return true;
            }
        }
    }
}
